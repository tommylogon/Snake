using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameAssets;

public class LanguageSelector : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    //public TextMeshProUGUI text;
    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { DropdownSelected(dropdown); });
        PopulateDropdown();

        dropdown.value = (int)instance.selectedLanguage;
    }
    public void DropdownSelected(TMP_Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0: instance.selectedLanguage = Language.English;break;
            case 1: instance.selectedLanguage = Language.Japanese;break;
            case 2: instance.selectedLanguage = Language.Thai;break;
            case 3: instance.selectedLanguage = Language.Norwegian;break;
        }

        instance.SelectLanguage((Language)dropdown.value);
    }
    public void PopulateDropdown()
    {
       // text.text = instance.selectedLanguage.ToString();
        dropdown.ClearOptions();
        List<string> languageList = new List<string>();
        foreach(Language language in Enum.GetValues(typeof(Language))) 
        { 
            languageList.Add(language.ToString());
        }
        dropdown.AddOptions(languageList);
    }



}
