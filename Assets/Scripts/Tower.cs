using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float shootingDistance;
    [SerializeField] List<GameObject> bullets;
    [SerializeField] public TowerPlacement towerPlace;
    Transform targetEnemy;
    [Obsolete]
    void Update()
    {
        SetTargetEnemy();
        objectToPan.LookAt(targetEnemy);
        FireEnemy();

    }
    private void SetTargetEnemy()
    {
        if (targetEnemy == null)
        {
            var enemies = FindObjectsOfType<EnemyMovement>();
            if (enemies.Length == 0) { return; }

            var closestEnemy = enemies[0];
            foreach (var enemy in enemies)
            {
                if (Mathf.Abs(Vector3.Distance(enemy.transform.position, gameObject.transform.position))
                    < Mathf.Abs(Vector3.Distance(closestEnemy.transform.position, gameObject.transform.position)))
                    closestEnemy = enemy;
            }
            targetEnemy = closestEnemy.transform;
        }
    }

    private void FireEnemy()
    {
        if (TargetInAtackRange())
            Shoot(true);
        else
            Shoot(false);
    }

    private void Shoot(bool isActive)
    {
        foreach (var bullet in bullets)
        {
            var towerGun = bullet.GetComponent<ParticleSystem>().emission;
            towerGun.enabled = isActive;
        }
    }

    bool TargetInAtackRange()
    {
        if(targetEnemy == null)
            return false;
        var distanceBetween = Mathf.Abs(Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position));
        if (shootingDistance - distanceBetween >= Mathf.Epsilon)
            return true;
        targetEnemy = null;
        return false;
    }
}
