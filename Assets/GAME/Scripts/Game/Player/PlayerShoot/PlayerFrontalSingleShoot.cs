using System.Threading.Tasks;
using UnityEngine;

public class PlayerFrontalSingleShoot : MonoBehaviour
{
    [SerializeField] private Transform _playerFrontalShootPoint;

    [Range(1, 4)]
    [SerializeField] private int _playerShootDamage;

    [Range(0, 2000)]
    [SerializeField] private int _playerShootDelayInMiliSec;

    private bool _playerCanShoot = true;

    private PlayerController _playerController;

    private void Awake() => _playerController = transform.parent.GetComponent<PlayerController>();

    private void Start() => _playerController.PlayerInputs.OnPlayerPressedShootButton += ShootBullet;
    
    private void ShootBullet()
    {
        if (_playerCanShoot)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerFrontalShootPoint.position, transform.parent.rotation, _playerShootDamage, gameObject.layer);
            _playerCanShoot = false;
            SetPlayerCanShootToTrue();
        }
    }

    private async void SetPlayerCanShootToTrue()
    {
        await Task.Delay(_playerShootDelayInMiliSec);
        _playerCanShoot = true;
    }

    private void OnDisable()
    {
        _playerController.PlayerInputs.OnPlayerPressedShootButton -= ShootBullet;
    }
}
