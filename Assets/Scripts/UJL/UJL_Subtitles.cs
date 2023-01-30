using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UJL_Subtitles : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int CurrentText;

    private static void thing()
    {
        var map = new Dictionary<double, string>();
        map.Add(12.000, "Let's get on, Let's get on");
    }
}
