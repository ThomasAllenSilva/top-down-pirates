using System.Threading.Tasks;
using UnityEngine;

public class PlayerSideTripleShoot : MonoBehaviour
{
    [SerializeField] private Transform[] _playerLeftSidePoints;

    [SerializeField] private Transform[] _playerRightSidePoints;

    private PlayerController _playerController;

    private bool _playerCanShoot = true;
    [Range(1, 4)]
    [SerializeField] private int _playerShootDamage;

    [Range(0, 4000)]
    [SerializeField] private int _playerShootDelayInMiliSec;

    private void Awake() => _playerController = transform.parent.GetComponent<PlayerController>();

    private void Start() => _playerController.PlayerInputs.OnPlayerPressedShootButton += ShootTripleBulletsOnBothSides;

    private void ShootTripleBulletsOnBothSides()
    {
        if (_playerCanShoot)
        {
            ShootTripleBulletsOnLeftSide();
            ShootTripleBulletsOnRightSide();
            _playerCanShoot = false;
            SetPlayerCanShootToTrue();
        }
     
    }

    private async void SetPlayerCanShootToTrue()
    {
        await Task.Delay(_playerShootDelayInMiliSec);
        _playerCanShoot = true;
    }

    private void ShootTripleBulletsOnLeftSide()
    {
        for (int i = 0; i < _playerLeftSidePoints.Length; i++)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerLeftSidePoints[i].position, _playerLeftSidePoints[i].rotation, _playerShootDamage, gameObject.layer);
        }
    }

    private void ShootTripleBulletsOnRightSide()
    {
        for (int i = 0; i < _playerRightSidePoints.Length; i++)
        {
            GameManager.Instance.BulletsObjectPool.SpawnBulletFromPool(_playerRightSidePoints[i].position, _playerRightSidePoints[i].rotation, _playerShootDamage, gameObject.layer);
        }
    }
}
