using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    //Variables for the ground tile object and the next spawn point for the ground tile
    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    void Start()
    {
        //Spawns 15 Ground Tiles at start of game
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }

   public void SpawnTile()
    {
        //Spawns the next tile at the chosen spawn point in the tile index
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
