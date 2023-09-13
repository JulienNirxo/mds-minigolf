using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Vector3 mousePressDownPos;
    private Vector3 lastMousePos;
    

    private Rigidbody rb;
    public CinemachineVirtualCamera virtualCamera; 

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
            GameManager.Instance.Retry();
        }
        
    }

    // variables de forces
    private float forceMultiplier = 1f;
    private float maxForce = 1000f; 

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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            GameManager.Instance.EndGame();
        }
    }

}
