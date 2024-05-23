using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackgeController : MonoBehaviour
{
    [SerializeField] private GameObject fulfilling;
    [SerializeField] private ColorsAndLayers colorLayerScriptable;

    public List<int> layerAccept = new List<int>();

    private GameObject[] boxFulfilling;
    private int turn = 0;
    private int[] transferLayerFilter;
    private Renderer renderTrain;
    // Start is called before the first frame update
    void Start()
    {
        boxFulfilling = new GameObject[fulfilling.transform.childCount];
        for (int i = 0; i < fulfilling.transform.childCount; i++)
        {
            boxFulfilling[i]= fulfilling.transform.GetChild(i).gameObject;
        }
        //Debug.Log(boxFulfilling.Length);
        renderTrain = GetComponent<Renderer>();
    }

     public void CompatibleLayer(int boxLayer){
        if (layerAccept.Contains(boxLayer)){
            renderTrain.material.SetFloat("_ValueMultiplay", 1.02f);// Ativando o Contorno
        }else{
            renderTrain.material.SetFloat("_ValueMultiplay", 0);// desativando o o Contorno
        }
    }

    public void CheckLayerPackage(Color boxColor,int boxLayer, GameObject target){
        if (layerAccept.Contains(boxLayer)){
            FillTheLoad(boxColor);
            Destroy(target, 0.15f);
        }
    }
    void FillTheLoad (Color boxColor) {
        if(turn < boxFulfilling.Length){ 
            boxFulfilling[turn].SetActive(true);
            GameObject boxColorChild = boxFulfilling[turn].transform.GetChild(1).gameObject;
            boxColorChild.GetComponent<Renderer>().materials[1].color = boxColor;
            colorLayerScriptable.amoutPackage--;
            Debug.Log("amout " + colorLayerScriptable.amoutPackage);
        }
        turn++;
    }

}
