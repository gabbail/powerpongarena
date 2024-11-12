using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    private float initialMovementSpeed = 8f;
    private float maxMovementSpeed = 16;
    private float movementSpeedIncreaseFactor = 1.07f;
    private bool speedRushActivated = true;
    private Rigidbody2D ballRigidbody;
    private Vector2 direction;
    private float currentMovementSpeed;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            if (speedRushActivated)
                IncreaseBallSpeed();
        }
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.gameStarted)
        {
            direction = ballRigidbody.velocity.normalized;
            ballRigidbody.velocity = new Vector2(direction.x * currentMovementSpeed, direction.y * currentMovementSpeed);   
        }
    }

    private void IncreaseBallSpeed()
    {
        currentMovementSpeed = Mathf.Min(currentMovementSpeed * movementSpeedIncreaseFactor, maxMovementSpeed);
    }

    public void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? 1: -1;
        float y = Random.Range(0, 2) == 0 ? 1: -1;
        direction = new Vector2(x,y);
        ballRigidbody.velocity = new Vector2(x * initialMovementSpeed, y * initialMovementSpeed);
        currentMovementSpeed = initialMovementSpeed;
    }

    public void Reset()
    {
        transform.position = Vector3.zero;
        direction = Vector2.zero;
        ballRigidbody.velocity = Vector2.zero;
    }

    internal void SetClassicMode()
    {
        speedRushActivated = false;
    }

    internal void SetSpeedRushMode()
    {
        speedRushActivated = true;
    }
}