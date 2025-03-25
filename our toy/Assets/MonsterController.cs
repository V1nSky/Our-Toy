using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 1.5f;               // �������� �������
    public Transform player;                   // ������ �� ��������� ������

    // ������� ������ ��� �������
    public float boundaryX = 8f;
    public float boundaryY = 4f;

    private void Update()
    {
        if (player == null) return; // ���� ��� ������, ������ �� ������

        // ���������, ��������� �� ����� ����� ��� ������ �� �������
        if (player.position.x < transform.position.x)  // ����� �����
        {
            // ������������ ������� ������
            transform.localScale = new Vector3(-1f, 1f, 1f);  // �������� ������� �� X �� -1 ��� ����������� ���������
        }
        else  // ����� ������
        {
            // ������������ ������� �������
            transform.localScale = new Vector3(1f, 1f, 1f);  // ��������������� ���������� �������
        }

        // 1. ������������ ����������� �� ������� � ������
        Vector3 directionToPlayer = player.position - transform.position;

        // 2. ����������� ��� ����������� (����� �������� ���� ����������)
        directionToPlayer.Normalize();

        // 3. ���������� ������� � ������� ������
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);


    }
}
