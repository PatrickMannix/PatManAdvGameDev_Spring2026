using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected SpriteRenderer sr;
    public Color powerUpColor;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = powerUpColor;
    }

    protected virtual void ApplyEffect()
    {
        Debug.Log("Need to apply effects");
    }
}
