using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[SerializeField]
public class DialogoJson
{
    public string path = "Madeira-Mamor-\\MadeiraMamore\\Assets\\Dialogo\\ScriptOfHistori";
    public string dada;
    public void teste(){
        dada = File.ReadAllText(path);
    }
}
