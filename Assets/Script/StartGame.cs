using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
  

    public void ClickToLv1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Awak11e()
    {
        Debug.Log("Null Object");
    }
}
