using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinderr : MonoBehaviour
{
    [SerializeField] WayPoint2 startPoint, endPoint;
    Dictionary<Vector2Int, WayPoint2> grid = new Dictionary<Vector2Int, WayPoint2>();
    Queue<WayPoint2> pathFined = new Queue<WayPoint2>();

    WayPoint2 currentWayPoint;

    [SerializeField] List<WayPoint2> path = new List<WayPoint2>();
    [SerializeField] GameObject groundLocker;

    bool PathFinded = false;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };
    public List<WayPoint2> GetPath()
    {
        if (path.Count > 0)
            return path;
        LoadBlocks();
        BreadthFirstSearch();
        return path;
    }
    private void BreadthFirstSearch()
    {
        pathFined.Enqueue(startPoint);
        while (!PathFinded && pathFined.Count > 0)
        {
            currentWayPoint = pathFined.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            currentWayPoint.isExplore = true;
        }
        if (PathFinded)
        {
            CreatePath();
        }
    }
    private void CreatePath()
    {
        var currentPathPoint = endPoint.searchFrom;
        SetAsPath(endPoint);
        while (currentPathPoint != startPoint)
        {
            SetAsPath(currentPathPoint);
            currentPathPoint = currentPathPoint.searchFrom;
        }
        SetAsPath(startPoint);

        path.Reverse();
 
    } 
    private void SetAsPath(WayPoint2 wayPoint)
    {
        wayPoint.isPlaceable = false;
        Instantiate(groundLocker,wayPoint.gameObject.transform);
        path.Add(wayPoint);
    }
    private void HaltIfEndFound()
    {
        
        if (currentWayPoint == endPoint)
        {
            PathFinded = true;
        }

    }

    private void ExploreNeighbours()
    {
        if (PathFinded) return;
        foreach (var direction in directions)
        {
            Vector2Int neighbourCoordinates = currentWayPoint.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                PathfinedAdd(neighbourCoordinates);
            }
        }
    }

    private void PathfinedAdd(Vector2Int neighbourCoordinates)
    {

        var neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplore || pathFined.Contains(neighbour))
        {

        }
        else
        {
            pathFined.Enqueue(neighbour);
            neighbour.searchFrom = currentWayPoint;
        }
    }

    private void LoadBlocks()
    {
        var gridBlocks = FindObjectsOfType<WayPoint2>();
        foreach (var gridBlock in gridBlocks)
        {
            if (!grid.ContainsKey(gridBlock.GetGridPos()))
            {
                grid.Add(gridBlock.GetGridPos(), gridBlock);
            }
        }
    }
}
