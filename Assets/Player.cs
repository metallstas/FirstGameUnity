using UnityEngine;

public class Player : MonoBehaviour
{
    public float xInput;
    private void Update()
    {
        xInput = Input.GetAxis("Horizontal");
    }
}
