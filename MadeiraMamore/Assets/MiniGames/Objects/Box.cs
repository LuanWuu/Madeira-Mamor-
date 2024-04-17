using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public string[] layerOfPackage;
    [SerializeField] private Color[] packageColor;
    [System.NonSerialized] public int[] saveLayers;
    [System.NonSerialized] public CarryMinimage carryMinimageScript;
    
    private GameObject[] package;

    // Start is called before the first frame update
    void Start()
    {
        package = new GameObject[transform.childCount];
         saveLayers = new int[1];
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
        int e = 0;
        for(int i = 0; i < saveLayerPackege.Length; i++) {
            if(saveLayerPackege[i] == LayerMask.NameToLayer(layerOfPackage[e])){
                saveLayers[e] = LayerMask.NameToLayer(layerOfPackage[e]);
                Debug.Log("funcoiunarq " + e + " " +saveLayers[e]);
                e++;
                saveLayers = new int[e + 1];
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

