using UnityEngine;
using UnityEngine.AI;

public class ChaserEnemyNavMeshAgentManager : MonoBehaviour
{
    private static Transform _targetToFollow;

    private NavMeshAgent _shipAI;

    private void Awake() => _shipAI = GetComponent<NavMeshAgent>();

    private void Start() => _targetToFollow = FindObjectOfType<PlayerController>().gameObject.transform;

    void Update() => _shipAI.SetDestination(_targetToFollow.position);
}
