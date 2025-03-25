using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 1.5f;               // Скорость монстра
    public Transform player;                   // Ссылка на трансформ игрока

    // Границы экрана для монстра
    public float boundaryX = 8f;
    public float boundaryY = 4f;

    private void Update()
    {
        if (player == null) return; // Если нет игрока, ничего не делаем

        // Проверяем, находится ли игрок слева или справа от монстра
        if (player.position.x < transform.position.x)  // Игрок слева
        {
            // Поворачиваем монстра налево
            transform.localScale = new Vector3(-1f, 1f, 1f);  // Изменяем масштаб по X на -1 для зеркального отражения
        }
        else  // Игрок справа
        {
            // Поворачиваем монстра направо
            transform.localScale = new Vector3(1f, 1f, 1f);  // Восстанавливаем нормальный масштаб
        }

        // 1. Рассчитываем направление от монстра к игроку
        Vector3 directionToPlayer = player.position - transform.position;

        // 2. Нормализуем это направление (чтобы скорость была постоянной)
        directionToPlayer.Normalize();

        // 3. Перемещаем монстра в сторону игрока
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);


    }
}
