using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button backToMainButton;

    [SerializeField]
    private GameObject loadingScenePanel;

    private void Awake()
    {
        continueButton.onClick.AddListener(() => 
        {
            EventHandler.ResumeGame();
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            GameTimer.Instance.ResumeTimer();
        });

        restartButton.onClick.AddListener(() => { 
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
        });
        backToMainButton.onClick.AddListener(() => {
            LSM.instance.nextSceneName = "Main";
            loadingScenePanel.SetActive(true); 
        });
    }

    private void OnEnable()
    {
        EventHandler.PauseGame();
        Time.timeScale = 0f;
        GameTimer.Instance.PauseTimer();
    }
}
