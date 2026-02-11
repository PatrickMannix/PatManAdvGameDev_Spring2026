using UnityEngine;

public class PUJump : PowerUp
{
    protected override void ApplyEffect()
    {
        base.ApplyEffect();
        Debug.Log("Jump Effect");
    }
}
