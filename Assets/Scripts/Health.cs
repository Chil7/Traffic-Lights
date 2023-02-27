using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Range(0f, 100f)]
    public float health;

    private float currenthealth;

    public Image bar;

    public Text healthText;


    private void Start()
    {
        EventManager.loseHealthEvent += Hurt;

        currenthealth = health / 100;
        bar.fillAmount = currenthealth;
        healthText.text = "Current Health " + health;
    }

    private void Update()
    {
        currenthealth = health / 100;
        bar.fillAmount = currenthealth;
        healthText.text = "Current Health " + health;
    }

    public void Hurt(float _amount)
    {
        if (health - _amount > 0)
        {
            health -= _amount;
        }
        else
        {
            health = 0;
        }
    }
}
