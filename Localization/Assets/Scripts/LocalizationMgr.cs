using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language { Chinese, English }

public class LocalizationMgr : Singleton<LocalizationMgr>
{
    public Language language = Language.Chinese;

    private Dictionary<string, string> dic = new Dictionary<string, string>();

    void Start()
    {
        Init();
    }


    void Init()
    {
        TextAsset ta = Resources.Load<TextAsset>(language.ToString());
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
