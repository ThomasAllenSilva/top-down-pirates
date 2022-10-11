using System.Threading.Tasks;
using UnityEngine;

public class PlayerSideTripleShoot : MonoBehaviour
{
    [SerializeField] private Transform[] _playerLeftSideShootSpawnPoints;

    [SerializeField] private Transform[] _playerRightSideShootSpawnPoints;

    [Range(1, 4)] [SerializeField] private int _playerShootDamage;

    [Range(2000, 4000)] [SerializeField] private int _playerShootDelayInMiliSec;

    private PlayerController _playerController;

    private bool _playerCanShoot = true;

    private void Awake() => _playerController = transform.parent.GetComponent<PlayerController>();

    private void Start() => _playerController.PlayerInputs.OnPressedShootButton += ShootTripleBulletsOnBothSides;

    private void ShootTripleBulletsOnBothSides()
    {
        if (_playerCanShoot)
        {
            _playerCanShoot = false;

            ShootTripleBulletsOnLeftSide();
            ShootTripleBulletsOnRightSide();
           
            SetPlayerCanShootToTrue();
        }
    }
    private void ShootTripleBulletsOnLeftSide()
    {
        for (int i = 0; i < _playerLeftSideShootSpawnPoints.Length; i++)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerLeftSideShootSpawnPoints[i].position, _playerLeftSideShootSpawnPoints[i].rotation, _playerShootDamage, gameObject.layer);
        }
    }

    private void ShootTripleBulletsOnRightSide()
    {
        for (int i = 0; i < _playerRightSideShootSpawnPoints.Length; i++)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerRightSideShootSpawnPoints[i].position, _playerRightSideShootSpawnPoints[i].rotation, _playerShootDamage, gameObject.layer);
        }
    }

    private async void SetPlayerCanShootToTrue()
    {
        await Task.Delay(_playerShootDelayInMiliSec);
        _playerCanShoot = true;
    }

    private void OnDestroy()
    {
        if(_playerController != null) _playerController.PlayerInputs.OnPressedShootButton -= ShootTripleBulletsOnBothSides;
    }
}
