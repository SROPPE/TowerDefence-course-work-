using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollector : MonoBehaviour
{

    ParticleSystem currentParticle;
    private void Start()
    {
        currentParticle = gameObject.GetComponent<ParticleSystem>();
    }
    void Update()
    {
       if(currentParticle.isPlaying)
       {
             
       }
       else
       {
          Destroy(gameObject,2f);
       }
    }
  
}
