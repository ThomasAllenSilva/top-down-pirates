using UnityEngine;

public class PlayerSideTripleShoot : MonoBehaviour
{
    [SerializeField] private Transform[] _playerLeftSidePoints;

    [SerializeField] private Transform[] _playerRightSidePoints;

    private PlayerController _playerController;

    private void Awake() => _playerController = transform.parent.GetComponent<PlayerController>();

    private void Start() => _playerController.PlayerInputs.OnPlayerPressedShootButton += ShootTripleBulletsOnBothSides;

    private void ShootTripleBulletsOnBothSides()
    {
        ShootTripleBulletsOnLeftSide();
        ShootTripleBulletsOnRightSide();
    }

    private void ShootTripleBulletsOnLeftSide()
    {
        Debug.Log("shooting-left");
    }

    private void ShootTripleBulletsOnRightSide()
    {
        Debug.Log("shooting-right");
    }
}
