using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSystem : MonoBehaviour
{
    [SerializeField] int hpValue = 0;
    [SerializeField] GameObject DeathFX;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] int enemyScoreCost;
    [SerializeField] AudioClip getDamage;
    public Healthbar healthbar;
    bool isDead = false;
    public bool isLast = false;
    private void OnParticleCollision(GameObject other)
    {
        if (!isDead)
        {
            EnemyGetDamage(other);
            if (hpValue <= 0) isDead = true;
            HitHandler(other);
        }
    }
    public int GetHpValue()
    {
        return hpValue;
    }
    private void HitHandler(GameObject other)
    {
    
        if (hpValue > 0)
        {
            hitParticles.Play();
            var damageAudio = GetComponent<AudioSource>();
            if (damageAudio) damageAudio.PlayOneShot(getDamage);
            HealthBarProcess();
        }
        else
        {
          
            PlayDeathScence();   
        }

    }

    private void EnemyGetDamage(GameObject other)
    {
        var damageValue = other.GetComponent<BulletDamage>().GetDamageValue();
        hpValue -= damageValue;
    }

    void HealthBarProcess()
    {
        healthbar.SetHealth(hpValue);
    }
    private void PlayDeathScence()
    {
        if(isLast)
        {
            NextLevelLoader.LoadNextLevel();
        }
        Instantiate(DeathFX, gameObject.transform.position,Quaternion.identity);
        Scoreboard.AddScore(enemyScoreCost);
        Destroy(gameObject);
    }

}
