using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Juego2.Scripts
{
    public class JugadorPlataformero : MonoBehaviour
    {
        public GameObject winUI;
        public TextMeshProUGUI pointsUI;
        public Rigidbody2D rigidBody;
        public AudioSource pickUpSound;
        public int jumps = 2;
        public int points;

        Vector3 _initialPosition;
        private void Start()
        {
            _initialPosition = transform.position;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && jumps > 0)
            {
                rigidBody.linearVelocity = Vector3.zero;
                rigidBody.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                jumps--;
            }

            rigidBody.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * 5, rigidBody.linearVelocity.y);

            if(transform.position.y < -6)
            {
                transform.position = _initialPosition;
                rigidBody.linearVelocity = Vector3.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Manzana>())
            {
                points += 10;
                pointsUI.text = "Puntos :" + points;
                pickUpSound.Play();
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.GetComponent<ZonaFinal>())
            {
                winUI.SetActive(true);
                SceneManager.LoadScene("Menu");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            jumps = 2;

            if (collision.gameObject.GetComponent<PlataformaMovible>())
            {
                transform.parent = collision.transform;
            }

            if (collision.gameObject.GetComponent<BloqueEnemigo>())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlataformaMovible>())
            {
                transform.parent = null;
            }
        }

    }
}
