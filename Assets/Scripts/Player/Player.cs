using UnityEngine;

public class Player : AbstractPlayer
{
    /// <summary>
    /// Method to initialize player-specific data
    /// </summary>
    public override void InitializePlayer()
    {
        playerName = "Player" + Random.Range(1, 1000).ToString();
        health = 100;  // Default health
    }
    /// <summary>
    /// Method to spawn the player at a specific point
    /// </summary>
    /// <param name="spawnPoint"></param>
    public override void SpawnAtPoint(Transform spawnPoint)
    {
        transform.position = spawnPoint.position;  // Set position to spawn point
        transform.rotation = spawnPoint.rotation;  // Set rotation to spawn point
    }
}