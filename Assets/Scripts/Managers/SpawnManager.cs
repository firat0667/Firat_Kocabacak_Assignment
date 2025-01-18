using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

   [SerializeField] private List<Transform> _spawnPoints;  // List of spawn points


    /// <summary>
    ///  Method to set spawn points externally
    /// </summary>
    /// <param name="points"></param>
    public void SetSpawnPoints(List<Transform> points)
    {
        _spawnPoints = points;
    }
    /// <summary>
    /// Method to get a random spawn point
    /// </summary>
    /// <returns></returns>
    public Transform GetRandomSpawnPoint()
    {
        // Null or empty check for spawn points
        if (_spawnPoints == null || _spawnPoints.Count == 0)
        {
            Debug.LogError("Spawn points are not set or empty.");
            return null; // Return null if no spawn points are available
        }

        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }
}
