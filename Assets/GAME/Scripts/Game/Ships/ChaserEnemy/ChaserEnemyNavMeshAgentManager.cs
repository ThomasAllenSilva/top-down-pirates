public class ChaserEnemyNavMeshAgentManager : NavMeshAgentManager
{
    private void Update() => _shipAI.SetDestination(_targetToFollow.position);
}
