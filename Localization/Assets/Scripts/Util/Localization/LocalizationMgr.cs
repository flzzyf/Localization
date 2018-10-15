using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language { Chinese_Simplified, Chinese_Traditional, English }

public class LocalizationMgr : Singleton<LocalizationMgr>
{
    public Language language;

    private Dictionary<string, string> dic;

    [HideInInspector]
    public List<LocalizationText> localizationTexts;

    void Start()
    {
        ChangeToLanguage(language);
    }

    public void ChangeToLanguage(Language _language)
    {
        language = _language;
        Init(_language);
        InitAllLocalizationTexts(_language);
    }

    void InitAllLocalizationTexts(Language _language)
    {
        foreach (LocalizationText text in localizationTexts)
        {
            text.Init();
        }
    }

    void Init(Language _language)
    {
        dic = new Dictionary<string, string>();
        TextAsset ta = Resources.Load<TextAsset>(_language.ToString());
        string text = ta.text;

        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            if (line == null)
                continue;

            string[] s = line.Split('=');
            dic.Add(s[0], s[1]);
        }
    }

    public string GetText(string _key)
    {
        if (dic.ContainsKey(_key))
            return dic[_key];

        return null;
    }
}
