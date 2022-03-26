using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStarter : MonoBehaviour
{
    public UnityEvent OnGameStart;
    private void Start()
    {
        RestartGame();
    }
    public void RestartGame()
    {
        Debug.Log("Restart Game");
        OnGameStart?.Invoke();
    }
}
