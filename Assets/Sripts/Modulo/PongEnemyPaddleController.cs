using UnityEngine;

public class PongEnemyPaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 250f;
    [SerializeField] private Transform ball;
    [SerializeField] private float limiteY = 4f;
    [SerializeField] private float wallHeight = 20f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

    float targetY = ball.position.y;
    float currentY = transform.position.y;
    float newY = Mathf.Lerp(currentY, targetY, 0.05f);
    //float newY = Mathf.MoveTowards(currentY, targetY, speed * Time.fixedDeltaTime);

    Vector3 pos = transform.position;
    pos.y = Mathf.Clamp(pos.y - (currentY - newY), -limiteY, limiteY);
    transform.position = pos;
    }
}