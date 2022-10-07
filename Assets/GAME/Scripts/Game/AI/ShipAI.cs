using UnityEngine;
using UnityEngine.AI;

public class ShipAI : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent _shipAI;

    private Vector3 v_diff;
    private float atan2;
    void Start() => _shipAI = GetComponent<NavMeshAgent>();
  

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= 5f)
        {
            transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        _shipAI.SetDestination(target.position);


    }
}
