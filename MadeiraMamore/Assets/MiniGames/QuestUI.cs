using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    private bool isOpen;
    int amoutTipeBox;
    [SerializeField] private GameObject[] boxList;
    [SerializeField] private ToFillTrain[] wagonScripts;
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    private Image[] boxImage;
    private List<int> boxLayer;
    private int numberOfWAGON;
    // Start is called before the first frame update
    void Start()
    {
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
        int amoutPainting = 0;
        for(int i = 0; i < numberlayers.Length; i++) {
            for(int l = 0; l < colorLayerScriptable.layerOfPackage.Length; l++) {
                if(numberlayers[i] == LayerMask.NameToLayer(colorLayerScriptable.layerOfPackage[l])){
                    boxImage[i].color = colorLayerScriptable.packageColor[l];
                    amoutPainting++;
                }
            }
        }
        for(int i = boxImage.Length; i > amoutPainting ; i--){
            int o = i -1;
            boxImage[o].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(isOpen == false){
                isOpen = true;
                gameObject.SetActive(false);
            }else{
                isOpen = false;
                gameObject.SetActive(true);
            }
        }
        
    }
}
