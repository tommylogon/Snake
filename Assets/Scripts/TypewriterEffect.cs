using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameAssets;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    public Language language;
    private string currentText = "";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void StartTextWriter()
    {
        fullText = language.ToString() + "\r\n" + fullText;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshPro>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
