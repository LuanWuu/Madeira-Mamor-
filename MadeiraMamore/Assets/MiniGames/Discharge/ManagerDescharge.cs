using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDescharge : MonoBehaviour
{
    [SerializeField] private ColorsAndLayers colorLayerScriptable;
    [SerializeField] private DeschargeMinigame[] DescharMiniScricpt;
    [SerializeField] private GameObject depositPrefab;
    [SerializeField] private Transform[] depositPosition;
    public void StartMinigame(){
        for(int i = 0; i < DescharMiniScricpt.Length; i++) {
            DescharMiniScricpt[i].CreateBoxs();
        }
        Debug.Log("teste");
        int saveLayerAmout = colorLayerScriptable.packageLayer.ToArray().Length;
        int[] giveDepositAmoutLayer = new int[depositPosition.Length];
        int halfTipLayer = saveLayerAmout/depositPosition.Length; 

        if (saveLayerAmout % depositPosition.Length != 0){
            int randomizedDeposit = Random.Range(0, depositPosition.Length);
            int remainingLayers = saveLayerAmout % depositPosition.Length;
            giveDepositAmoutLayer[randomizedDeposit] = remainingLayers;
        }
        for(int i = 0; i < giveDepositAmoutLayer.Length; i++) {
            giveDepositAmoutLayer[i] += halfTipLayer;
        }
        for(int i = 0; i < depositPosition.Length; i++){
            GameObject deposit = Instantiate(depositPrefab, depositPosition[i].position, depositPosition[i].rotation);
            GameObject depositChild = deposit.transform.GetChild(0).gameObject;
            for(int a = 0; a < giveDepositAmoutLayer[i]; a++){
                int  givelayer = colorLayerScriptable.packageLayer[0];
                //Debug.Log(" vez i vagao " + i + "givelayer " + givelayer + "rodou quantas vezes " + a);
                depositChild.GetComponent<PackgeController>().layerAccept.Add(givelayer);
                colorLayerScriptable.packageLayer.RemoveAt(0);
            }
           // CarryUIScript.Wagon(i);
        }
    }
}
