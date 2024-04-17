using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFillTrain : MonoBehaviour
{
    [SerializeField] private GameObject fulfilling;
    private GameObject[] boxFulfilling;
    private int turn = 0;
    private bool canGetPackage;
    private int[] transferLayerFilter;
    // Start is called before the first frame update
    void Start()
    {
        boxFulfilling = new GameObject[fulfilling.transform.childCount];
        for (int i = 0; i < fulfilling.transform.childCount; i++)
        {
            boxFulfilling[i]= fulfilling.transform.GetChild(i).gameObject;
        }
        Debug.Log(boxFulfilling.Length);
    }
    public void FilterLayerAccept (int[] layersAccpet) {
        transferLayerFilter = layersAccpet;
        //for(int i = 0; i < transferLayerFilter.Length; i++) {
        //    Debug.Log("LayerAccept " + transferLayerFilter[i]);
        //}
    }
    public void CheckLayerPackage(Color boxColor,int boxLayer){
        Debug.Log("Box layer " + boxLayer);
        for(int i = 0; i < transferLayerFilter.Length; i++) {
            if(boxLayer == transferLayerFilter[i]){
                canGetPackage = true;
            }
        }
        if(canGetPackage == true){
            FillTheLoad(boxColor);
        }
    }
    void FillTheLoad (Color boxColor) {
        if(turn < boxFulfilling.Length){ 
            boxFulfilling[turn].SetActive(true);
            boxFulfilling[turn].GetComponent<Renderer>().material.color = boxColor;
            Debug.Log(" turn " + turn);
        }
        turn++;
        canGetPackage = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
