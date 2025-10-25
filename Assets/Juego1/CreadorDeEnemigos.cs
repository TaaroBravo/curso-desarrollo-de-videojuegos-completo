using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDeEnemigos : MonoBehaviour
{
    public GameObject prefabDelEnemigo;

    float tiempo = 0.5f;

    void Update()
    {
        tiempo -= Time.deltaTime;
        if(tiempo < 0)
        {
            tiempo = 0.5f;
            Instantiate(prefabDelEnemigo);
        }
    }
}
