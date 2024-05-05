using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensageController : MonoBehaviour
{
    [SerializeField] private roadMap characterWords;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private TextMeshProUGUI speechBubbleText;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private bool cheif;
    [SerializeField] private bool guard;
    [SerializeField] private bool[] worker;
    int placeNumber;
    private List<string> myCharacterlist = new List<string>();
    private List<string>[] speechesOfDay;
    private void Start() {
        if(cheif == true){
            myCharacterlist = characterWords.cheif;
        }else if(guard == true){
            myCharacterlist = characterWords.guard;
        }
    }
    public void PickWorkerWords(){
        switch(DaySystem.day){
            case 1:
                speechesOfDay = characterWords.workerTalkDay1;
                break;
            case 2:
                speechesOfDay = characterWords.workerTalkDay2;
                break;
            case 12:
                speechesOfDay = characterWords.workerTalkDay12;
                break;
            case 20:
                speechesOfDay = characterWords.workerTalkDay20;
                break;
            case 22:
                 speechesOfDay = characterWords.workerTalkDay22;
                break;
            case 25:
                speechesOfDay = characterWords.workerTalkDay25;
                break;
            case 26:
                speechesOfDay = characterWords.workerTalkDay26;
                break;
            case 27:
                speechesOfDay = characterWords.workerTalkDay27;
                break;
        }
        GiveTalk();
    }
    void GiveTalk(){
        for(int i = 0; i < worker.Length; i++) {
            if(worker[i] == true){
                myCharacterlist = speechesOfDay[i];
                speechBubbleText.text = myCharacterlist[0];
                break;
            }
        }
        placeNumber = 0;
    }
    public void ChangePhrase(){
        placeNumber++;
        if(placeNumber < myCharacterlist.Count){
            speechBubbleText.text = myCharacterlist[placeNumber];
        }else{
            Debug.Log("acabou as frases");
            speechBubble.gameObject.SetActive(false);
            GiveTalk();
            PlayerCamera.DisabledCursor();
        }
    }
    public void GiveToBottun(){
        ButtonPlayerTalk.mensageControllerScript = GetComponent<MensageController>();
    }
}
