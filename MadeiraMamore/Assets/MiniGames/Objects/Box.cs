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
    
    private GameObject[] package;

    // Start is called before the first frame update
    void Start()
    {
        localPackageColor = new Color[colorLayerScriptable.packageColor.Length];
        localPackageColor = colorLayerScriptable.packageColor;

        localLayerOfPackage = new string[colorLayerScriptable.layerOfPackage.Length];
        localLayerOfPackage = colorLayerScriptable.layerOfPackage;

        package = new GameObject[transform.childCount];
        int[] saveLayerPackege = new int[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            package[i]= transform.GetChild(i).gameObject;
            int decideTypePackage = Random.Range(0,localLayerOfPackage.Length);
            package[i].layer = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            package[i].GetComponent<Renderer>().materials[1].color = localPackageColor[decideTypePackage];
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
    //void teste(){
    //    int decideTypePackage = Random.Range(0,layerOfPackage.Length);
    //    for (int i = 0; i < layerOfPackage.Length; i++)
    //    {
    //        if(decideTypePackage == i){
    //            gameObject.layer = LayerMask.NameToLayer(layerOfPackage[i]);
    //            Debug.Log(LayerMask.LayerToName(gameObject.layer) + LayerMask.NameToLayer(layerOfPackage[i]));
    //       }
    //    }

}

