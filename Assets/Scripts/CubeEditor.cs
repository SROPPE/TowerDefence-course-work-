using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint2))]
public class CubeEditor : MonoBehaviour
{
  
    WayPoint2 wayPoint;
    private void Start()
    {
       var colliderCheck =gameObject.GetComponent<BoxCollider>();
        colliderCheck.size = new Vector3(10, 10, 10);
        colliderCheck.center = new Vector3(0,5,0);
       if(colliderCheck ==null)
        {
          var collider =  gameObject.AddComponent<BoxCollider>();
            collider.isTrigger = true;
        }
    }
    private void Awake()
    {
        wayPoint = GetComponent<WayPoint2>();
    }
    void Update()
    {
        SnapToGrid();
        LabelChange();
    }

    private void LabelChange()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = $"{wayPoint.GetGridPos().x},{wayPoint.GetGridPos().y}";
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void SnapToGrid()
    {
       
       int  gridSize = wayPoint.GetGridRange();
        transform.position = new Vector3(
            wayPoint.GetGridPos().x * gridSize,
            0f,
            wayPoint.GetGridPos().y * gridSize
            );
    }
}
