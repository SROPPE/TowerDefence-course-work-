using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
  
  
    private void OnMouseDown()
    {
        PutNewTower();
    }

    private void PutNewTower()
    {
        var placable = GetComponent<WayPoint2>().isPlaceable;
        if (placable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
    }
}
