using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
 [SerializeField] List<SpawnTowerInfo> towerSpawnList;
 [System.Serializable]
    private class SpawnTowerInfo
    {
       public TowerIndex index;
       public int limitOfTowers;
       public Tower towerPrefab;
       public Queue<Tower> towerRingBuffer = new Queue<Tower>();
    }
    [SerializeField] Transform towerParent;
    public void AddTower(TowerPlacement towerPlacement)
    {
        if (!PauseMenu.IsPaused)
        {
            var buffTower = towerSpawnList.Find(towerSlot => towerSlot.index == TowerPanel.towerNumber);
            if (buffTower.towerRingBuffer.Count < buffTower.limitOfTowers)
            {
                TowerAdd(towerPlacement, buffTower);
            }
            else
            {
                TowerMove(towerPlacement, buffTower);
            }
        }
    }
    private void TowerAdd(TowerPlacement towerPlacement,SpawnTowerInfo spawnInfo)
    {
        var tower = Instantiate(spawnInfo.towerPrefab, towerPlacement.transform.position, Quaternion.identity);
        tower.transform.parent = towerParent;
        spawnInfo.towerRingBuffer.Enqueue(tower);
        tower.towerPlace = towerPlacement;
        towerPlacement.gameObject.GetComponent<WayPoint2>().isPlaceable = false;
    }
    private void TowerMove(TowerPlacement towerPlacement, SpawnTowerInfo spawnInfo)
    {   
        var oldestTower = spawnInfo.towerRingBuffer.Dequeue();
        oldestTower.towerPlace.gameObject.GetComponent<WayPoint2>().isPlaceable = true;
        oldestTower.towerPlace = towerPlacement;
        towerPlacement.gameObject.GetComponent<WayPoint2>().isPlaceable = false;
        oldestTower.transform.position = towerPlacement.transform.position;
        spawnInfo.towerRingBuffer.Enqueue(oldestTower);
    }

 
}
