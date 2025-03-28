using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Ссылка на меню GameOver
    public GameObject gameOverMenu;

    // Флаг, чтобы не показывать меню несколько раз
    private bool isGameOver = false;

    // Метод для активации меню GameOver
    public void GameOver()
    {
        if (!isGameOver)
        {
            gameOverMenu.SetActive(true); // Активируем меню
            Time.timeScale = 0f; // Останавливаем игру
            isGameOver = true; // Меню уже показано
        }
    }

    // Метод для перезапуска игры
    public void RestartGame()
    {
        Time.timeScale = 1f; // Снимаем паузу
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Загружаем текущую сцену заново
    }

    // Метод для выхода из игры
    public void QuitGame()
    {
        Application.Quit(); // Закрывает игру
    }
}
