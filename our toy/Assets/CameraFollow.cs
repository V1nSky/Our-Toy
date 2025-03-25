using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Ссылка на игрока
    public float smoothing = 5f;    // Скорость следования камеры

    private Vector3 offset;         // Смещение камеры от игрока

    void Start()
    {
        // Устанавливаем начальное смещение камеры (например, отодвигаем её немного по оси Z)
        offset = transform.position;
    }

    void Update()
    {
        // Позиция камеры будет следовать за позицией игрока с учетом смещения
        Vector3 targetPosition = player.position + offset;

        // Плавное движение камеры с заданной скоростью
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
