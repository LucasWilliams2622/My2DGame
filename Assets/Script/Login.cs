using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Login : MonoBehaviour
{
    public TMP_InputField edtUsername, edtPassword;
    public GameObject panelLogin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      



    }
    public void checkLogin()
    {
        var username = edtUsername.text;
        var password = edtPassword.text;

        //call API
        if (username.Equals("Lucas") && password.Equals("abc123"))
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
