using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeposit : MonoBehaviour
{
    int amoutTipeBox;
    [SerializeField] private GameObject[] boxList;
    [System.NonSerialized] public PackgeController[] packageScript;
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    private Image[] boxImage;
    private int numberOfDeposit;
    void Start(){

    }
    public void Reset(){
        for(int i = 0; i < boxList.Length; i++) {
            for(int c = 0; c < boxList[i].transform.childCount; c++) {
                boxList[i].transform.GetChild(c).gameObject.SetActive(true);
            }
        }
    }
    public void Deposit(int numerberDeposit){
        numberOfDeposit = numerberDeposit;
        boxList[numerberDeposit].SetActive(true);
        CheckWagonAccpet();
    }
    void CheckWagonAccpet(){
        boxImage = new Image[boxList[numberOfDeposit].transform.childCount];
        for(int i = 0; i < boxImage.Length; i++) {
            boxImage[i] = boxList[numberOfDeposit].transform.GetChild(i).GetComponent<Image>();
        } 
        LayerListToColorList();         
    }
    void LayerListToColorList(){
        int[] numberlayers = new int[packageScript[numberOfDeposit].layerAccept .Count];
        numberlayers = packageScript[numberOfDeposit].layerAccept .ToArray();
        Debug.Log(" numberlayers " + numberlayers.Length);
        int amoutNotPainting = 0;
        for(int i = 0; i < numberlayers.Length; i++) {
            for(int l = 0; l < colorLayerScriptable.layerOfPackage.Length; l++) {
                if(numberlayers[i] == LayerMask.NameToLayer(colorLayerScriptable.layerOfPackage[l])){
                    boxImage[i].color = colorLayerScriptable.packageColor[l];
                    amoutNotPainting++;
                }
            }
        }
        DesabledAdditional(amoutNotPainting);
    }
    void DesabledAdditional(int amout){
        //Debug.Log("amoutPainting " + amout);
        for(int i = boxImage.Length; i > amout; i--){
            boxImage[i-1].gameObject.SetActive(false);
            //Debug.Log("oBJETO dESABILITADO " + (i-1));
            //Debug.Log("vez lifasd " + i);
        }
    }
}
