using UnityEngine;

public class PUHealth : PowerUp
{
    protected override void ApplyEffect()
    {
        base.ApplyEffect();
        Debug.Log("Health Effect");
    }
}
