using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
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

            Invoke("CompleteLevel1", 7f);

        }
    }

    private void CompleteLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
