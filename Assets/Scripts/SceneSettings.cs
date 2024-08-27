using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSettings : MonoBehaviour
{
    public GameObject PausePanel, Inventory, tapEffect;
    public int level;

    void Start()
    {
        PausePanel.SetActive(false);  // Панель паузы выключена при старте игры
    }

    void Update()
    {
        // Проверка нажатия клавиши Escape или нажатия мыши
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButtonPressed();
        }
    }

    public void PauseButtonPressed()
    {
        // Переключаем состояние панели паузы
        PausePanel.SetActive(!PausePanel.activeSelf);

        if (PausePanel.activeSelf)
        {
            Time.timeScale = 0f; // Ставим игру на паузу
        }
        else
        {
            Time.timeScale = 1f; // Продолжаем игру
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(level);
    }

    public void ContinueButtonPressed()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}
