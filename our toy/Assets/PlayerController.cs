using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;  // �������� �������� ������
    private float moveInputX;  // ����������� �������� �� ��� X
    private float moveInputY;  // ����������� �������� �� ��� Y

    private void Update()
    {
        // �������� ���� �� ������ �� ����������� (�����/������) � ��������� (�����/����)
        moveInputX = Input.GetAxis("Horizontal");  // ���� �� ��� X (A/D ��� ������� �����/������)
        moveInputY = Input.GetAxis("Vertical");    // ���� �� ��� Y (W/S ��� ������� �����/����)

        // ������� ������ �� ����� ���� (X � Y)
        transform.Translate(new Vector3(moveInputX, moveInputY, 0) * moveSpeed * Time.deltaTime);

        // ������������ ������ � ����������� �� ����������� �������� �� ��� X
        if (moveInputX < 0)  // ���� ����� ��������� �����
        {
            transform.localScale = new Vector3(-0.3787f, 0.3836f, 1f);  // ������������ �����
        }
        else if (moveInputX > 0)  // ���� ����� ��������� ������
        {
            transform.localScale = new Vector3(0.3787f, 0.3836f, 1f);  // ������������ ������
        }
    }
}
