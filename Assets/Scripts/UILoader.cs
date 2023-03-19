using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    public string uiSceneName = "UI";

    void Start()
    {
        SceneManager.LoadScene(uiSceneName, LoadSceneMode.Additive);
    }

    void OnDestroy()
    {
        SceneManager.UnloadSceneAsync(uiSceneName);
    }
}
