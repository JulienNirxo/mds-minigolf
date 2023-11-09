using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hache : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Vitesse de rotation en degrés par seconde
    public float hoverHeight = 5.0f;    // Hauteur à laquelle l'objet doit rester bloqué

    void Update()
    {
        // Faites tourner l'objet autour de l'axe Z
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }
}
