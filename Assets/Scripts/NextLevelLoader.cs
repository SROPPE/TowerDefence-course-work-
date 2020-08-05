using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    EnemySpawner enemySpawner;
    static int deadEnemyNumber = 0;
    static int maxEnemy = 0;
  
    private void Start()
    {
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
        maxEnemy = enemySpawner.GetNumberOfEnemy();
    }
    public static void IncreaseDeadEnemyNumber()
    {
        deadEnemyNumber++;
        if (deadEnemyNumber == maxEnemy)
        {
            LoadNextLevel();
        }
    }
    public static void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Scoreboard.Delete();
        if (nextScene < 5)
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene(1);
    }
}
