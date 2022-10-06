using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInputs))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D PlayerRigidbody;

    public PlayerInputs PlayerInputs { get; private set; }

    private void Awake()
    {
        PlayerInputs = GetComponent<PlayerInputs>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }

    public void MovePlayerToDirection(Vector2 directionToMove)
    {
        PlayerRigidbody.velocity = directionToMove;
    }
}
