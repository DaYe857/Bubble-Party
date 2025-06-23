using UnityEngine;

/// <summary>
/// ���س���������
/// </summary>
public class LSM : MonoBehaviour
{
    public static LSM instance;
    [SerializeField]private GameObject loadingPanel;//���س�������
    public string nextSceneName;//��ת��������

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else{ Destroy(gameObject); }
    }
    /// <summary>
    /// ���س���
    /// </summary>
    /// <param name="sceneName">��������</param>
    public void LoadNextScene(string sceneName)
    {
        Time.timeScale = 1f;
        nextSceneName = sceneName;
        loadingPanel.SetActive(true);
    }
}