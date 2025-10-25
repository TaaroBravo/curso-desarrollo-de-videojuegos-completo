using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    private ShooterPlayer _player;
    private UIManager _uiManager;

    void Start()
    {
        _player = FindObjectOfType<ShooterPlayer>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        transform.forward = _player.transform.position - transform.position;
        transform.position += transform.forward * 3 * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            _uiManager.AddScore(100);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
