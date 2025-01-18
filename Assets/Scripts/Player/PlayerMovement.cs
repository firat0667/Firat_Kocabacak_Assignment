using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Handles player movement in a networked environment.
/// </summary>
public class PlayerMovement : NetworkBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f; // Movement speed of the player

    private void OnEnable()
    {
        // Check if the SpawnManager is available and if GetRandomSpawnPoint() returns a valid spawn point
        Transform spawnPoint = Singleton<SpawnManager>.Instance.GetRandomSpawnPoint();
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
        }
        else
        {
            Debug.LogError("Spawn point is invalid.");
        }
    }

    /// <summary>
    /// Unity's Update method, called once per frame.
    /// </summary>
    private void Update()
    {
        if (!IsOwner) return; // Ensure only the owner can control this object

        HandleMovement();
    }

    /// <summary>
    /// Handles player movement based on input.
    /// </summary>
    private void HandleMovement()
    {
        float horizontal = GetHorizontalInput();
        float vertical = GetVerticalInput();

        Vector3 movement = CalculateMovement(horizontal, vertical);
        ApplyMovement(movement);
    }

    /// <summary>
    /// Retrieves horizontal input from the user.
    /// </summary>
    /// <returns>Horizontal input value.</returns>
    private float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// Retrieves vertical input from the user.
    /// </summary>
    /// <returns>Vertical input value.</returns>
    private float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    /// <summary>
    /// Calculates the movement vector based on input and speed.
    /// </summary>
    /// <param name="horizontal">Horizontal input value.</param>
    /// <param name="vertical">Vertical input value.</param>
    /// <returns>Calculated movement vector.</returns>
    private Vector3 CalculateMovement(float horizontal, float vertical)
    {
        return new Vector3(horizontal, 0, vertical) * _speed * Time.deltaTime;
    }

    /// <summary>
    /// Applies the calculated movement to the player's position.
    /// </summary>
    /// <param name="movement">Movement vector to apply.</param>
    private void ApplyMovement(Vector3 movement)
    {
        transform.Translate(movement, Space.World);
    }

    /// <summary>
    /// Sets the player's movement speed.
    /// </summary>
    /// <param name="newSpeed">New movement speed value.</param>
    public void SetSpeed(float newSpeed)
    {
        _speed = Mathf.Max(0, newSpeed); // Ensure speed is not negative
    }

    /// <summary>
    /// Gets the current movement speed.
    /// </summary>
    /// <returns>Current movement speed.</returns>
    public float GetSpeed()
    {
        return _speed;
    }
}
