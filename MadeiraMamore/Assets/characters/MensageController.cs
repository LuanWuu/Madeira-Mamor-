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
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject buttonPositive;
    [SerializeField] private GameObject buttonNegative;
    [SerializeField] private bool cheif;
    [SerializeField] private bool guard;
    [SerializeField] private bool[] worker;

    int numeberOfWorker;
    int placeNumber;
    int numberAnswerPositive;
    int numberAnswerNegative;
    int? count = 0;

    private List<string> myCharacterlist;
    private List<string> myCharacterAnswerPositive;
    private List<string> myCharacterAnswerNegative;
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
    }
    public void GiveTalk(){
        for(int i = 0; i < worker.Length; i++) {
            if (worker[i] == true){
                if(i == 5){
                    myCharacterlist = characterWords.worker6Special;
                    speechBubbleText.text = myCharacterlist[0];
                    numeberOfWorker = i;
                    break;
                }
                myCharacterlist = speechesOfDay[i];
                speechBubbleText.text = myCharacterlist[0];
                numeberOfWorker = i;
                break;
            }
        }
        placeNumber = 0;
        numberAnswerPositive = 0;
        numberAnswerNegative = 0;
        GetIndexOfList();
    }
    public void ChangePhrase(){
        placeNumber++;
        if(placeNumber < myCharacterlist.Count){
            Debug.Log("index da frase " + placeNumber);
            speechBubbleText.text = myCharacterlist[placeNumber];
            GetIndexOfList();
        }else{
            Debug.Log("acabou as frases");
            speechBubble.gameObject.SetActive(false);
            GiveTalk();
            PlayerCamera.DisabledCursor();
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
        ButtonPlayerTalk posiButton = buttonPositive.GetComponent<ButtonPlayerTalk>();
        posiButton.mensageControllerScript = GetComponent<MensageController>();
        buttonNegative.SetActive(true);
        ButtonPlayerTalk negaButton = buttonNegative.GetComponent<ButtonPlayerTalk>();
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
        Debug.Log("positive" + numberAnswerPositive);
            if(numberAnswerPositive <= (myCharacterAnswerPositive.Count-1)){
                speechBubbleText.text =  myCharacterAnswerPositive[numberAnswerPositive];
                numberAnswerPositive++;
            }
            if(numberAnswerPositive > (myCharacterAnswerPositive.Count-1)){
                DisableAnswer();
            }
            Debug.Log(numeberOfWorker);
            if(numeberOfWorker == 5){
                characterWords.SpecialNight2();
                Debug.Log("oxi");
            }
        DisableButtonsAnswer();
    }
    public void AnswerNegative(){
        nextButton.GetComponent<ButtonPlayerTalk>().localSignal = false;
        Debug.Log("negat" + numberAnswerNegative);
        if(numberAnswerNegative <= (myCharacterAnswerNegative.Count-1)){
            speechBubbleText.text =  myCharacterAnswerNegative[numberAnswerNegative];
            numberAnswerNegative++;
        }
        if(numberAnswerNegative > (myCharacterAnswerNegative.Count-1)){
            DisableAnswer();
        }         
        DisableButtonsAnswer();
    }
    void Worker0(){
        myCharacterAnswerPositive = characterWords.worker0AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker0AnswerNegative;
        int[] indexAnswer = new int[]{ 1,1,4,0,1};
        switch(DaySystem.day){
            case 1:
                if(placeNumber == 1){
                    Debug.Log("ativar pergunta do dia 1");
                    ActiveButtonsAnswer();
                }
                break;
            case 2:
                if(placeNumber == 1){
                    Debug.Log("ativar pergunta do dia 2");
                    ActiveButtonsAnswer();
                }
                break;
            case 4:
                if(placeNumber == 3){
                    Debug.Log("ativar pergunta do dia 4");
                    ActiveButtonsAnswer();
                }
                break;
            case 5:
                if(placeNumber == 0){
                    Debug.Log("ativar pergunta do dia 5 0");
                    ActiveButtonsAnswer();
                }else if (placeNumber == 3){
                    Debug.Log("ativar pergunta do dia 5 desugnasd");
                    myCharacterAnswerPositive = characterWords.worker0AnswerPositive2Day22;
                    numberAnswerPositive = 0;
                    myCharacterAnswerNegative = characterWords.worker0AnswerNegative2Day22;
                    numberAnswerNegative = 0;
                    ActiveButtonsAnswer();
                }
                break;
        }

    }
    void Worker2(){
        myCharacterAnswerPositive = characterWords.worker2AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker2AnswerNegative;
        if(DaySystem.day == 3 && placeNumber == 2 ){
             Debug.Log("trabalhador 2 dia 3 ou 12");
                ActiveButtonsAnswer();
        }
    }
    void Worker4(){
        myCharacterAnswerPositive = characterWords.worker4AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker4AnswerNegative;
        if(DaySystem.day == 8 && placeNumber == 1 ){
             Debug.Log("trabalhador 4 dia 8 ou 27");
                ActiveButtonsAnswer();
        }
    }
    void Worker5(){
        myCharacterAnswerPositive = characterWords.worker5AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker5AnswerNegative;
        if(count == 0 && placeNumber == 2) {
            Debug.Log("trabalhador 5 todos os dias");
            ActiveButtonsAnswer();
            count++;
        }
        if(count > 0 && placeNumber == 3){
            characterWords.SpecialNight3();
            count = null;
        }
    }
}
