using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour
{
    public static PauseWindow instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("ResumeBtn").GetComponent<Button_UI>().ClickFunc = () => GameHandler.ResumeGame() ;
        transform.Find("ResumeBtn").GetComponent<Button_UI>().AddButtonSounds();

        transform.Find("MainMenuBtn").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.MainMenu);
        transform.Find("MainMenuBtn").GetComponent<Button_UI>().AddButtonSounds();

        Hide();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    public static void ShowStatic()
    {
        instance.Show();
    }
    public static void HideStatic()
    {
        instance.Hide();
    }

}
