using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject panal;
    public static bool isGameOver;
    public GameObject panalLeaderBoard;
    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {

    }

    public void GameMenu()
    {
        Time.timeScale = 0;
        Debug.Log("Menu Open");
        panal.SetActive(true);
    }
    public void ResumeGame()    
    {
        Time.timeScale = 1f;
        panal.SetActive(false);
    }
    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Start_Scene");
    }
    public void OpenLeaderBoard()
    {
        panalLeaderBoard.SetActive(true);
    }
}
