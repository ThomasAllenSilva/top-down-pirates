using System;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    public event Action OnPressedShootButton;

    private const string HorizontalInputAxis = "Horizontal";

    private const string VerticalInputAxis = "Vertical";

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();

        _playerInputActions.Player.FrontalShoot.performed += _ => OnPressedShootButton?.Invoke();
    }

    public float PlayerRotationInputValue()
    {
        return Input.GetAxis(HorizontalInputAxis);
    }

    public float PlayerMovementInputValue()
    {
        return Input.GetAxis(VerticalInputAxis);
    }
}
