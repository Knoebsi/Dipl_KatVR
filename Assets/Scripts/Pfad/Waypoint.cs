using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<WaypointSpawner>().SpawnNextWaypoint();
            Destroy(gameObject);
        }
    }
}