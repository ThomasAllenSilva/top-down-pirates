using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentManager : MonoBehaviour
{
    protected static Transform _targetToFollow;

    protected NavMeshAgent _shipAI;

    private void Start()
    {
        if (_targetToFollow == null)
        {
            _targetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;
        }
    }

    private void Awake() => _shipAI = GetComponent<NavMeshAgent>();
}
