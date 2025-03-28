using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public Transform player;
    public float detectionRadius = 5f;
    public float visionAngle = 90f;
    public float smoothStop = 5f;   // Чем больше, тем быстрее остановка
    public float smoothStart = 2f;  // Чем больше, тем быстрее разгон
    public float stopDistance = 1f;
    public Transform[] patrolPoints;

    private Rigidbody2D rb;
    private int currentPatrolIndex = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        Vector2 desiredVelocity = Vector2.zero;

        Vector2 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;
        Vector2 dirToPlayerNorm = directionToPlayer.normalized;
        float angleToPlayer = Vector2.Angle(transform.right, dirToPlayerNorm);

        // ====== Преследование ======
        if (distanceToPlayer <= detectionRadius && angleToPlayer <= visionAngle / 2f)
        {
            if (distanceToPlayer > stopDistance)
            {
                desiredVelocity = dirToPlayerNorm * moveSpeed;
            }
        }
        else
        {
            // ====== Патруль ======
            if (patrolPoints.Length > 0)
            {
                Transform targetPoint = patrolPoints[currentPatrolIndex];
                Vector2 dirToPoint = (targetPoint.position - transform.position);
                float distanceToPoint = dirToPoint.magnitude;

                if (distanceToPoint < 0.2f) // Достиг точки
                {
                    currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
                }
                else
                {
                    desiredVelocity = dirToPoint.normalized * moveSpeed;
                }
            }
        }

        // ====== Плавное ускорение/замедление ======
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, Time.deltaTime * (desiredVelocity.magnitude > 0.1f ? smoothStart : smoothStop));

        // ====== Поворот ======
        if (rb.linearVelocity.x < -0.1f)
            transform.localScale = new Vector3(-10f, 10f, 1f);
        else if (rb.linearVelocity.x > 0.1f)
            transform.localScale = new Vector3(10f, 10f, 1f);
    }
}


