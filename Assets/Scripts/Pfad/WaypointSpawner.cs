using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;   // Spawnpunkte im Inspector setzen
    public GameObject waypointPrefab;     // Dein Waypoint Prefab

    private GameObject currentWaypoint;
    private int lastIndex = -1;

    void Start()
    {
        SpawnNextWaypoint();
    }

    public void SpawnNextWaypoint()
    {
        if (currentWaypoint != null)
        {
            Destroy(currentWaypoint);
        }

        int randomIndex;

        // verhindert gleiche Position zweimal hintereinander
        do
        {
            randomIndex = Random.Range(0, spawnPoints.Count);
        }
        while (randomIndex == lastIndex && spawnPoints.Count > 1);

        lastIndex = randomIndex;

        Transform spawnPoint = spawnPoints[randomIndex];

        currentWaypoint = Instantiate(
            waypointPrefab,
            spawnPoint.position,
            Quaternion.identity
        );
    }
}