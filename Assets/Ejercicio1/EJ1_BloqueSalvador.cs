using UnityEngine;

namespace Ejercicio_1
{
    public class EJ1_BloqueSalvador : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Rigidbody>().mass = 20000;
        }
    }
}