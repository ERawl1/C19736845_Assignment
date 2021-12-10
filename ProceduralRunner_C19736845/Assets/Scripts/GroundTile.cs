using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawn groundSpawner;

    
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawn>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        //When exiting collider it calls the SpawnTile function and destroys the exited game object after 3 seconds to save memory
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 6);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject pickupPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 3;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(pickupPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = Random.Range(2, 8);
       
        return point;
        
    }

}
