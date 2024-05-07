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
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private QuestUI QuestUIscript;

    private int numberMinigame;
    private int beforeNumberMinigame;
    private GameObject packages;
    private Box boxScript;
    // Start is called before the first frame update
    void Start()
    {

        DecideAmoutBox();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown("l")){
            DecideAmoutBox();
        }
    }
    void DecideAmoutBox(){
        while (true){
            numberMinigame = Random.Range(0, optionsBox);
            if (numberMinigame != beforeNumberMinigame){
                //Debug.Log("minigame: " + numberMinigame);
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
        boxScript = packages.GetComponent<Box>();
        boxScript.carryMinimageScript = GetComponent<CarryMinimage>();
        boxScript.rafflequestScript = rafflequestScript;

    }
    public void GiveLayerGenerated(){
        int saveLayerAmout = boxScript.saveLayers.ToArray().Length;
        int[] transferLayerBox = boxScript.saveLayers.ToArray();
        List<int> transferList = boxScript.saveLayers;

        int[] giveWagonsAmoutLayer = new int[wagons.Length];
        int halfTipLayer = saveLayerAmout/wagons.Length; 

        //foreach (int elemento in transferList)
        //{
        //   Debug.Log("layer da  lista " + elemento);
        //}
        if (saveLayerAmout % wagons.Length != 0){
            int randomizedWagons = Random.Range(0,wagons.Length);
            int remainingLayers = saveLayerAmout % wagons.Length;
            giveWagonsAmoutLayer[randomizedWagons] = remainingLayers;
        }
        for(int i = 0; i < giveWagonsAmoutLayer.Length; i++) {
            giveWagonsAmoutLayer[i] += halfTipLayer;
        }
        for(int i = 0; i < wagons.Length; i++){
            for(int a = 0; a < giveWagonsAmoutLayer[i]; a++){
                int  givelayer = transferList[0];
                //Debug.Log(" vez i vagao " + i + "givelayer " + givelayer + "rodou quantas vezes " + a);
                wagons[i].GetComponent<ToFillTrain>().LayerAccept.Add(givelayer);
                transferList.RemoveAt(0);
            }
            QuestUIscript.Wagon(i);
        }
        QuestUIscript.gameObject.SetActive(true);
        int maxValueLayer = transferLayerBox.Max() + 1;
        int minValuerLayer = transferLayerBox.Min();
        //Debug.Log("mim " + minValuerLayer + " max " + maxValueLayer);
    }
}
