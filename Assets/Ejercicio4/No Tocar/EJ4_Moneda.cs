using UnityEngine;

namespace Ejercicio4
{
    public class EJ4_Moneda : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            Destroy(gameObject);
        }
    }
}