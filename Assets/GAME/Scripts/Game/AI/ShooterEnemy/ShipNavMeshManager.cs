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
        float distance = Vector3.Distance(transform.position, _targetToFollow.position);

        if (distance < 7f)
        {
            transform.LookAt(_targetToFollow);

            if (canInvokePositionCloseToPlayerAction)
            {
                OnReachedPositionCloseEnoughToPlayer?.Invoke();
                canInvokePositionCloseToPlayerAction = false;
            }
            canInvokeOnIsFarFromPlayerPlayerAction = true;
        }

        else
        {
            _shipAI.speed = 1f;
         
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
