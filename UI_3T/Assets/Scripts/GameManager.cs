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
   [SerializeField] private GameObject gameOverUI;
   [SerializeField] private Button restartButton; 
   [SerializeField] private GameObject[] uiElementsToDisable;

   void Start()
   {
       playerName.text = player.CharName;
       ActivateEnemy(0);
       UpdateHealth();
       restartButton.gameObject.SetActive(false);
       restartButton.onClick.AddListener(RestartGame); // listener for restart button
   }

   private void UpdateHealth()
   {
       playerHealth.text = player.health.ToString();
       enemyHealth.text = enemy.health.ToString();
   }

   public void DoRound()
   {
       enemy.GetHit(player.Weapon.GetDamage());
       player.Weapon.ApplyEffect(enemy);
       
       if (enemy.health <= 0)
       {
           RespawnEnemy();
       }
       else
       {
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
       currentEnemyIndex++;

       if (currentEnemyIndex >= enemies.Length)
       {
           Debug.Log("All enemies defeated! Showing Game Over screen.");
           GameOver();
       }
       else
       {
           ActivateEnemy(currentEnemyIndex);
       }

       UpdateHealth();
   }

   private void ActivateEnemy(int index)
   {
       if (enemy != null)
       {
           enemy.gameObject.SetActive(false);
           if (enemy.EnemyImage != null)
           {
               enemy.EnemyImage.gameObject.SetActive(false);
           }
       }

       enemy = enemies[index]; // set new enemy
       enemy.gameObject.SetActive(true);
       UpdateEnemyVisual();
   }

   private void UpdateEnemyVisual()
   {
       enemyName.text = enemy.name; 
       
       if (enemy.EnemyImage != null)
           enemy.EnemyImage.gameObject.SetActive(true);
   }

   public void GameOver()
   {
       Debug.Log("Game Over! Player has died.");
       gameOverUI.SetActive(true);
       restartButton.gameObject.SetActive(true);

       // disable unecessary UI elements
       foreach (GameObject uiElement in uiElementsToDisable)
       {
           uiElement.SetActive(false);
       }
   }
   public void RestartGame()
   {
       Debug.Log("Restarting Game...");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
}
