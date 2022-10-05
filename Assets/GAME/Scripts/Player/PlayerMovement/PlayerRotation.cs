using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Range(0f, 120f)]
    [SerializeField] private float _playerRotationSpeed = 60f;

    private float _playerRotationInputValue;

    private float _desiredPlayerRotation;

    private PlayerController _playerController;

    private void Awake() => _playerController = GetComponent<PlayerController>();

    private void Update()
    {
        _playerRotationInputValue = _playerController.PlayerInputs.GetPlayerRotationValue();

        RotateShip();
    }

    private void RotateShip()
    {
        _desiredPlayerRotation += -1 * _playerRotationInputValue * _playerRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, 0f, _desiredPlayerRotation);
    }
}
