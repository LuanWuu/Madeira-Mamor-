using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Color", menuName = "Color")]
public class ColorsAndLayers: ScriptableObject
{
    public  Color[] packageColor;
    public string[] layerOfPackage;
    public int amoutPackage;
    public List<int> packageLayer = new List<int>();
}
