using UnityEngine;

/// <summary>
/// 加载场景管理器
/// </summary>
public class LSM : MonoBehaviour
{
    public static LSM instance;
    [SerializeField]private GameObject loadingPanel;//加载场景界面
    public string nextSceneName;//跳转场景名称

    private void Awake()
    {
        if(instance == null){ instance = this; }
        else{ Destroy(gameObject); }
    }
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    public void LoadNextScene(string sceneName)
    {
        Time.timeScale = 1f;
        nextSceneName = sceneName;
        loadingPanel.SetActive(true);
    }
}