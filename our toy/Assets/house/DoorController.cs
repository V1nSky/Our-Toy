using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactionRange = 1f;  // Расстояние для взаимодействия
    private bool isInRange = false;      // Флаг для проверки нахождения в зоне взаимодействия
    private GameObject player;           // Игрок
    private SpriteRenderer spriteRenderer; // Для изменения спрайта двери

    public GameObject interactionPanel;  // Панель для взаимодействия

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Получаем компонент спрайта
    }

    private void Update()
    {
        if (isInRange)
        {
            interactionPanel.SetActive(true);  // Показываем панель
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenDoor(); // Открыть дверь (сделать её невидимой)
                interactionPanel.SetActive(false); // Скрыть панель после взаимодействия
            }
        }
        else
        {
            interactionPanel.SetActive(false); // Скрыть панель, если игрок не в радиусе
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Если игрок входит в зону
        {
            player = other.gameObject;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Если игрок покидает зону
        {
            isInRange = false;
        }
    }

    private void OpenDoor()
    {
        // Пропадаем спрайт двери (или удаляем её)
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false; // Делает спрайт невидимым
        }
        else
        {
            Destroy(gameObject); // Либо уничтожаем объект, если не нужен
        }
    }
}
