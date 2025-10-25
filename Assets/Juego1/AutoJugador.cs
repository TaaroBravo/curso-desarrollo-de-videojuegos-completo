using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoJugador : MonoBehaviour
{
    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.up = Vector3.up;
            transform.position += Vector3.up * Time.deltaTime * velocidad;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.up = Vector3.down;
            transform.position += Vector3.down * Time.deltaTime * velocidad;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.up = Vector3.left;
            transform.position += Vector3.left * Time.deltaTime * velocidad;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.up = Vector3.right;
            transform.position += Vector3.right * Time.deltaTime * velocidad;
        }

        if(transform.position.y > 8)
        {
            Vector3 nuevaPosition = transform.position;
            nuevaPosition.y = -6;
            transform.position = nuevaPosition;
        }
        if (transform.position.y < -6)
        {
            Vector3 nuevaPosition = transform.position;
            nuevaPosition.y = 8;
            transform.position = nuevaPosition;
        }

        if (transform.position.x < -12)
        {
            Vector3 nuevaPosition = transform.position;
            nuevaPosition.x = 12;
            transform.position = nuevaPosition;
        }
        if (transform.position.x > 12)
        {
            Vector3 nuevaPosition = transform.position;
            nuevaPosition.x = -12;
            transform.position = nuevaPosition;
        }
    }
}
