using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarryUI : MonoBehaviour
{
    int amoutTipeBox;
    [SerializeField] private GameObject[] boxList;
    [SerializeField] private ToFillTrain[] wagonScripts;
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    private Image[] boxImage;
    private int numberOfWAGON;
    void Start(){

    }
    public void Reset(){
        for(int i = 0; i < boxList.Length; i++) {
            for(int c = 0; c < boxList[i].transform.childCount; c++) {
                boxList[i].transform.GetChild(c).gameObject.SetActive(true);
            }
        }
    }
    public void Wagon(int numerberWagon){
        numberOfWAGON = numerberWagon;
        boxList[numerberWagon].SetActive(true);
        CheckWagonAccpet();
    }
    void CheckWagonAccpet(){
        boxImage = new Image[boxList[numberOfWAGON].transform.childCount];
        for(int i = 0; i < boxImage.Length; i++) {
            boxImage[i] = boxList[numberOfWAGON].transform.GetChild(i).GetComponent<Image>();
        } 
        LayerListToColorList();         
    }
    void LayerListToColorList(){
        int[] numberlayers = new int[wagonScripts[numberOfWAGON].LayerAccept.Count];
        numberlayers = wagonScripts[numberOfWAGON].LayerAccept.ToArray();
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
        Debug.Log("amoutPainting " + amout);
        for(int i = boxImage.Length; i > amout; i--){
            boxImage[i-1].gameObject.SetActive(false);
            Debug.Log("oBJETO dESABILITADO " + (i-1));
            Debug.Log("vez lifasd " + i);
        }
    }
}
