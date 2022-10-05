using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public float GetPlayerRotationValue()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetPlayerMovementValue()
    {
        return Input.GetAxis("Vertical");
    }
}
