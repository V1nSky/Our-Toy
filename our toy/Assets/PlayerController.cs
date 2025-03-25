using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryX = 8f;  // ������� �� ��� X
    public float boundaryY = 4f;  // ������� �� ��� Y

    private void Update()
    {
        // �������� ���� � ������ WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ������� ���������
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // ��������� �������� � ������� ��������� � ������������� �� ��������
        transform.Translate(movement);
    }
}
