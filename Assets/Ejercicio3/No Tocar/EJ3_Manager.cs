using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Utils;

public class EJ3_Manager : MonoBehaviour
{
    public EJ3_Jugador anne;
    public EJ3_Jugador henry;
    public EJ3_Jugador jack;

    public Transform[] pathfindingAnne;
    public Transform[] pathfindingHenry;
    public Transform[] pathfindingJack;

    public TextMeshProUGUI anneName;
    public TextMeshProUGUI henryName;
    public TextMeshProUGUI jackName;

    public GameObject[] bombs;
    public GameObject[] bombsObjects;
    
    public GameObject losePopup;
    public GameObject winPopup;
    
    private Dictionary<EJ3_Jugador, Transform[]> _paths;
    private Dictionary<EJ3_Jugador, int> _distances;

    private int _playersSaved;

    private void Start()
    {
        _paths = new Dictionary<EJ3_Jugador, Transform[]>
        {
            {anne, pathfindingAnne},
            {henry, pathfindingHenry},
            {jack, pathfindingJack},
        };

        _distances = new Dictionary<EJ3_Jugador, int>
        {
            {anne, 1},
            {henry, 11},
            {jack, 5},
        };
        
        MakeDecision(anne);
        Observable.Timer(TimeSpan.FromSeconds(2))
            .DoOnCompleted(() => MakeDecision(henry))
            .Delay(TimeSpan.FromSeconds(2))
            .DoOnCompleted(() => MakeDecision(jack))
            .Delay(TimeSpan.FromSeconds(2))
            .DoOnCompleted(() =>
            {
                if(_playersSaved >= 3)
                    winPopup.SetActive(true);
            })
            .Subscribe()
            .AddTo(this);

    }

    void MakeDecision(EJ3_Jugador player)
    {
        var decision = player.Decision(_distances[player]);
        if (decision == player.desactivar)
            Desactivar(player);
        else if (decision == player.correr)
            Correr(player);
        else if(decision == player.saludar)
            Saludar(player);
        
        Observable.Timer(TimeSpan.FromSeconds(1))
            .DoOnCompleted(() => ExploteFor(player))
            .Subscribe()
            .AddTo(this);
    }

    private void Correr(EJ3_Jugador player)
    {
        player.transform.forward = -player.transform.forward;
        player.GetComponent<Animator>().SetTrigger("run");

        RxTween.Make(0, 1, 1, Easings.Linear)
            .Do(value =>
            {
                player.transform.position =
                    Vector3.Lerp(_paths[player][0].position, _paths[player][1].position, value);
            })
            .Subscribe()
            .AddTo(this);
    }

    private void Desactivar(EJ3_Jugador player)
    {
        player.GetComponent<Animator>().SetTrigger("walk");

        RxTween.Make(0, 1, 1, Easings.Linear)
            .Do(value =>
            {
                player.transform.position =
                    Vector3.Lerp(_paths[player][2].position, _paths[player][3].position, value);
            })
            .Subscribe()
            .AddTo(this);
 
    }

    private void Saludar(EJ3_Jugador player)
    {
        player.GetComponent<Animator>().SetTrigger("wave");
    }

    private void ExploteFor(EJ3_Jugador player)
    {
        var decision = player.Decision(_distances[player]);
        if (player == anne)
        {
            if (decision == anne.desactivar)
            {
                _playersSaved++;
                player.GetComponent<Animator>().SetTrigger("idle");
                anneName.color = Color.green;
            }
            else
            {
                losePopup.SetActive(true);

                bombs[0].SetActive(true);
                bombsObjects[0].SetActive(false);
                anne.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Impulse);
                anneName.color = Color.red;
            }
        }
        else if (player == henry)
        {
            if (decision == henry.correr)
            {
                _playersSaved++;
                player.GetComponent<Animator>().SetTrigger("idle");
                henryName.color = Color.green;
            }
            else
            {
                losePopup.SetActive(true);

                bombs[1].SetActive(true);
                bombsObjects[1].SetActive(false);

                henry.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Impulse);
                henryName.color = Color.red;
            }
        }
        else if (player == jack)
        {
            if (decision == henry.saludar)
            {
                _playersSaved++;
                jackName.color = Color.green;
            }
            else
            {
                losePopup.SetActive(true);
                bombs[2].SetActive(true);
                bombsObjects[2].SetActive(false);

                jack.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Impulse);
                jackName.color = Color.red;
            }
        }
    }
}