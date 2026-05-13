using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject winPanel;

    void Start()
    {
        // При запуске показываем меню старта и ОСТАНАВЛИВАЕМ время
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        Time.timeScale = 0f; 
    }

    // Эту функцию мы повесим на кнопку "ИГРАТЬ"
    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f; // Запускаем время
    }

    // Эту функцию будет вызывать финишная черта
    public void ShowWinMenu()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Снова останавливаем время
    }

    // Эту функцию мы повесим на кнопку "ИГРАТЬ СНОВА"
    public void RestartGame()
    {
        Time.timeScale = 1f; // Обязательно возвращаем время перед перезагрузкой!
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}