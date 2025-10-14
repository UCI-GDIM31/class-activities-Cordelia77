using UnityEngine;

public class BallW3 : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    public SpriteRenderer ballRenderer; // must be public for Cat to read color

    [Header("Ball Settings")]
    [SerializeField] private float speedMultiplier = 1.1f;
    [SerializeField] private float brightnessIncrement = 0.1f;

    private void Start()
    {
        // Add random initial velocity
        rb.linearVelocity = new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Increase speed on bounce
        rb.linearVelocity *= speedMultiplier;

        // Brighten if moving fast
        if (rb.linearVelocity.magnitude > 10f)
        {
            Color brighter = ballRenderer.color * (1 + brightnessIncrement);
            brighter.a = 1f; // keep alpha fully visible
            ballRenderer.color = brighter;
        }

        // Hit cat
        CatW3 cat = collision.gameObject.GetComponent<CatW3>();
        if (cat != null)
        {
            cat.HitByBall(this);
        }
    }
}
