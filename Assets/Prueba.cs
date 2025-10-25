using UnityEngine;

public class Prueba : MonoBehaviour
{
    string jugador1 = "Pepito";
    string jugador2 = "Mariana";
    string jugador3 = "Phil";

    void Start()
    {
        //array
        string[] jugadores = new string[3];
        jugadores[0] = jugador1;
        jugadores[1] = jugador2;
        jugadores[2] = jugador3;

        //for
        for(int indice = 0; indice < jugadores.Length; indice++)
        {
            print(jugadores[indice]);
        }
    }
}
