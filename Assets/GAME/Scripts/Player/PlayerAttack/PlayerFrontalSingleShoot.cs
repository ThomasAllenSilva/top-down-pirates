using UnityEngine;

public class PlayerFrontalSingleShoot : MonoBehaviour
{
    [SerializeField] private Transform _playerFrontalShootPoint;

    private PlayerController _playerController;

    private void Awake() => _playerController = transform.parent.GetComponent<PlayerController>();

    private void Start() => _playerController.PlayerInputs.OnPlayerPressedShootButton += ShootBullet;
    
    private void ShootBullet()
    {
        Debug.Log("frontal-shoot");
    }

    private void OnDestroy()
    {
        if (_playerController != null)
        {
            _playerController.PlayerInputs.OnPlayerPressedShootButton -= ShootBullet;
        }
    }
}
