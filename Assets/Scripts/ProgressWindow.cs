using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class ProgressWindow : MonoBehaviour
{
    [SerializeField] GameObject ListItemObjectTemplate;
    [SerializeField] GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject newListItem;
        for(int i =0; i < GameHandler.instance.wordsList.Count - 1; i++)
        {
            newListItem = Instantiate(ListItemObjectTemplate, panel.transform);
            WordListItem wordListItem = newListItem.GetComponent<WordListItem>();
            wordListItem.SetWord(GameHandler.instance.wordsList[i]);
            //WordListItem.set

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
