using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeschargeMinigame : MonoBehaviour
{
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    [SerializeField] private GameObject load;
    [System.NonSerialized] public List<int> saveLayers = new List<int>();
    private Color[] localPackageColor;
    private string[] localLayerOfPackage;
    
    private GameObject package;
    private GameObject[] packageColor;

    [SerializeField] private int maxBOX;
    // Start is called before the first frame update
    public void Start()
    {
        int amoutBox = Random.Range(2, maxBOX);

        localPackageColor = new Color[colorLayerScriptable.packageColor.Length];
        localPackageColor = colorLayerScriptable.packageColor;

        localLayerOfPackage = new string[colorLayerScriptable.layerOfPackage.Length];
        localLayerOfPackage = colorLayerScriptable.layerOfPackage;

        packageColor = new GameObject[load.transform.childCount];
        int[] saveLayerPackege = new int[load.transform.childCount];

        for (int i = 0; i < amoutBox; i++)
        {
            package = load.transform.GetChild(i).gameObject;
            packageColor[i] = package.transform.GetChild(1).gameObject;
            int decideTypePackage = Random.Range(0,localLayerOfPackage.Length);
            packageColor[i].layer = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            packageColor[i].GetComponent<Renderer>().materials[1].color = localPackageColor[decideTypePackage];
            Debug.Log("caloraedsa " + packageColor[i].name);
            //Debug.Log(LayerMask.LayerToName(gameObject.layer) + LayerMask.NameToLayer(layerOfPackage[i])); 
            saveLayerPackege[i] = LayerMask.NameToLayer(localLayerOfPackage[decideTypePackage]);
            package.SetActive(true);
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
