using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CharacterDataManager : MonoBehaviour
{
    public List<List<string>> _character_datas { get; set; } = new List<List<string>>();
    private TextAsset csv = default;

    private int line = default;

    private void Awake()
    {
        csv = Resources.Load<TextAsset>("Game - ƒV[ƒg1");
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string data = reader.ReadLine();
            if (line != 0)
            {
                List<string> lineDatas = new List<string>(data.Split(","));
                _character_datas.Add(lineDatas);
            }
            line++;
        }
    }
}
