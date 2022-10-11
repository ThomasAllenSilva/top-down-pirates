using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [Range(0f, 300f)] [SerializeField] private float _playerMovementSpeed = 120f;

    private float _playerMovementInputValue;

    private Vector3 _directionPlayerShouldMove;

    private PlayerController _playerController;

    private Rigidbody _playerRigidbody;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() => _playerMovementInputValue = _playerController.PlayerInputs.PlayerMovementInputValue();  
    
    private void FixedUpdate() => MovePlayer();
    
    private void MovePlayer()
    {
        _directionPlayerShouldMove = _playerMovementSpeed * Time.fixedDeltaTime * _playerMovementInputValue * -transform.up;

        _playerRigidbody.velocity = _directionPlayerShouldMove;
    }
}
