using UnityEngine;

public class PlayerPointsManager : MonoBehaviour
{
    public int PlayerPoints { get; private set; }

    private void Start() => PlayerPoints = 0;

    public void IncreasePlayerPoints()
    {
        PlayerPoints++;
    }
}
