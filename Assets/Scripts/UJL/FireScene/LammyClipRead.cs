using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class LammyClipRead : MonoBehaviour
{
    //[SerializeField] private TextAsset lammyfile;
    private FileReader fileReader;

    private void Awake()
    {
        fileReader = FindObjectOfType<FileReader>();
    }

    private void Start()
    {
        ReadFromFile();
    }

    void ReadFromFile()
    {
        return;
        //string text = File.ReadAllText(lammyfile.text);
    }
}