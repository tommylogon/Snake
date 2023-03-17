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
        LevelSelect,
        HowToPlay
    }
    // Start is called before the first frame update
    private void Awake()
    {

        transform.Find("HowToPlaySub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("MainSub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("LevelSelectSub").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        transform.Find("MainSub").Find("PlayBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.LevelSelect);
        transform.Find("MainSub").Find("PlayBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("LevelSelectSub").Find("SmallBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.Small);
        transform.Find("LevelSelectSub").Find("SmallBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("LevelSelectSub").Find("MediumBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.Medium);
        transform.Find("LevelSelectSub").Find("MediumBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("MainSub").Find("QuitBtn").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
        transform.Find("MainSub").Find("QuitBtn").GetComponent<Button_UI>().AddButtonSounds();
        
        transform.Find("MainSub").Find("HowToPlayBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.HowToPlay);
        transform.Find("MainSub").Find("HowToPlayBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("HowToPlaySub").Find("BackBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);
        transform.Find("HowToPlaySub").Find("BackBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("LevelSelectSub").Find("BackBtn").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);
        transform.Find("LevelSelectSub").Find("BackBtn").GetComponent<Button_UI>().AddButtonSounds();



        ShowSub(Sub.Main);
    }

    private void ShowSub(Sub sub)
    {
        transform.Find("MainSub").gameObject.SetActive(false);
        transform.Find("HowToPlaySub").gameObject.SetActive(false);
        transform.Find("LevelSelectSub").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
                transform.Find("MainSub").gameObject.SetActive(true);
                break;
            case Sub.HowToPlay:
                transform.Find("HowToPlaySub").gameObject.SetActive(true);
                break;
            case Sub.LevelSelect:
                transform.Find("LevelSelectSub").gameObject.SetActive(true);
                break;
        }
    }
}
