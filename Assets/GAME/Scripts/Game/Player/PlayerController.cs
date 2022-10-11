using UnityEngine;
using System;
using System.Threading.Tasks;

[RequireComponent(typeof(PlayerInputs))]

public class PlayerController : MonoBehaviour
{
    public PlayerInputs PlayerInputs { get; private set; }

    public static event Action OnPlayerDied;

    private void Awake() => PlayerInputs = GetComponent<PlayerInputs>();

    private async void OnDisable()
    {
        await Task.Delay(1000);
        OnPlayerDied?.Invoke();
    }
}
