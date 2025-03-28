using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // ������ �� ���� GameOver
    public GameObject gameOverMenu;

    // ����, ����� �� ���������� ���� ��������� ���
    private bool isGameOver = false;

    // ����� ��� ��������� ���� GameOver
    public void GameOver()
    {
        if (!isGameOver)
        {
            gameOverMenu.SetActive(true); // ���������� ����
            Time.timeScale = 0f; // ������������� ����
            isGameOver = true; // ���� ��� ��������
        }
    }

    // ����� ��� ����������� ����
    public void RestartGame()
    {
        Time.timeScale = 1f; // ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ��������� ������� ����� ������
    }

    // ����� ��� ������ �� ����
    public void QuitGame()
    {
        Application.Quit(); // ��������� ����
    }
}
