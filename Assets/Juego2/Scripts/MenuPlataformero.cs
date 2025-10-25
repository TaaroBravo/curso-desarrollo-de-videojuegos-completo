using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlataformero : MonoBehaviour
{
    public Button botonNivel1;
    public Button botonNivel2;
    public Button botonNivel3;
    public Button botonSalir;

    void Start()
    {
        botonNivel1.onClick.AddListener(CargarNivel1);
        botonNivel2.onClick.AddListener(CargarNivel2);
        botonNivel3.onClick.AddListener(CargarNivel3);
        botonSalir.onClick.AddListener(Salir);
    }

    void Salir()
    {
        Application.Quit();
    }

    void CargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    void CargarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }

    void CargarNivel3()
    {
        SceneManager.LoadScene("Nivel3");
    }

}