using UnityEngine;


[RequireComponent(typeof(PlayerInputs))]

public class PlayerController : MonoBehaviour
{
    public PlayerInputs PlayerInputs { get; private set; }

    private void Awake() => PlayerInputs = GetComponent<PlayerInputs>();
}
