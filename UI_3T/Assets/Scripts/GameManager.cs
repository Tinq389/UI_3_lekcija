using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public Player player;
   public Enemy[] enemies;
   private int currentEnemyIndex = 0;
   private Enemy enemy;
   [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth;
   [SerializeField] private GameObject gameOverUI; // Game Over UI to enable when player dies
   [SerializeField] private Button restartButton; // Restart button to restart the scene
   [SerializeField] private GameObject[] uiElementsToDisable; // 5 UI GameObjects to disable

   void Start()
   {
       playerName.text = player.CharName;
       ActivateEnemy(0);
       UpdateHealth();

       // Ensure restart button is initially disabled
       restartButton.gameObject.SetActive(false);
       restartButton.onClick.AddListener(RestartGame); // Set listener for restart button
   }

   private void UpdateHealth()
   {
       playerHealth.text = player.health.ToString();
       enemyHealth.text = enemy.health.ToString();
   }

   public void DoRound()
   {
       enemy.GetHit(player.Weapon);
       player.Weapon.ApplyEffect(enemy);

       // Check if enemy is dead
       if (enemy.health <= 0)
       {
           RespawnEnemy();
       }
       else
       {
           // Enemy attacks player
           int enemyDamage = enemy.Attack();
           player.GetHit(enemyDamage);
           enemy.Weapon.ApplyEffect(player);
       }

       if (player.health <= 0)
       {
           GameOver();
       }

       UpdateHealth();
   }

   public void RespawnEnemy()
   {
       currentEnemyIndex++; // Move to the next enemy

       if (currentEnemyIndex >= enemies.Length)
       {
           Debug.Log("All enemies defeated! Showing Game Over screen.");
           GameOver(); // End game when all enemies are defeated
       }
       else
       {
           ActivateEnemy(currentEnemyIndex); // Activate the next enemy
       }

       UpdateHealth();
   }

   private void ActivateEnemy(int index)
   {
       if (enemy != null)
       {
           enemy.gameObject.SetActive(false); // Disable previous enemy
           if (enemy.EnemyImage != null)
           {
               enemy.EnemyImage.gameObject.SetActive(false); // Hide previous enemy's image
           }
       }

       enemy = enemies[index]; // Set new enemy
       enemy.gameObject.SetActive(true); // Activate new enemy

       // Update the UI with the new enemy's name and image
       UpdateEnemyVisual();
   }

   private void UpdateEnemyVisual()
   {
       enemyName.text = enemy.name; // Update the enemy name on UI

       // Display the enemy's image if it's assigned
       if (enemy.EnemyImage != null)
           enemy.EnemyImage.gameObject.SetActive(true);
   }

   public void GameOver()
   {
       Debug.Log("Game Over! Player has died.");
       gameOverUI.SetActive(true); // Show the Game Over screen
       restartButton.gameObject.SetActive(true); // Show the restart button

       // Disable the 5 UI elements that were assigned in the Inspector
       foreach (GameObject uiElement in uiElementsToDisable)
       {
           uiElement.SetActive(false); // Disable each UI GameObject
       }
   }

   public void RestartGame()
   {
       Debug.Log("Restarting Game...");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
   }
}
