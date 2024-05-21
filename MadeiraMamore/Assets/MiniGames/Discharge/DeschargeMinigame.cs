using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeschargeMinigame : MonoBehaviour
{
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    [SerializeField] private GameObject load;
    [SerializeField] private GameObject box;
    private List<int> saveLayersDescharger = new List<int>();
    private Color[] localPackageColor;
    private string[] localLayerOfPackage;
    
    private GameObject[] package;
    private GameObject[] packageColor;
    private int number =0 ;

    [SerializeField] private int maxBOX;
    // Start is called before the first frame update
    public void CreateBoxs()
    {
        int amoutBox = Random.Range(3, maxBOX);

        localPackageColor = new Color[colorLayerScriptable.packageColor.Length];
        localPackageColor = colorLayerScriptable.packageColor;

        localLayerOfPackage = new string[colorLayerScriptable.layerOfPackage.Length];
        localLayerOfPackage = colorLayerScriptable.layerOfPackage;
        package = new GameObject[load.transform.childCount];
        packageColor = new GameObject[load.transform.childCount];
        int[] saveLayerPackege = new int[load.transform.childCount];

        for (int i = 0; i < amoutBox; i++)
        {
            package[i] = load.transform.GetChild(i).gameObject;
            packageColor[i] = package[i].transform.GetChild(1).gameObject;
            int decideTypePackage = Random.Range(0,localLayerOfPackage.Length);
            package[i].layer = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            packageColor[i].GetComponent<Renderer>().materials[1].color = localPackageColor[decideTypePackage];
            Debug.Log("caloraedsa " + packageColor[i].name);
            //Debug.Log(LayerMask.LayerToName(gameObject.layer) + LayerMask.NameToLayer(layerOfPackage[i])); 
            saveLayerPackege[i] = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            package[i].SetActive(true);
        }
        for(int i = 0; i < saveLayerPackege.Length; i++) {
            for(int e = 0; e < localLayerOfPackage.Length; e++) {
                if(saveLayerPackege[i] == LayerMask.NameToLayer(localLayerOfPackage[e])){
                    if (!saveLayersDescharger.Contains(LayerMask.NameToLayer(localLayerOfPackage[e]))){
                        saveLayersDescharger.Add(LayerMask.NameToLayer(localLayerOfPackage[e]));
                        //Debug.Log("funcoiunarq " + i + "i numero E" + e + " layer " + LayerMask.NameToLayer(layerOfPackage[e]));
                    }
                }
            }
        }
        colorLayerScriptable.packageLayer.AddRange(saveLayersDescharger);
    }

    public void GiveClone(Transform positionHand){
        if(package[number] !=  null){
            GameObject boxClone = Instantiate(box,positionHand.position, Quaternion.identity);
            boxClone.layer = package[number].layer;
            GameObject boxCloneColor = boxClone.transform.GetChild(1).gameObject;
            boxCloneColor.GetComponent<Renderer>().materials[1].color = packageColor[number].GetComponent<Renderer>().materials[1].color;
            package[number].SetActive(false);
            number++;
        }
    }
    public void ActiveOutiline(){
        if(package[number] !=  null){
            GetComponent<Renderer>().material.SetFloat("_ValueMultiplay", 1.02f);
        }else{
            GetComponent<Renderer>().material.SetFloat("_ValueMultiplay", 0);
        }
    }
}
