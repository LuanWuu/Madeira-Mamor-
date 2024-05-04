using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensageController : MonoBehaviour
{
    [SerializeField] private roadMap characterWords;
    [SerializeField] private TextMeshProUGUI speechBubble;
    [SerializeField] private bool cheif;
    [SerializeField] private bool guard;
    [SerializeField] private bool[] worker;
    int placeNumber;
    private  List<string> myCharacterlist = new List<string>();
    private void Start() {
        if(cheif == true){
            myCharacterlist = characterWords.cheif;
        }else if(guard == true){
            myCharacterlist = characterWords.guard;
        }else{
            for(int i = 0; i < worker.Length; i++) {
                if(worker[i] == true){
                    characterWords.InitializeWorkerTalk();
                    myCharacterlist = characterWords.workerTalk[i];
                    //speechBubble.text = myCharacterlist[0];
                }
            }
        }
    }
    public void ChangePhrase(){
        placeNumber++;
        if(placeNumber <= myCharacterlist.Count){
            speechBubble.text = myCharacterlist[placeNumber];
        }else{
            Debug.Log("acabou as frases");
        }
    }
}
