public class ChaserEnemyNavMeshAgentManager : NavMeshAgentManager
{
    private void Update() => _shipAI.SetDestination(_targetToFollow.position);

    public void SetShipMovementSpeed(float speed)
    {
        _shipAI.speed = speed;
    }
}
