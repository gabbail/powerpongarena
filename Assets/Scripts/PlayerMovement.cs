using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2.5f;
    [SerializeField] private bool isPlayer1 = false;

    private Vector2 inputs = Vector2.zero;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isPlayer1)
        {
            float vertical = 0f;
            if (Input.GetKey(KeyCode.W))
            {
                vertical = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                vertical = -1f;
            }
            inputs = new Vector2(0, vertical);
        }
        else
        {
            float vertical = 0f;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                vertical = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                vertical = -1f;
            }
            inputs = new Vector2(0, vertical);
        }
        
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = new Vector3(0, inputs.y * movementSpeed * Time.fixedDeltaTime, 0);
    }
}