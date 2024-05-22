using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    [System.NonSerialized] public CarryMinimage carryMinimageScript;
    [System.NonSerialized] public List<int> saveLayers = new List<int>();
    [System.NonSerialized] public RaffleQuest rafflequestScript;
    private Color[] localPackageColor;
    private string[] localLayerOfPackage;
    
    private GameObject package;
    private GameObject[] packageColor;

    // Start is called before the first frame update
    void Start()
    {
        localPackageColor = new Color[colorLayerScriptable.packageColor.Length];
        localPackageColor = colorLayerScriptable.packageColor;

        localLayerOfPackage = new string[colorLayerScriptable.layerOfPackage.Length];
        localLayerOfPackage = colorLayerScriptable.layerOfPackage;

        packageColor = new GameObject[transform.childCount];
        int[] saveLayerPackege = new int[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            package = transform.GetChild(i).gameObject;
            packageColor[i] = package.transform.GetChild(1).gameObject;
            int decideTypePackage = Random.Range(0,localLayerOfPackage.Length);
            package.layer = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            packageColor[i].GetComponent<Renderer>().materials[1].color = localPackageColor[decideTypePackage];
            //Debug.Log(LayerMask.LayerToName(gameObject.layer) + LayerMask.NameToLayer(layerOfPackage[i])); 
            saveLayerPackege[i] = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
        }
        for(int i = 0; i < saveLayerPackege.Length; i++) {
            for(int e = 0; e < localLayerOfPackage.Length; e++) {
                if(saveLayerPackege[i] == LayerMask.NameToLayer(localLayerOfPackage[e])){
                    if (!saveLayers.Contains(LayerMask.NameToLayer(localLayerOfPackage[e]))){
                        saveLayers.Add(LayerMask.NameToLayer(localLayerOfPackage[e]));
                        //Debug.Log("funcoiunarq " + i + "i numero E" + e + " layer " + LayerMask.NameToLayer(layerOfPackage[e]));
                    }
                }
            }
        }
        carryMinimageScript.GiveLayerGenerated();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            rafflequestScript.CompleteQuest();
            Destroy(gameObject,0.05f);
        }
    }

}

