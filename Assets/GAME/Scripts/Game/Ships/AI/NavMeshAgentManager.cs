using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavMeshAgentManager : MonoBehaviour
{
    protected static Transform _targetToFollow;

    protected NavMeshAgent _shipAI;

    private void Awake() => _shipAI = GetComponent<NavMeshAgent>();

    private void Start()
    {
        if (_targetToFollow == null)
        {
            _targetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;
        }
    }
}
