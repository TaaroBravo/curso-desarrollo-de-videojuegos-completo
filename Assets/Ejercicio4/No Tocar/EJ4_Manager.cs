using System;
using System.Collections.Generic;
using System.Linq;
using Ejercicio4;
using UnityEngine;
using Random = UnityEngine.Random;

public class EJ4_Manager : MonoBehaviour
{
    public static EJ4_Manager Instance { get; private set; }
    public EJ4_Controlador Controlador;

    public GameObject winPopup;
    public GameObject losePopup;
    public GameObject bombPrefab;
    public GameObject coinPrefab;
    public Transform[] spawnPoints;

    private float timerLeft = 1;
    private float timerRight = 1.5f;

    private List<string> _objetsToCreate;
    private List<string> _currentObjectsLeft;
    private List<string> _currentObjectsRight;

    private void Start()
    {
        Instance = this;
        
        _objetsToCreate = new List<string>
        {
            Controlador.nombreBomba,
            Controlador.nombreMoneda,
            Controlador.nombreBomba,
            Controlador.nombreBomba,
            Controlador.nombreMoneda,
            Controlador.nombreBomba,
            Controlador.nombreMoneda,
            Controlador.nombreBomba,
            Controlador.nombreMoneda,
            Controlador.nombreBomba,
            Controlador.nombreMoneda
        };

        _currentObjectsLeft = _objetsToCreate.ToList();
        _currentObjectsRight = _objetsToCreate.ToList();
        _currentObjectsRight.Sort();
    }

    private void Update()
    {
        timerLeft -= Time.deltaTime;
        timerRight -= Time.deltaTime;

        if (timerLeft < 0)
        {
            CreateForLeft();
            timerLeft = Random.Range(1f, 2f);
        }

        if (timerRight < 0)
        {
            CreateForRight();
            timerRight = Random.Range(1f, 2f);
        }
        
        if (FindObjectsOfType<EJ4_Enemigo>().Length == 0)
        {
            winPopup.SetActive(true);
        }
    }

    private void CreateForRight()
    {
        if (_currentObjectsRight.Count == 1 || _currentObjectsRight.All(x => x != Controlador.nombreBomba))
            _currentObjectsRight = _objetsToCreate.ToList();
        var objeto = Controlador.ObtenerBomba(_currentObjectsRight.ToArray());
        _currentObjectsRight.Remove(objeto);
        if (objeto == Controlador.nombreBomba)
        {
            var bomb = Instantiate(bombPrefab);
            var spawnPoint = spawnPoints[2].position;
            spawnPoint.x = Random.Range(spawnPoints[2].position.x, spawnPoints[3].position.x);
            bomb.transform.position = spawnPoint;
        }
        else if(objeto == Controlador.nombreMoneda)
        {
            var coin = Instantiate(coinPrefab);
            var spawnPoint = spawnPoints[2].position;
            spawnPoint.x = Random.Range(spawnPoints[2].position.x, spawnPoints[3].position.x);
            coin.transform.position = spawnPoint;
        }
    }

    private void CreateForLeft()
    {
        if (_currentObjectsLeft.Count == 1 || _currentObjectsRight.All(x => x != Controlador.nombreMoneda))
            _currentObjectsLeft = _objetsToCreate.ToList();
        var objeto = Controlador.ObtenerMoneda(_currentObjectsLeft.ToArray());
        _currentObjectsRight.Remove(objeto);
        if (objeto == Controlador.nombreBomba)
        {
            var bomb = Instantiate(bombPrefab);
            var spawnPoint = spawnPoints[0].position;
            spawnPoint.x = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x);
            bomb.transform.position = spawnPoint;
        }
        else if(objeto == Controlador.nombreMoneda)
        {
            var coin = Instantiate(coinPrefab);
            var spawnPoint = spawnPoints[0].position;
            spawnPoint.x = Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x);
            coin.transform.position = spawnPoint;
        }
    }

    public void RemovePerson(EJ4_Persona person)
    {
        Destroy(person.gameObject);
        losePopup.SetActive(true);
        winPopup.SetActive(false);
    }

    public void RemoveEnemy(EJ4_Enemigo enemy)
    {
        Destroy(enemy.gameObject);
        
    }
}