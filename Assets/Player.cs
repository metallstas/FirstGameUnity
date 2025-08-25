using UnityEngine;

public class Player : Entity
{
    private float xInput;

    protected override void Update()
    {
        HandleMovment(xInput);
    }
}
