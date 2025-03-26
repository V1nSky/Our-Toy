using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;  // Скорость движения игрока
    private float moveInputX;  // Направление движения по оси X
    private float moveInputY;  // Направление движения по оси Y

    private void Update()
    {
        // Получаем ввод от игрока по горизонтали (влево/вправо) и вертикали (вверх/вниз)
        moveInputX = Input.GetAxis("Horizontal");  // Ввод по оси X (A/D или стрелки влево/вправо)
        moveInputY = Input.GetAxis("Vertical");    // Ввод по оси Y (W/S или стрелки вверх/вниз)

        // Двигаем игрока по обеим осям (X и Y)
        transform.Translate(new Vector3(moveInputX, moveInputY, 0) * moveSpeed * Time.deltaTime);

        // Поворачиваем игрока в зависимости от направления движения по оси X
        if (moveInputX < 0)  // Если игрок двигается влево
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);  // Поворачиваем влево
        }
        else if (moveInputX > 0)  // Если игрок двигается вправо
        {
            transform.localScale = new Vector3(10f, 10f, 10f);  // Поворачиваем вправо
        }
    }
}
