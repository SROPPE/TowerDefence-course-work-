using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int numberOfEnemy = 0;
    [SerializeField] float spawnRate = 0f;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform enemyParent;
    [SerializeField] AudioClip enemySpawn;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {
     
    }
    public int GetNumberOfEnemy()
    {
        return numberOfEnemy;
    }
    private IEnumerator EnemySpawn()
    {
        for (int i = 0; i < numberOfEnemy;)
        {
            var currentEnemy = Instantiate(enemy);
            GetComponent<AudioSource>().PlayOneShot(enemySpawn);
            SetMaxHpValue(currentEnemy);
            currentEnemy.transform.parent = enemyParent;
            if (i + 1 == numberOfEnemy)
                currentEnemy.GetComponentInChildren<HpSystem>().isLast = true;
                i++;
            yield return new WaitForSeconds(spawnRate);
        }

    }

    private void SetMaxHpValue(GameObject currentEnemy)
    {
        var hpSystem  = currentEnemy.GetComponentInChildren<HpSystem>();
        hpSystem.healthbar.SetMaxHealth(hpSystem.GetHpValue());
    }
}
