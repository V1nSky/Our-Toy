using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 1.5f;               // Скорость монстра
    public Transform player;                     // Ссылка на трансформ игрока
    private Rigidbody2D rb;                      // Rigidbody2D монстра

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    private void Update()
    {
        if (player == null) return; // Если нет игрока, ничего не делаем

        // Проверяем, находится ли игрок слева или справа от монстра
        if (player.position.x < transform.position.x)  // Игрок слева
        {
            // Поворачиваем монстра налево, но изменяем только масштаб по оси X
            transform.localScale = new Vector3(-10f, 10f, 1f);  // Отражение по X
        }
        else  // Игрок справа
        {
            // Поворачиваем монстра направо
            transform.localScale = new Vector3(10f, 10f, 1f);  // Нормальный масштаб
        }

        // Рассчитываем направление от монстра к игроку
        Vector3 directionToPlayer = player.position - transform.position;

        // Нормализуем это направление (чтобы скорость была постоянной)
        directionToPlayer.Normalize();

        // Перемещаем монстра с помощью Rigidbody2D
        rb.linearVelocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }
}
