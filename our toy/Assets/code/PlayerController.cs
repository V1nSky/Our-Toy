using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7f;

    private float moveInputX;
    private float moveInputY;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Sprite frontSprite;  // Спрайт спереди
    public Sprite backSprite;   // Спрайт сзади
    public Sprite sideSprite;   // Спрайт сбоку
    public Sprite diagonalBackRightSprite;  // Спрайт вверх-вправо (спина + бок)
    public Sprite diagonalBackLeftSprite;   // Спрайт вверх-влево (спина + бок)
    public Sprite diagonalFrontRightSprite; // Спрайт вниз-вправо (лицо + бок)
    public Sprite diagonalFrontLeftSprite;  // Спрайт вниз-влево (лицо + бок)
    public Sprite deadSprite; // Спрайт умер

    private bool isDead = false; // Флаг смерти

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster") && !isDead)
        {
            Die(); // Если столкновение с монстром — умираем
        }
    }

    private void Die()
    {
        isDead = true;  // Устанавливаем флаг смерти
        spriteRenderer.sprite = deadSprite;  // Меняем спрайт на мертвого

        // Останавливаем движение
        rb.linearVelocity = Vector2.zero;  // Останавливаем движение
        rb.isKinematic = true;  // Блокируем физику, чтобы персонаж не двигался

        // Отключаем только обработку движения
        this.GetComponent<PlayerController>().enabled = false;

        // Логируем смерть
        Debug.Log("Player has fallen and died.");
    }



    private void Update()
    {
        if (isDead) return; // Если игрок мертв, не обрабатываем движение

        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        // Обрабатываем диагональное движение
        if (moveInputX > 0 && moveInputY > 0)
        {
            spriteRenderer.sprite = diagonalBackRightSprite; // Вверх-вправо (спина + бок)
        }
        else if (moveInputX < 0 && moveInputY > 0)
        {
            spriteRenderer.sprite = diagonalBackLeftSprite; // Вверх-влево (спина + бок)
        }
        else if (moveInputX > 0 && moveInputY < 0)
        {
            spriteRenderer.sprite = diagonalFrontRightSprite; // Вниз-вправо (лицо + бок)
        }
        else if (moveInputX < 0 && moveInputY < 0)
        {
            spriteRenderer.sprite = diagonalFrontLeftSprite; // Вниз-влево (лицо + бок)
        }
        else if (moveInputY > 0)
        {
            spriteRenderer.sprite = backSprite; // Если идем вверх
        }
        else if (moveInputY < 0)
        {
            spriteRenderer.sprite = frontSprite; // Если идем вниз
        }
        else
        {
            spriteRenderer.sprite = sideSprite; // Боковой спрайт
        }

        // Разворачиваем персонажа только если он смотрит вбок
        if (spriteRenderer.sprite == sideSprite || spriteRenderer.sprite == frontSprite || spriteRenderer.sprite == backSprite)
        {
            if (moveInputX < 0)
            {
                transform.localScale = new Vector3(-10f, 10f, 10f);  // Левый поворот
            }
            else if (moveInputX > 0)
            {
                transform.localScale = new Vector3(10f, 10f, 10f);   // Правый поворот
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return; // Если игрок мертв, не обрабатываем движение

        // Применяем движение
        rb.linearVelocity = new Vector2(moveInputX, moveInputY).normalized * moveSpeed;
    }
}
