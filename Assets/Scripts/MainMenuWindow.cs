using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class MainMenuWindow : MonoBehaviour
{
    private enum Sub
    {
        Main,
        HowToPlay
    }
    // Start is called before the first frame update
    private void Awake()
    {

        transform.Find("HowToPlaySub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("MainSub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        transform.Find("MainSub").Find("PlayBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        transform.Find("MainSub").Find("QuitBtn").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
        transform.Find("MainSub").Find("HowToPlayBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.HowToPlay);

        ShowSub(Sub.Main);
    }

    private void ShowSub(Sub sub)
    {
        transform.Find("MainSub").gameObject.SetActive(false);
        transform.Find("HowToPlaySub").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
                transform.Find("MainSub").gameObject.SetActive(true);
                break;
            case Sub.HowToPlay:
                transform.Find("HowToPlaySub").gameObject.SetActive(true);
                break;
        }
    }
}
