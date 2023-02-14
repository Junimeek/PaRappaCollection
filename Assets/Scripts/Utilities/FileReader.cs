using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileReader : MonoBehaviour
{
    public static void ReadVoicesAsset(TextAsset Text, Dictionary<string, string> OutputDictionary, bool LogLines = true) {
        var Lines = ReadTextAsset(Text);
        var dataSeparators = new char[] {':', ','};
        for (int i = 0; i < Lines.Length; i++) {
            if(LogLines)
                Debug.Log(Lines[i]);

            string[] line = Lines[i].Split(dataSeparators);
            string voiceSampleID = line[0];
            string voiceSampleStart = line[1];
            string voiceSampleLength = line[2];
            OutputDictionary.Add(voiceSampleID, voiceSampleStart);
        }
    }

    public static string[] ReadTextAsset(TextAsset Text) {
        string[] Lines = Text.text.Split(System.Environment.NewLine, System.StringSplitOptions.RemoveEmptyEntries);
        return Lines;
    }
}
