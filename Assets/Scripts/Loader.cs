using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{

    public enum Scene
    {
        Small,
        Medium,
        Loading,
        MainMenu

    }

    private static Action loaderCallbakckAction;

    public static void Load(Scene scene)
    {
        loaderCallbakckAction = () => {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString());

        
        
    }
    public static void LoaderCallback()
    {
        if(loaderCallbakckAction != null)
        {
            loaderCallbakckAction();
            loaderCallbakckAction = null;
        }
    }
}
