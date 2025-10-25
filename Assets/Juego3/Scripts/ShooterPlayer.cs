using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShooterPlayer : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Rigidbody rigidbody;
    public Transform spawnPoint;
    public LayerMask groundLayer;
    public Animator animator;
    public SkinnedMeshRenderer meshRenderer;
    public UIManager uiManager;
    public int lives = 3;
    public float speed = 5;

    private bool _canGetHit = true;
    private float _noHitTime = 2;

    private void Start()
    {
        uiManager.SetNewLife(lives);
    }

    void Update()
    {
        if (lives <= 0)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.forward = hitPoint - transform.position;
        }
        animator.SetFloat("speed_animator", GetInput().magnitude);
        transform.position += GetInput() * speed * Time.deltaTime;

        if(Input.GetMouseButtonDown(0))
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.up = transform.forward;
        }

        if (!_canGetHit)
        {
            _noHitTime -= Time.deltaTime;
            if(_noHitTime < 0)
            {
                _canGetHit = true;
                _noHitTime = 2;

                AssignColor(Color.white);
            }
        }
    }

    Vector3 GetInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ZombieEnemy>())
        {
            uiManager.AddScore(10);
            Destroy(collision.gameObject);
            if (_canGetHit)
            {
                _canGetHit = false;
                animator.SetTrigger("hitted");
                AssignColor(Color.red);
                lives--;
                uiManager.SetNewLife(lives);
                if (lives <= 0)
                    uiManager.ShowEndGamePopup();
            }
        }
    }

    void AssignColor(Color color)
    {
        Material material = new Material(meshRenderer.material);
        material.color = color;
        meshRenderer.material = material;
    }
}
