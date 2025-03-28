using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public Transform player;
    public float detectionRadius = 5f;
    public float visionAngle = 90f;
    public float smoothStop = 5f;         // Чем больше, тем быстрее остановка
    public float smoothStart = 2f;             // Чем больше, тем быстрее разгон
    public float stopDistance = 1f;

    private Rigidbody2D rb;
    private Vector2 desiredVelocity = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (player == null) return;

        Vector2 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;

        // Угол между взглядом монстра и игроком
        Vector2 dirToPlayerNorm = directionToPlayer.normalized;
        float angleToPlayer = Vector2.Angle(transform.right, dirToPlayerNorm);

        Vector2 desiredVelocity = Vector2.zero;

        if (distance <= detectionRadius && angleToPlayer <= visionAngle / 2f)
        {
            if (distance > stopDistance)
            {
                desiredVelocity = dirToPlayerNorm * moveSpeed;
            }
        }

        // Плавное разгон и замедление
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, Time.deltaTime * smoothStart);
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, desiredVelocity, Time.deltaTime * smoothStop);

        // Определяем в какую сторону смотрит монстр
        if (player.position.x < transform.position.x)
            transform.localScale = new Vector3(-10f, 10f, 1f); // Поворачиваем налево
        else
            transform.localScale = new Vector3(10f, 10f, 1f);  // Поворачиваем направо
    }


    // Проверка на столкновение с игроком
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
      //  if (collision.gameObject.CompareTag("Player"))
        //{
            // Действие при столкновении с игроком (например, смерть)
          //  Destroy(collision.gameObject);  // Уничтожаем игрока
            //Debug.Log("Player is dead!");
        //}
    //}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Vector3 leftDir = Quaternion.Euler(0, 0, -visionAngle / 2) * Vector2.right;
        Vector3 rightDir = Quaternion.Euler(0, 0, visionAngle / 2) * Vector2.right;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftDir * detectionRadius);
        Gizmos.DrawLine(transform.position, transform.position + rightDir * detectionRadius);
    }
}
