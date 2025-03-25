using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed = 3f;               // �������� �������
    public Transform player;                   // ������ �� ��������� ������

    // ������� ������ ��� �������
    public float boundaryX = 8f;
    public float boundaryY = 4f;

    private void Update()
    {
        if (player == null) return; // ���� ��� ������, ������ �� ������

        // 1. ������������ ����������� �� ������� � ������
        Vector3 directionToPlayer = player.position - transform.position;

        // 2. ����������� ��� ����������� (����� �������� ���� ����������)
        directionToPlayer.Normalize();

        // 3. ���������� ������� � ������� ������
        transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
    }
}
