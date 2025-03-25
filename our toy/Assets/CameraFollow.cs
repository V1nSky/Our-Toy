using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // ������ �� ������
    public float smoothing = 5f;    // �������� ���������� ������

    private Vector3 offset;         // �������� ������ �� ������

    void Start()
    {
        // ������������� ��������� �������� ������ (��������, ���������� � ������� �� ��� Z)
        offset = transform.position;
    }

    void Update()
    {
        // ������� ������ ����� ��������� �� �������� ������ � ������ ��������
        Vector3 targetPosition = player.position + offset;

        // ������� �������� ������ � �������� ���������
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
