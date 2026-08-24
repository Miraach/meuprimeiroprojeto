using UnityEngine;
using UnityEngine.InputSystem;

public class PongPlayerPaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float limiteY = 4f;

    private Vector2 moveInput;

   public void OnMove(InputValue value) {
     moveInput = value.Get<Vector2>();
   }

    private void Start() {
        GetComponent<SpriteRenderer>().color = GameData.PlayerColor;
    }

    private void Update()
    {
        float moveY = moveInput.y;

        Vector3 pos = transform.position;
        pos.y += moveY * speed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, -limiteY, limiteY);

        transform.position = pos;
    }
}