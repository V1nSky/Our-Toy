using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f;               // Скорость монстра
    public Transform player;                   // Ссылка на трансформ игрока

    // Границы экрана для монстра
    public float boundaryX = 8f;
    public float boundaryY = 4f;

    private void Update()
    {
        if (player == null) return; // Если нет игрока, ничего не делаем

        // 1. Рассчитываем направление от монстра к игроку
        Vector3 directionToPlayer = player.position - transform.position;

        // 2. Нормализуем это направление (чтобы скорость была постоянной)
        directionToPlayer.Normalize();

        // 3. Перемещаем монстра в сторону игрока
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
    }
}
