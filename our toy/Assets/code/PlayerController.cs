using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;  // �������� �������� ������
    private float moveInputX;
    private float moveInputY;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    private void Update()
    {
        // �������� ���� �� ������
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        // ������������ ������ � ����������� �� ����������� ��������
        if (moveInputX < 0)
        {
            transform.localScale = new Vector3(-10f, 10f, 10f);
        }
        else if (moveInputX > 0)
        {
            transform.localScale = new Vector3(10f, 10f, 10f);
        }
    }

    private void FixedUpdate()
    {
        // ������� ��������� ����� Rigidbody2D, � �� transform!
        rb.linearVelocity = new Vector2(moveInputX, moveInputY).normalized * moveSpeed;

        // ���� �������� ����� �������, ������������� ���������
        if (rb.linearVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
