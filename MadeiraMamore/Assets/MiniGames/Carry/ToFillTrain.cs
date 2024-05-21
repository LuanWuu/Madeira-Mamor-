using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFillTrain : MonoBehaviour
{
    [SerializeField] private GameObject fulfilling;
    [System.NonSerialized] public List<int> LayerAccept  = new List<int>();
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
    public void ResetWagons(){
        LayerAccept.Clear();
        turn = 0;
        for (int i = 0; i < fulfilling.transform.childCount; i++)
        {
            fulfilling.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
     public void CompatibleLayer(int boxLayer){
        if (LayerAccept.Contains(boxLayer)){
            renderTrain.material.SetFloat("_ValueMultiplay", 1.02f);// Ativando o Contorno
        }else{
            renderTrain.material.SetFloat("_ValueMultiplay", 0);// desativando o o Contorno
        }
    }

    public void CheckLayerPackage(Color boxColor,int boxLayer, GameObject target){
        if (LayerAccept.Contains(boxLayer)){
            FillTheLoad(boxColor);
            Destroy(target, 0.15f);
        }
    }
    void FillTheLoad (Color boxColor) {
        if(turn < boxFulfilling.Length){ 
            boxFulfilling[turn].SetActive(true);
            GameObject boxColorFill = boxFulfilling[turn].transform.GetChild(1).gameObject;
            boxColorFill.GetComponent<Renderer>().materials[1].color = boxColor;
        }
        turn++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
