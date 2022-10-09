using System;
using UnityEngine;
using UnityEngine.AI;

public class ShipNavMeshManager : MonoBehaviour
{
    [SerializeField] private Transform _targetToFollow;

    private NavMeshAgent _shipAI;

    public event Action OnReachedPositionCloseEnoughToPlayer;

    private bool canInvokePositionCloseToPlayerAction = true;

    public event Action OnIsFarFromPlayerPlayer;

    private bool canInvokeOnIsFarFromPlayerPlayerAction;

    void Start() => _shipAI = GetComponent<NavMeshAgent>();
  
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
