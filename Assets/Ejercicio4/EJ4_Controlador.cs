using UnityEngine;

namespace Ejercicio4
{
    public class EJ4_Controlador : MonoBehaviour
    {
        public string nombreBomba = "bomba";
        public string nombreMoneda = "moneda";
        
        public string ObtenerMoneda(string[] objetos)
        {
            //Hacer que recorra todos los objetos
            //Hacer que devuelva si el nombre es igual a "moneda"

            return objetos[0];
        }

        public string ObtenerBomba(string[] objetos)
        {
            //Hacer que recorra todos los objetos
            //Hacer que devuelva si el nombre es igual a "bomba"

            return objetos[1];
        }
    }
}