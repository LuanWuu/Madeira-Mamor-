using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public string[] layerOfPackage;
    [SerializeField] private Color[] packageColor;
    [System.NonSerialized] public CarryMinimage carryMinimageScript;
    [System.NonSerialized] public List<int> saveLayers = new List<int>();
    
    private GameObject[] package;

    // Start is called before the first frame update
    void Start()
    {
        package = new GameObject[transform.childCount];
        int[] saveLayerPackege = new int[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            package[i]= transform.GetChild(i).gameObject;
            int decideTypePackage = Random.Range(0,layerOfPackage.Length);
            package[i].layer = LayerMask.NameToLayer(layerOfPackage[decideTypePackage]);
            package[i].GetComponent<Renderer>().materials[1].color = packageColor[decideTypePackage];
            //Debug.Log(LayerMask.LayerToName(gameObject.layer) + LayerMask.NameToLayer(layerOfPackage[i])); 
            saveLayerPackege[i] = LayerMask.NameToLayer(layerOfPackage[decideTypePackage]);
        }
        for(int i = 0; i < saveLayerPackege.Length; i++) {
            for(int e = 0; e < layerOfPackage.Length; e++) {
                if(saveLayerPackege[i] == LayerMask.NameToLayer(layerOfPackage[e])){
                    if (!saveLayers.Contains(LayerMask.NameToLayer(layerOfPackage[e]))){
                        saveLayers.Add(LayerMask.NameToLayer(layerOfPackage[e]));
                        Debug.Log("funcoiunarq " + i + "i numero E" + e + " layer " + LayerMask.NameToLayer(layerOfPackage[e]));
                    }
                }
            }
        }
        carryMinimageScript.GiveLayerGenerated();
    }
    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown("l")){
        //    teste();
        //}
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

