using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealthBar;

 /*   private void Start()
    {
        totalHealth.fillAmount = playerHealth.currentHealth / 10;

    }
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
        //it will fill the amount of heart depend on the number input
    }*/
}
