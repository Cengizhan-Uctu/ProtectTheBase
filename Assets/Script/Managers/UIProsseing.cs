using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIProsseing : SingeltonGeneric<UIProsseing>
{
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject StartBtn;
    [SerializeField] GameObject ReplayBtn;
    [SerializeField] GameObject NextLevelBtn;
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += GameOverUI;
        GameManager.Instance.OnWin += WinUI;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= GameOverUI;
        GameManager.Instance.OnWin -= WinUI;
    }
    private void Start()
    {
        StartUI();
    }
    void GameOverUI()
    {
        GameCanvas.SetActive(true);
        Time.timeScale = 0;
        StartBtn.SetActive(false);
        ReplayBtn.SetActive(true);
        NextLevelBtn.SetActive(false);
    }
    void WinUI()
    {
        GameCanvas.SetActive(true);
        Time.timeScale = 0;
        StartBtn.SetActive(false);
        ReplayBtn.SetActive(false);
        NextLevelBtn.SetActive(true);
    }
    void StartUI()
    {
        GameCanvas.SetActive(true);
        Time.timeScale = 0;
        StartBtn.SetActive(true);
        ReplayBtn.SetActive(false);
        NextLevelBtn.SetActive(false);
    }
    public void RePBtnlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void NexLevelBtnAction()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameObject.SetActive(false);
        }
        else
        {
            RePBtnlay();
        }
    }
    public void StartBtnAction()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}