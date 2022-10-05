using UnityEngine;
using System.Threading.Tasks;

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
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerFrontalShootPoint.position, transform.parent.rotation, _playerShootDamage);
            _playerCanShoot = false;
            SetPlayerCanShootToTrue();
        }
    }

    //TODO change this method name
    private async void SetPlayerCanShootToTrue()
    {
        await Task.Delay(_playerShootDelayInMiliSec);
        _playerCanShoot = true;
    }

    private void OnDestroy()
    {
        if (_playerController != null)
        {
            _playerController.PlayerInputs.OnPlayerPressedShootButton -= ShootBullet;
        }
    }
}
