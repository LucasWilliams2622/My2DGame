using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private AudioSource finishScene;
    private void Start()
    {
        ItemCollector itemCollector = GetComponent<ItemCollector>();    
    }
    void Update()
    {
        finishScene = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Complete");
            finishScene.Play();
            Invoke("CompleteLevel1", 4f);
        }
    }
    private void CompleteLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
