using UnityEngine;

public class PongBallController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 12f; 
    [SerializeField] private PongGameManager gameManager;

    private Rigidbody2D rb;
    private float currentSpeed;
    private Vector2 lastVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.linearVelocity;
    }

    private void LaunchBall()
    {
        currentSpeed = speed;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * currentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftGoal"))
        {
            gameManager.EnemyScores();
            ResetBall();
        }
        else if (other.CompareTag("RightGoal"))
        {
            gameManager.PlayerScores();
            ResetBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isWall = collision.gameObject.CompareTag("Wall");
        bool isPaddle = collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy");

        if (!isWall && !isPaddle) return;

        if (isPaddle) {
             currentSpeed *= 1.10f; 
             currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
             Debug.Log("CurrentSpeed atual: " + currentSpeed); /*TESTE*/
        }
           Vector2 normal = collision.contacts[0].normal;
           Vector2 reflected = Vector2.Reflect(lastVelocity, normal).normalized;

        if (Mathf.Abs(reflected.x) < 0.3f)
        {
            reflected.x = reflected.x >= 0 ? 0.3f : -0.3f;
            reflected = reflected.normalized;
        }

        if (Mathf.Abs(reflected.y) < 0.3f)
        {
            reflected.y = reflected.y >= 0 ? 0.3f : -0.3f;
            reflected = reflected.normalized;
        }

        rb.linearVelocity = reflected * currentSpeed;
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
        LaunchBall();
    }
}