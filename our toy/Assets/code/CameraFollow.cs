using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // ������ �� ������
    public float smoothing = 5f;    // �������� ���������� ������

    private Vector3 offset;         // �������� ������ �� ������

    void Start()
    {
        if (player != null)  // �������� �� null � ������
        {
            offset = transform.position - player.position;
        }
    }

    void Update()
    {
        if (player != null)  // ��������, ��� ����� ����������
        {
            // ������� ������ ����� ��������� �� �������� ������ � ������ ��������
            Vector3 targetPosition = player.position + offset;

            // ������� �������� ������ � �������� ���������
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Player object is destroyed, camera can't follow.");
        }
    }
}
