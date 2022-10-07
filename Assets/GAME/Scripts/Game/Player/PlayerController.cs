using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody PlayerRigidbody;

    public PlayerInputs PlayerInputs { get; private set; }

    private void Awake()
    {
        PlayerInputs = GetComponent<PlayerInputs>();
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayerToDirection(Vector3 directionToMove)
    {
        PlayerRigidbody.velocity = new Vector3(directionToMove.x, 0f, directionToMove.z);
    }
}
