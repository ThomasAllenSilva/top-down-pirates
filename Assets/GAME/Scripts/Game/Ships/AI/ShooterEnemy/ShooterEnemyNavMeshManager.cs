using System;
using UnityEngine;

public class ShooterEnemyNavMeshManager : NavMeshAgentManager
{
    public event Action OnReachedPositionCloseEnoughToPlayer;

    private bool canInvokePositionCloseEnoughToPlayerAction = true;

    public event Action OnIsFarFromPlayerPlayer;

    private bool canInvokeOnIsFarFromPlayerPlayerAction;

    private float distanceBetweenThisShipAndTarget;

    private void Update()
    {
        distanceBetweenThisShipAndTarget = Vector3.Distance(transform.position, _targetToFollow.position);

        if (CheckIfThisShipIsCloseEnoughToPlayer())
        {
            InvokePositionCloseEnoughToPlayerAction();
        }

        else
        {
            _shipAI.SetDestination(_targetToFollow.position);
            InvokeFarFromPlayerAction();
        }
    }

    private bool CheckIfThisShipIsCloseEnoughToPlayer()
    {
        return distanceBetweenThisShipAndTarget <= 7f;
    }

    private void InvokePositionCloseEnoughToPlayerAction()
    {
        if (canInvokePositionCloseEnoughToPlayerAction)
        {
            OnReachedPositionCloseEnoughToPlayer?.Invoke();

            canInvokePositionCloseEnoughToPlayerAction = false;
        }

        canInvokeOnIsFarFromPlayerPlayerAction = true;

        RotateThisShipToLookAtPlayer();
    }

    private void RotateThisShipToLookAtPlayer()
    {
        transform.LookAt(_targetToFollow);
    }

    private void InvokeFarFromPlayerAction()
    {
        if (canInvokeOnIsFarFromPlayerPlayerAction)
        {
            OnIsFarFromPlayerPlayer?.Invoke();

            canInvokeOnIsFarFromPlayerPlayerAction = false;

            canInvokePositionCloseEnoughToPlayerAction = true;
        }
    }
}
