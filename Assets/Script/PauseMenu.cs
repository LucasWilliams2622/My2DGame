using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gameObject;
    public static bool isPaused = false;

    // Start is called before the first frame update
    /*void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;

    }
    public void GoToMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Start_Scene");
    }
    public void QuitGame()
    {
        Application.Quit();



    }
    public void Play()
    {
        Application.Quit();
    }*/
}
