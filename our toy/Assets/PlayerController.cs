using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryX = 8f;  // Граница по оси X
    public float boundaryY = 4f;  // Граница по оси Y

    private void Update()
    {
        // Получаем ввод с клавиш WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Двигаем персонажа
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Применяем движение к позиции персонажа с ограничениями по границам
        transform.Translate(movement);
    }
}
