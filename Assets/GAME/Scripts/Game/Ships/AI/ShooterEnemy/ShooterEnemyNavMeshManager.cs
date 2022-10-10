using System;
using UnityEngine;
using UnityEngine.AI;

public class ShooterEnemyNavMeshManager : NavMeshAgentManager
{
    public event Action OnReachedPositionCloseEnoughToPlayer;

    private bool canInvokePositionCloseToPlayerAction = true;

    public event Action OnIsFarFromPlayerPlayer;

    private bool canInvokeOnIsFarFromPlayerPlayerAction;

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
