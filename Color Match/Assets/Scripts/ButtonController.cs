using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonController : MonoBehaviour
{
    public static Action OnDisableInput;
    public static Action OnEnableInput;
    public void PauseButton(GameObject pauseButton)
    {
        OnDisableInput?.Invoke();
        Time.timeScale = 0;
        pauseButton.SetActive(true);
    }
    public void ReturnToLevelButton(GameObject pauseButton)
    {
        OnEnableInput?.Invoke();
        Time.timeScale = 1;
        pauseButton.SetActive(false);
    }
}
