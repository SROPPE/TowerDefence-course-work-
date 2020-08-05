using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint2 : MonoBehaviour
{
    [SerializeField] public WayPoint2 searchFrom;
    public bool isExplore = false;
    public bool isPlaceable = true;

    const int GridRange = 10;


    public int GetGridRange()
    {
        return GridRange;
    }
    
    public Vector2Int GetGridPos()
    {
       return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / GridRange), 
            Mathf.RoundToInt(transform.position.z / GridRange) 
            );
        
    }
 
    void Update()
    {
        
    }
}
