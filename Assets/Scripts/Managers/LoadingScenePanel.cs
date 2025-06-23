using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScenePanel : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Text progressText;
    private AsyncOperation operation;
    private int strProgressValue = 0, endProgressValue = 100;

    private void Start()
    {
        StartCoroutine(AsyncLoading(LSM.instance.nextSceneName));
    }

    IEnumerator AsyncLoading(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        yield return operation;
    }

    void Update()
    {
        System.GC.Collect();

        if (strProgressValue < endProgressValue)
        {
            strProgressValue++;
        }
        progressText.text = strProgressValue + "%";
        slider.value = strProgressValue / 100f;

        if (strProgressValue == 100)
        {
            operation.allowSceneActivation = true;
        }
    }
}