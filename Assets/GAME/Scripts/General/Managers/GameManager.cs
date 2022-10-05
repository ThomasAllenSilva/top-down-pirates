using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BulletsObjectPool BulletsObjectPool { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Debug.LogError("Duplicated GameManager, this may cause some bugs");
        }

        BulletsObjectPool = GetComponentInChildren<BulletsObjectPool>();
    }
}
