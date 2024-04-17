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

    public void CheckLayerPackage(Color boxColor,int boxLayer, GameObject target){
        Debug.Log("Box layer " + boxLayer);
        if (LayerAccept.Contains(boxLayer)){
            FillTheLoad(boxColor);
            Destroy(target, 0.15f);
            Debug.Log("entregou");
        }
    }
    void FillTheLoad (Color boxColor) {
        if(turn < boxFulfilling.Length){ 
            boxFulfilling[turn].SetActive(true);
            boxFulfilling[turn].GetComponent<Renderer>().material.color = boxColor;
            Debug.Log(" turn " + turn);
        }
        turn++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
