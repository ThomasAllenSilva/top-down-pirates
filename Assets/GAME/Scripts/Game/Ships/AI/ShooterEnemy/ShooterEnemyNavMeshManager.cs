using System;
using UnityEngine;
using UnityEngine.AI;

public class ShooterEnemyNavMeshManager : MonoBehaviour
{
    private static Transform _targetToFollow;

    private NavMeshAgent _shipAI;

    public event Action OnReachedPositionCloseEnoughToPlayer;

    private bool canInvokePositionCloseToPlayerAction = true;

    public event Action OnIsFarFromPlayerPlayer;

    private bool canInvokeOnIsFarFromPlayerPlayerAction;

    private void Awake() => _shipAI = GetComponent<NavMeshAgent>();

    private void Start()
    {
        _targetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;
    }
  
    private void Update()
    {
        float distanceBetweenThisShipAndTarget = Vector3.Distance(transform.position, _targetToFollow.position);

        if (distanceBetweenThisShipAndTarget <= 7f)
        {
            if (canInvokePositionCloseToPlayerAction)
            {
                OnReachedPositionCloseEnoughToPlayer?.Invoke();
                canInvokePositionCloseToPlayerAction = false;
            }
            canInvokeOnIsFarFromPlayerPlayerAction = true;
            transform.LookAt(_targetToFollow);
        }

        else
        {
            _shipAI.SetDestination(_targetToFollow.position);

            if (canInvokeOnIsFarFromPlayerPlayerAction)
            {
                OnIsFarFromPlayerPlayer?.Invoke();
                canInvokeOnIsFarFromPlayerPlayerAction = false;
                canInvokePositionCloseToPlayerAction = true;
            }
        }
    }
}
