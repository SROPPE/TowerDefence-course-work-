using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPSystem : MonoBehaviour
{
    [SerializeField] int playerHp = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text HpHandler;
    [SerializeField] AudioClip enemyEnter;
    public int GetHp()
    {
        return playerHp;
    }
    private void Start()
    {
        HpHandler.text = playerHp.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerHp-=healthDecrease;
        GetComponent<AudioSource>().PlayOneShot(enemyEnter);
        HpHandler.text = playerHp.ToString();
        if (playerHp <=0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
