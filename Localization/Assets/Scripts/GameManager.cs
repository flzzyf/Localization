using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SubjectNerd.Utilities;

public class GameManager : MonoBehaviour
{
    [Reorderable]
    public List<Language> languageList;

    public Text text;

    public void LanguageChanged(int _option)
    {
        LocalizationMgr.instance.ChangeToLanguage(languageList[_option]);
    }

    public void Buttoned()
    {
        text.text = string.Format(LocalizationMgr.instance.GetText("defeat"), "希瓦");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
        }
    }
}