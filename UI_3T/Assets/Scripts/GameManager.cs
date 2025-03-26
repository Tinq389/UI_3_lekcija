using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
	public Enemy[] enemies; // Array of enemy GameObjects (set in Inspector)
    private int currentEnemyIndex = 0;
	private Image enemyImage;

    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
	[SerializeField] private GameObject gameOverUI; // UI for Game Over screen



    void Start()
    {
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
		ActivateEnemy(0); // Start with the first enemy
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
    }

    public void DoRound()
    {
        //int damage = player.Attack();
        enemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(enemy);

        if (enemy.health <= 0) // Enemy is dead, spawn new one
        {
            RespawnEnemy();
        }
        else
        {
            int enemyDamage = enemy.Attack();
            player.GetHit(enemyDamage);
            enemy.Weapon.ApplyEffect(player);
        }

        UpdateHealth();
    }

	public void RespawnEnemy()
	{
    	currentEnemyIndex++; // Move to the next enemy

    	// If we reach the last enemy, loop back to the first enemy
    	if (currentEnemyIndex >= enemies.Length)
    	{
        	currentEnemyIndex = 0; // Reset index to loop enemies infinitely
    	}

    	ActivateEnemy(currentEnemyIndex);
    	UpdateHealth();
	}

	private void ActivateEnemy(int index)
    {
        if (enemy != null) enemy.gameObject.SetActive(false); // Disable previous enemy

        enemy = enemies[index]; // Set new enemy
        enemy.gameObject.SetActive(true); // Activate new enemy

        // Update the UI with the new enemy's name and sprite
        UpdateEnemyVisual();
    }

    private void UpdateEnemyVisual()
	{
    // Ensure you're using the Enemy class reference to update the UI
    enemyName.text = enemy.name; // Update the enemy name on UI

    if (enemy.EnemyImage != null)
    {
        enemyImage.sprite = enemy.EnemyImage.sprite; // Set the image of the enemy UI Image
    }
    else
    {
        Debug.LogWarning("Enemy image is not assigned!");
    }
	}

    public void GameOver()
    {
        Debug.Log("Game Over! Player has died.");
        gameOverUI.SetActive(true); // Show Game Over UI
    }
}