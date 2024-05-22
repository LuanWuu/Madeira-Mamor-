using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MensageController : MonoBehaviour
{
    public List<string> characterNames;
    [SerializeField] private roadMap characterWords;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private TextMeshProUGUI speechBubbleText;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject buttonPositive;
    [SerializeField] private GameObject buttonNegative;
    [SerializeField] private RaffleQuest rafflequestScript;

    int numeberOfWorker;
    int placeNumber;
    int numberAnswerPositive;
    int numberAnswerNegative;
    int? count = 0;
    int saveDayTime = 0;
    [System.NonSerialized] public int moment = 0;
    [System.NonSerialized] public bool oneTime = true;
    private List<string> myCharacterlist;
    private List<string> myCharacterAnswerPositive;
    private List<string> myCharacterAnswerNegative;
    private List<string> localPlayerAnswers;
    private List<string>[] speechesOfDay;

    ButtonPlayerTalk posiButton;
    ButtonPlayerTalk negaButton;

    private void Start() {
        posiButton = buttonPositive.GetComponent<ButtonPlayerTalk>();
        negaButton = buttonNegative.GetComponent<ButtonPlayerTalk>();
    }
    public void PickWorkerWords(){
        switch(DaySystem.day){
            case 1:
                speechesOfDay = characterWords.workerTalkDay1;
                break;
            case 2:
                speechesOfDay = characterWords.workerTalkDay2;
                break;
            case 3:
                speechesOfDay = characterWords.workerTalkDay12;
                break;
            case 4:
                speechesOfDay = characterWords.workerTalkDay20;
                break;
            case 5:
                speechesOfDay = characterWords.workerTalkDay22;
                break;
            case 6:
                speechesOfDay = characterWords.workerTalkDay25;
                break;
            case 7:
                speechesOfDay = characterWords.workerTalkDay26;
                break;
            case 8:
                speechesOfDay = characterWords.workerTalkDay27;
                break;
        }
        if(saveDayTime == DaySystem.day){
            if(count == 10){
                characterWords.SpecialNight3();
            }else{
                characterWords.SpecialNight2();
            }
            Debug.Log("dsadas" + count);
        }
    }
    
    public void GiveTalk(string name){
        for(int i = 0; i < characterNames.Count; i++) {
            if(name == characterNames[i]){
                numeberOfWorker = i;
                break;
            }
        }       
        placeNumber = 0;
        if(numeberOfWorker != 6 && numeberOfWorker !=7){
            if(DaySystem.dayTime != "Lunch" && DaySystem.dayTime != "Night"){
                myCharacterlist = characterWords.NotTalkMoment[numeberOfWorker];
            }else if(DaySystem.dayTime == "Lunch" || DaySystem.dayTime == "Night"){
                myCharacterlist = speechesOfDay[numeberOfWorker];
            }
            numberAnswerPositive = 0;
            numberAnswerNegative = 0;
            GetIndexOfList();
        }else if(numeberOfWorker == 6){//Chief
            myCharacterlist = characterWords.cheif;
        }else if(numeberOfWorker == 7){ //Guard
            myCharacterlist = characterWords.guard;
        }
        speechBubbleText.text = myCharacterlist[0];    
    }
    public void ChangePhrase(){
        placeNumber++;
        if(placeNumber < myCharacterlist.Count){
            speechBubbleText.text = myCharacterlist[placeNumber];
            if(numeberOfWorker != 6 && numeberOfWorker !=7){
                GetIndexOfList();
            }
        }else{
            speechBubble.gameObject.SetActive(false);
            PlayerCamera.DisabledCursor();
            if(numeberOfWorker == 6){ 
                DayTCScript.TimeOfDay(moment);
                moment++;
                if(DaySystem.dayTime != "Night" && DaySystem.dayTime != "Lunch"){
                    rafflequestScript.DecideQuest();
                    oneTime = false;
                }
            }
        }
    }
    public void GiveToBottun(){
        nextButton.GetComponent<ButtonPlayerTalk>().mensageControllerScript = GetComponent<MensageController>();
    }
    void GetIndexOfList(){
        switch(numeberOfWorker){
            case 0:
                Worker0();
                break;
            case 2:
                Worker2();
                break;
            case 4:
                Worker4();
                break;
            case 5:
               Worker5();
                break;
            default:
                break;
        }
    }
    void ActiveButtonsAnswer(){
        nextButton.SetActive(false);
        buttonPositive.SetActive(true);
        posiButton.mensageControllerScript = GetComponent<MensageController>();
        buttonNegative.SetActive(true);
        negaButton.mensageControllerScript = GetComponent<MensageController>();
        characterWords.answer = true;
    }
    void DisableButtonsAnswer(){
        buttonPositive.SetActive(false);
        buttonNegative.SetActive(false);
        nextButton.SetActive(true);
    }
    void DisableAnswer(){
        characterWords.answer = false;
    }
    public void AnswerPositive(){
        nextButton.GetComponent<ButtonPlayerTalk>().localSignal = true;
            if(numberAnswerPositive <= (myCharacterAnswerPositive.Count-1)){
                speechBubbleText.text =  myCharacterAnswerPositive[numberAnswerPositive];
                numberAnswerPositive++;
            }
            if(numberAnswerPositive > (myCharacterAnswerPositive.Count-1)){
                DisableAnswer();
            }
            if(numeberOfWorker == 5){
                SpecialEnd();
            }
        DisableButtonsAnswer();
    }
    public void AnswerNegative(){
        nextButton.GetComponent<ButtonPlayerTalk>().localSignal = false;
        if(numberAnswerNegative <= (myCharacterAnswerNegative.Count-1)){
            speechBubbleText.text =  myCharacterAnswerNegative[numberAnswerNegative];
            numberAnswerNegative++;
        }
        if(numberAnswerNegative > (myCharacterAnswerNegative.Count-1)){
            DisableAnswer();
        }         
        DisableButtonsAnswer();
    }
    void GivePlayerAnswer(List<string> give){
        posiButton.PlayerAnswersButtons(give);
        negaButton.PlayerAnswersButtons(give);
    }
    void Worker0(){
        myCharacterAnswerPositive = characterWords.worker0AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker0AnswerNegative;
        int[] indexAnswer = new int[]{ 1,1,4,0,1};
        switch(DaySystem.day){
            case 1:
                if(placeNumber == 1){
                    ActiveButtonsAnswer();
                    GivePlayerAnswer(characterWords.playerAnswers[0]);
                }
                break;
            case 2:
                if(placeNumber == 1){;
                    ActiveButtonsAnswer();
                    GivePlayerAnswer(characterWords.playerAnswers[0]);
                }
                break;
            case 4:
                if(placeNumber == 3){
                    ActiveButtonsAnswer();
                    GivePlayerAnswer(characterWords.playerAnswers[0]);
                }
                break;
            case 5:
                if (placeNumber == 0){
                    GivePlayerAnswer(characterWords.playerAnswers[0]);
                    ActiveButtonsAnswer();
                }else if (placeNumber == 3){
                    myCharacterAnswerPositive = characterWords.worker0AnswerPositive2Day22;
                    numberAnswerPositive = 0;
                    myCharacterAnswerNegative = characterWords.worker0AnswerNegative2Day22;
                    numberAnswerNegative = 0;
                    GivePlayerAnswer(characterWords.playerAnswers[3]);
                    ActiveButtonsAnswer();
                }
                break;
        }

    }
    void Worker2(){
        myCharacterAnswerPositive = characterWords.worker2AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker2AnswerNegative;
        if(DaySystem.day == 3){
            if(placeNumber == 0){
                nextButton.GetComponent<ButtonPlayerTalk>().buttonNext(characterWords.playerAnswers[2]);
            }else if(placeNumber ==2){
                ActiveButtonsAnswer();
                GivePlayerAnswer(characterWords.playerAnswers[2]);
            }
        }
    }
    void Worker4(){
        myCharacterAnswerPositive = characterWords.worker4AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker4AnswerNegative;
        if(DaySystem.day == 8 && placeNumber == 1 ){
                ActiveButtonsAnswer();
                GivePlayerAnswer(characterWords.playerAnswers[4]);
        }
    }
    void Worker5(){
        myCharacterAnswerPositive = characterWords.worker5AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker5AnswerNegative;
        if(count == 0 && placeNumber == 2) {
            ActiveButtonsAnswer();
            GivePlayerAnswer(characterWords.playerAnswers[5]);
            count++;
        }
        if(count > 0 && placeNumber == 3){
            SpecialEnd();
            count = 10;
        }
    }
    void SpecialEnd(){
        saveDayTime = DaySystem.day;
        saveDayTime++;
    }
}
