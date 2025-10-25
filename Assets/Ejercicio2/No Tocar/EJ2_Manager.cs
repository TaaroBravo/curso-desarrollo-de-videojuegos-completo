using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class EJ2_Manager : MonoBehaviour
{
    public EJ2_Jugador player;
    public EJ2_Enemigo enemy;
    public Transform[] pathFinding;
    public GameObject food;

    public GameObject losePopup;
    public GameObject winPopup;

    public Image playerLifeFeedback;
    public Image enemyLifeFeedback;

    private void Start()
    {
        FirstMove(pathFinding[0].position, pathFinding[1].position);
    }

    private void Update()
    {
        playerLifeFeedback.fillAmount = player.vidaDelJugador / 100;
        enemyLifeFeedback.fillAmount = enemy.vidaDelEnemigo / 100;
    }

    private void FirstMove(Vector3 from, Vector3 to)
    {
        player.GetComponent<Animator>().SetTrigger("walk");

        RxTween.Make(0, 1, 1, Easings.Linear)
            .Do(value =>
            {
                player.transform.position = Vector3.Lerp(from, to, value);
            })
            .DoOnCompleted(() =>
            {
                player.GetComponent<Animator>().SetTrigger("cure");
                Destroy(food);
                player.Curarse();
            })
            .Delay(TimeSpan.FromSeconds(1))
            .DoOnCompleted(() => SecondMove(pathFinding[1].position, pathFinding[2].position))
            .Subscribe()
            .AddTo(this);
    }

    private void SecondMove(Vector3 from, Vector3 to)
    {
        player.GetComponent<Animator>().SetTrigger("walk");

        RxTween.Make(0, 1, 1, Easings.Linear)
            .Do(value =>
            {
                player.transform.position = Vector3.Lerp(from, to, value);
            })
            .DoOnCompleted(FinalCombat)
            .Subscribe()
            .AddTo(this);
    }

    private void FinalCombat()
    {
        enemy.GetComponent<Animator>().SetTrigger("attack");
        player.vidaDelJugador -= 10;
        if (player.vidaDelJugador <= 0)
        {
            losePopup.SetActive(true);
            player.GetComponent<Animator>().SetTrigger("death");
            enemy.GetComponent<Animator>().SetTrigger("idle");
        }
        else
        {
            player.GetComponent<Animator>().SetTrigger("attack");

            enemy.RecibirGolpe();
            if (enemy.vidaDelEnemigo <= 0)
            {
                winPopup.SetActive(true);
                enemy.GetComponent<Animator>().SetTrigger("death");
            }
            else
            {
                Observable.Timer(TimeSpan.FromSeconds(0.5f))
                    .DoOnCompleted(FinalCombat)
                    .Subscribe()
                    .AddTo(this); 
            }
            
        }
    }
}