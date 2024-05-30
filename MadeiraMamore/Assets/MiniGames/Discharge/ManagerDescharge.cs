using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerDescharge : MonoBehaviour
{
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    [SerializeField] private DeschargeMinigame[] DescharMiniScricpt;
    [SerializeField] private UIDeposit UIDepositScript;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private GameObject depositPrefab;
    [SerializeField] private Transform[] depositPosition;
    private GameObject[] deposit;
    private bool startGame;
    public void StartMinigame(){
        colorLayerScriptable.amoutPackage = 0;
        
        startGame = false;
        for(int i = 0; i < DescharMiniScricpt.Length; i++) {
            DescharMiniScricpt[i].CreateBoxs();
        }

        List<int> uniqueNumbers = RemoveDuplicates(colorLayerScriptable.packageLayer);

        colorLayerScriptable.packageLayer = uniqueNumbers;


        int saveLayerAmout = colorLayerScriptable.packageLayer.ToArray().Length;
        int[] giveDepositAmoutLayer = new int[depositPosition.Length];
        int halfTipLayer = saveLayerAmout/depositPosition.Length; 
        
        deposit = new GameObject[depositPosition.Length];

        if (saveLayerAmout % depositPosition.Length != 0){
            int randomizedDeposit = Random.Range(0, depositPosition.Length);
            int remainingLayers = saveLayerAmout % depositPosition.Length;
            giveDepositAmoutLayer[randomizedDeposit] = remainingLayers;
        }
        for(int i = 0; i < giveDepositAmoutLayer.Length; i++) {
            giveDepositAmoutLayer[i] += halfTipLayer;
        }
        UIDepositScript.gameObject.SetActive(true);
        for(int i = 0; i < depositPosition.Length; i++){
            deposit[i] = Instantiate(depositPrefab, depositPosition[i].position, depositPosition[i].rotation);
            GameObject depositChild = deposit[i].transform.GetChild(0).gameObject;
            UIDepositScript.packageScript = new PackgeController[deposit.Length];
            UIDepositScript.packageScript[i] = depositChild.GetComponent<PackgeController>();
            for(int a = 0; a < giveDepositAmoutLayer[i]; a++){
                int  givelayer = colorLayerScriptable.packageLayer[0];
                //Debug.Log(" vez i vagao " + i + "givelayer " + givelayer + "rodou quantas vezes " + a);
                depositChild.GetComponent<PackgeController>().layerAccept.Add(givelayer);
                colorLayerScriptable.packageLayer.RemoveAt(0);
            }
            UIDepositScript.Deposit(i);

        }
        startGame = true;
    }
    List<T> RemoveDuplicates<T>(List<T> list)
    {
        return list.Distinct().ToList();
    }
    void Update(){
        if(colorLayerScriptable.amoutPackage == 0 && startGame == true) {
            rafflequestScript.CompleteQuest();
            for(int i = 0; i < deposit.Length; i++){
                Destroy(deposit[i], 0.5f);
            }
            startGame = false;
        }
    }
    public void Reset(){
        if(deposit != null) {
            for(int i = 0; i < deposit.Length; i++) {
                Destroy(deposit[i], 0.5f);
            }
        }
    }
}
