using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{

    public GameObject GameOverPanel;

    public static Action GameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameOver += OnGameOver;
    }

    private void OnDestroy()
    {
        GameOver -= OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
