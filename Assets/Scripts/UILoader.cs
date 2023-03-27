using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    [SerializeField]
    private GameObject UIPrefab;
    public GameObject loadedUI;

    
    public void SetUpUI()
    {
        loadedUI = Instantiate(UIPrefab);
    }

}
