using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } //static = 1 version of the variable, no copies


    bool _isGameOver = false; //new variable


    private void Awake()
    {
        Instance = this;
    }

    public void GameOver(bool gameOver)
    {
        _isGameOver = gameOver; //private bool
    }

    public bool IsGameOver()
    {
        return _isGameOver; //value, return state of game as bool
    }
}
