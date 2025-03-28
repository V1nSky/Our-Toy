using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactionRange = 1f;  // ���������� ��� ��������������
    private bool isInRange = false;      // ���� ��� �������� ���������� � ���� ��������������
    private GameObject player;           // �����
    private SpriteRenderer spriteRenderer; // ��� ��������� ������� �����

    public GameObject interactionPanel;  // ������ ��� ��������������

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������� �������
    }

    private void Update()
    {
        if (isInRange)
        {
            interactionPanel.SetActive(true);  // ���������� ������
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenDoor(); // ������� ����� (������� � ���������)
                interactionPanel.SetActive(false); // ������ ������ ����� ��������������
            }
        }
        else
        {
            interactionPanel.SetActive(false); // ������ ������, ���� ����� �� � �������
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���� ����� ������ � ����
        {
            player = other.gameObject;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ���� ����� �������� ����
        {
            isInRange = false;
        }
    }

    private void OpenDoor()
    {
        // ��������� ������ ����� (��� ������� �)
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // ������ ������ ���������
        }
        else
        {
            Destroy(gameObject); // ���� ���������� ������, ���� �� �����
        }
    }
}
