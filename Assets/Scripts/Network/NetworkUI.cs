using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button _hostButton; // Host Game button
    [SerializeField] private Button _joinButton; // Join Game button

    private void Start()
    {
        // Add listeners to the buttons
        _hostButton.onClick.AddListener(()=> { StartHost(); Hide();});
        _joinButton.onClick.AddListener(() => { StartClient(); Hide();});
    }

    /// <summary>
    /// Starts the game as a host.
    /// </summary>
    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    /// <summary>
    /// Joins the game as a client.
    /// </summary>
    private void StartClient()
    {
        NetworkManager.Singleton.StartClient();
    }
    void Hide()
    {
        _hostButton.gameObject.SetActive(false);
        _joinButton.gameObject.SetActive(false);
    }
}
