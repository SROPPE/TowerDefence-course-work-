using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem endOfPath;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float moveSpeed = 1f;
    PlayerHPSystem playerHp;
    int i = 0;
    Pathfinderr pathfinder;
    List<WayPoint2> path;
    void Start()
    {
        pathfinder = FindObjectOfType<Pathfinderr>();
         path = pathfinder.GetPath();
        playerHp = FindObjectOfType<PlayerHPSystem>();
      
    }       
    private void Update()
    {
        if (!PauseMenu.IsPaused) StartCoroutine(PathFollowing());
    }
    IEnumerator PathFollowing()
    {
        while(i<path.Count)
        {
            
                Vector3 endPos = new Vector3(path[i].transform.position.x, transform.position.y, path[i].transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
                if (transform.position == endPos)
                    i++; 
                yield return new WaitForSeconds(speed);
 
        }      
        RichEnd();
    }
    private void RichEnd()
    {

       var particle = Instantiate(endOfPath,gameObject.transform.position,Quaternion.identity);
       particle.Play();
       Destroy(gameObject);
        i = 0;
        if (playerHp.GetHp() != 0 && GetComponentInChildren<HpSystem>().isLast)
        {
            NextLevelLoader.LoadNextLevel();
        }
    }

}
