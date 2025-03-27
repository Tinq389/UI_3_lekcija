using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    [SerializeField] private Image enemyImage;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] protected int aggression = 5;

    public Image EnemyImage
    {
        get { return enemyImage; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public override int Attack()
    {
        return 10; // Example attack value
    }

    public virtual void Die()
    {
        Debug.Log(name + " has been defeated.");
        if (GetComponent<Enemy>()?.EnemyImage != null)
        {
            GetComponent<Enemy>().EnemyImage.gameObject.SetActive(false); // Hide enemy image
        }
        gameObject.SetActive(false); // Disable enemy object
    }

}