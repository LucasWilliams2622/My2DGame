using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public TMP_InputField edtUsername, edtPassword;
    public GameObject panelLogin;
    void Start()
    {
        
    }

  
    void Update()
    {

    }
    public void checkLogin()
    {
        var username = edtUsername.text;
        var password = edtPassword.text;
        //call API
        if (username.Equals("Lucas@gmail.com") && password.Equals("abc123"))
        {
            panelLogin.SetActive(false);
            Debug.Log("Login Success");

        }
        else
        {
            Debug.Log("Login Failed");
        }
    }
}
