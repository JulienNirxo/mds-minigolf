using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    #region fields
    public GameObject objectToSpawn;
    private Vector3 mousePressDownPos;
    private Vector3 lastMousePos;
    //call my script Counter
    public Count counter;
    public Score score;

    

    private Rigidbody rb;
    private GameManager gameManager;
    public CinemachineVirtualCamera virtualCamera; 
    public int _numberOfShoot = 0;

    private float forceMultiplier = 1f;
    private float maxForce = 1000f;
    #endregion fields
    
    #region properties
    public int NumberOfShoot{
        get => _numberOfShoot;
    }
    #endregion properties

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePressDownPos = Input.mousePosition;
            lastMousePos = mousePressDownPos;
        }
        else if (Input.GetMouseButton(0))
        {
            lastMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Shoot(lastMousePos - mousePressDownPos);
        }

        if (transform.position.y < -10)
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.Retry();
            Debug.Log("Fall");
        }
        
    }

     

    void Shoot(Vector3 Force)
    {
        // calcul de la force appliqué
        Vector3 appliedForce = new Vector3(-Force.x, 0, -Force.y) * forceMultiplier;

        // Force maximum
        if (appliedForce.magnitude > maxForce)
        {
            appliedForce = appliedForce.normalized * maxForce;
        }

        rb.AddForce(appliedForce);
        _numberOfShoot++;
        counter.DisplayCount(NumberOfShoot);
    }

    public int GetNumberOfShoot()
    {
        return _numberOfShoot;
    }

    void LateUpdate()
    {
        // Faites en sorte que la caméra Cinemachine suive la position de la balle à chaque frame.
        if (virtualCamera != null)
        {
            virtualCamera.transform.position = transform.position;
        }
    }

    //si ma balle touche l'objet avec le tag goal je détruit la balle et je spawn un nouveau objectToSpawn
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name); // Ajoutez cette ligne
        if (collision.gameObject.tag == "goal")
        {
            Debug.Log("SHOOOT : " + _numberOfShoot);
            
            score.DetermineScoreMessage(_numberOfShoot);
            InvokeRepeating("changeScene", 2.0f, 0.3f);
            
        }
    }

    void changeScene()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.GestionOfTerrain();
    }
}
