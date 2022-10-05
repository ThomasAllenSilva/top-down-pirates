using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class PlayerMovement : MonoBehaviour
{
    [Range(0f, 300f)]
    [SerializeField] private float _playerMovementSpeed = 120f;

    private float _playerMovementInputValue;

    private Vector2 _directionPlayerShouldMove;

    private PlayerController _playerController;

    private void Awake() => _playerController = GetComponent<PlayerController>();

    private void Update() => _playerMovementInputValue = _playerController.PlayerInputs.GetPlayerMovementValue();  
    
    private void FixedUpdate() => MovePlayer();
    
    private void MovePlayer()
    {
        _directionPlayerShouldMove = _playerMovementSpeed * Time.fixedDeltaTime * _playerMovementInputValue * -transform.up;

        _playerController.MovePlayerToDirection(_directionPlayerShouldMove);
    }
}
