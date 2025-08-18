using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;

    private float redColorDuration = 0.2f;

    public float timer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ChangeColor();
    }

    public void TakeDamage()
    {
        sr.color = Color.red;
        timer = redColorDuration;
    }

    private void ChangeColor()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && sr.color != Color.white)
            sr.color = Color.white;
    }
}
