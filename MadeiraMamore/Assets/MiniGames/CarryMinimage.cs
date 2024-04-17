using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CarryMinimage : MonoBehaviour
{
    [SerializeField] private GameObject nineBox;
    [SerializeField] private GameObject twelveBox;
    [SerializeField] private GameObject fifteenBox;
    [SerializeField] private GameObject[] wagons;
    [SerializeField] private Transform boxsPosition;
    [SerializeField] private int optionsBox;

    private int numberMinigame;
    private int beforeNumberMinigame;
    private GameObject packages;
    // Start is called before the first frame update
    void Start()
    {
        DecideAmoutBox();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("l")){
            GiveLayerGenerated();
        }
    }
    void DecideAmoutBox(){
        while (true){
            numberMinigame = Random.Range(0, optionsBox);
            if (numberMinigame != beforeNumberMinigame){
                Debug.Log("minigame: " + numberMinigame);
                break;
            }
        }
        numberMinigame = 0;
        switch(numberMinigame){
            case 0:
                packages = Instantiate(nineBox, boxsPosition.position, Quaternion.identity);
                break;
            case 1:
                packages = Instantiate(twelveBox, boxsPosition.position, Quaternion.identity);
                break;
            case 2:
                packages = Instantiate(fifteenBox, boxsPosition.position, Quaternion.identity);
                break;
            default:
                break;
        }
        beforeNumberMinigame = numberMinigame;
        packages.GetComponent<Box>().carryMinimageScript = GetComponent<CarryMinimage>();
    }
    public void GiveLayerGenerated(){
        Box boxScript = packages.GetComponent<Box>();
        int layerAmout = boxScript.layerOfPackage.Length;
        int saveLayerAmout = boxScript.saveLayers.Length;
        int[] transferLayerBox = boxScript.saveLayers;

        int maxValueLayer = transferLayerBox.Max() + 1;
        int minValuerLayer = transferLayerBox.Min();
        int[] giveWagonsAmoutLayer = new int[wagons.Length];
        int randomizedWagons = Random.Range(0,wagons.Length);
        int halfTipLayer = transferLayerBox.Length/2; 

        if (transferLayerBox.Length % 2 != 0){
            giveWagonsAmoutLayer[randomizedWagons] = transferLayerBox.Length % 2;
        }
        for(int i = 0; i < giveWagonsAmoutLayer.Length; i++) {
            giveWagonsAmoutLayer[i] += halfTipLayer;
            Debug.Log("valor do wanfos " + giveWagonsAmoutLayer[i]);
        }
        //if transferLayerBox.Length = 5
        //train1 == 2 typsLayer
        //trin 2 == 2 typsLayer + Luck + 1 
        int randomized;
        int[] randomizeTipLayer = new int[saveLayerAmout];
        int[] sendLayers = new int[saveLayerAmout];
        int r = 0;
         Debug.Log("mim " + minValuerLayer + " max " + maxValueLayer);
        for(int i = 0; i < wagons.Length; i++){
            for(int a = 0; a < giveWagonsAmoutLayer[i]; a++) {
                do{
                randomized = Random.Range(minValuerLayer,maxValueLayer);
                }while (ArrayContains(randomizeTipLayer, randomized));
                randomizeTipLayer[a] = randomized;
                sendLayers[a] = randomizeTipLayer[r];
                Debug.Log(" vez a " + a + " vez i vagao " + i);
                wagons[i].GetComponent<ToFillTrain>().FilterLayerAccept(sendLayers);
                Debug.Log("sendLayers " + sendLayers);
                r++;
            }
        }
    }
    bool ArrayContains(int[] array, int value)
    {
        foreach (int element in array)
        {
            if (element == value)
            {
                return true;
            }
        }
        return false;
    }
}
