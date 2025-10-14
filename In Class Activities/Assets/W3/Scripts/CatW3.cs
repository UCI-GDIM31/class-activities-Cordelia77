using TMPro;
using UnityEngine;

public class CatW3 : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [Header("Movement")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jump = 10f;

    [Header("UI")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _speechText;

    [Header("Cat Settings")]
    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private bool _destroyCatWhenDead = true;

    private bool _facingLeft = false;
    private bool _isGrounded = true;
    private int _points = 0;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
        _healthText.text = "health = " + _health;
        _pointsText.text = "points: " + _points;
        _speechText.text = "ouch";
    }

    private void Update()
    {
        // Move horizontally
        float horizontal = Input.GetAxis("Horizontal");
        _rigidbody.linearVelocity = new Vector2(horizontal * _speed, _rigidbody.linearVelocity.y);

        // Jump
        if (Input.GetAxis("Vertical") > 0 && _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jump);
        }

        // Flip sprite
        if (horizontal < 0 && !_facingLeft)
        {
            _spriteRenderer.flipX = true;
            _facingLeft = true;
        }
        else if (horizontal > 0 && _facingLeft)
        {
            _spriteRenderer.flipX = false;
            _facingLeft = false;
        }

        // Walking animation
        if (_animator != null)
            _animator.SetBool("walking", horizontal != 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            _points++;
            _pointsText.text = "points: " + _points;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground check
        if (collision.gameObject.CompareTag("ground"))
        {
            _isGrounded = true;
        }

        // Ball collision
        BallW3 ball = collision.gameObject.GetComponent<BallW3>();
        if (ball != null)
        {
            HitByBall(ball);
        }
    }

    // -----------------------------
    // Public method for BallW3
    public void HitByBall(BallW3 ball)
    {
        // Change cat color to match ball
        if (ball != null && ball.ballRenderer != null)
        {
            _spriteRenderer.color = ball.ballRenderer.color;
        }

        // Decrease health
        DecreaseHealth();

        // Destroy cat if dead
        if (_health <= 0 && _destroyCatWhenDead == true)
        {
            DestroyCat();
        }
    }

    private void DecreaseHealth()
    {
        _health -= 1;
        _healthText.text = "health = " + _health;
        _speechText.text = GetHealthSpeechText();
    }

    private string GetHealthSpeechText()
    {
        if (_health < _maxHealth / 2)
            return "OH NO!";
        else
            return "ouch";
    }

    private void DestroyCat()
    {
        Destroy(gameObject);
    }
}
