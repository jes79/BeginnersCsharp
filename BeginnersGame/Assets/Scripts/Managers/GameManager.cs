using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ItemManager itemManager;
    public GameObject Cover;

    int score;
    public Text ScoreText;

    void Start()
    {
        EventManager.EnemyDieEvent += OnEnemyDie;
    }

    public void OnClickStartButton()
    {
        Cover.SetActive(false);
        spawnManager.SpawnRandom();
        itemManager.SpawnRandom();
    }

    public void OnEnemyDie()
    {
        score++;
        ScoreText.text = String.Format("Score : {0}", score);
    }
}