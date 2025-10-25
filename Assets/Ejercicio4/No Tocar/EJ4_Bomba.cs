using UnityEngine;

namespace Ejercicio4
{
    public class EJ4_Bomba : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!GetComponent<BoxCollider2D>().enabled)
                return;
            _animator.SetTrigger("explote");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            if(col.gameObject.GetComponent<EJ4_Persona>())
                EJ4_Manager.Instance.RemovePerson(col.gameObject.GetComponent<EJ4_Persona>());
            else if(col.gameObject.GetComponent<EJ4_Enemigo>())
                EJ4_Manager.Instance.RemoveEnemy(col.gameObject.GetComponent<EJ4_Enemigo>());
        }

    }
}