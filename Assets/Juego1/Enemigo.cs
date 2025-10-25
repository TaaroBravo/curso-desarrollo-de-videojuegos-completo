using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    private void Start()
    {
        int numeroRandom = Random.Range(1, 4);

        if(numeroRandom == 1)
        {
            float positionEnXRandom = Random.Range(-10, 10);
            transform.position = new Vector3(positionEnXRandom, 8, 0);
        }
        else if (numeroRandom == 2)
        {
            float positionEnXRandom = Random.Range(-10, 10);
            transform.position = new Vector3(positionEnXRandom, -8, 0);
        }
        else if (numeroRandom == 3)
        {
            float positionEnYRandom = Random.Range(-8, 8);
            transform.position = new Vector3(-12, positionEnYRandom, 0);
        }
        else
        {
            float positionEnYRandom = Random.Range(-8, 8);
            transform.position = new Vector3(12, positionEnYRandom, 0);
        }

        Vector3 posicionJugador = FindObjectOfType<AutoJugador>().transform.position;
        transform.up = posicionJugador - transform.position;


    }

    void Update()
    {
        transform.position += transform.up * 4 * Time.deltaTime; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
