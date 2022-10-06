using System;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    public event Action OnPlayerPressedShootButton;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();

        _playerInputActions.Player.FrontalShoot.performed += _ => OnPlayerPressedShootButton?.Invoke();
    }

    public float GetPlayerRotationValue()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetPlayerMovementValue()
    {
        return Input.GetAxis("Vertical");
    }
}
