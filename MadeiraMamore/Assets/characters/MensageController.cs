using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class MensageController : MonoBehaviour
{
    public List<string> characterNames;
    [SerializeField] private List<string> characterFullName;
    [SerializeField] private roadMap characterWords;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private TextMeshProUGUI speechBubbleText;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject buttonPositive;
    [SerializeField] private GameObject buttonNegative;
    [SerializeField] private GameObject escapeButton;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private MoneySystem MoneySystemScript;
    [SerializeField] private NighthChoses nightChoseScript;
    [SerializeField] private TextMeshProUGUI nameCharacter;

    int numeberOfWorker;
    int placeNumber;
    int numberAnswerPositive;
    int numberAnswerNegative;
    [System.NonSerialized] public int moment = 0;
    [System.NonSerialized] public bool oneTime = true;
    private List<string> myCharacterlist;
    private List<string> myCharacterAnswerPositive;
    private List<string> myCharacterAnswerNegative;
    private List<string> localPlayerAnswers;
    private List<string>[] speechesOfDay;
    private List<string> saveNameList = new List<string>();

    private bool seringueiraFinal = true;
    private bool haveAnswer = false;
    private int firstTime = 0;

    [SerializeField] private ButtonPlayerTalk posiButton;
    [SerializeField] private ButtonPlayerTalk negaButton;

    private void Start() {
         DisableAnswer();
    }
    public void RestNameList(){
        //if (saveNameList.Count > 0) {
            saveNameList.Clear();
        //}
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
    
    public void GiveTalk(string name){
        if(!saveNameList.Contains(name)){
            for(int i = 0; i < characterNames.Count; i++) {
                if(name == characterNames[i]){
                    nameCharacter.text = characterFullName[i];
                    saveNameList.Add(name);
                    numeberOfWorker = i;
                    Senteces();
                    break;
                }
            }   
        }    
    }
    void Senteces(){
        scriptTableValues.canMovi = false;
        speechBubble.SetActive(true);
        scriptTableValues.EnabledCursor();
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
    public void LimitBarrier(){
        nameCharacter.text = characterFullName[7];
        placeNumber = 0;  
        scriptTableValues.canMovi = false;
        speechBubble.SetActive(true);
        scriptTableValues.EnabledCursor();
        numeberOfWorker = 7;
        myCharacterlist = characterWords.guard;
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
            scriptTableValues.canMovi = true;
            speechBubble.SetActive(false);
            scriptTableValues.DisabledCursor();
            if(numeberOfWorker == 6){
                if(moment <4){
                    Chief();
                }else if(DaySystem.dayTime == "Night" && DaySystem.day == 7){
                    nightChoseScript.Sleep();
                }
            }
            if(numeberOfWorker == 5 && firstTime == 3){
                Invoke("EndGameSeringueiro", 1f);    
            }
            if(scriptTableValues.dontFineshed == true) {
                scriptTableValues.dontFineshed = false;
                scriptTableValues.canMoviCamera = true;
                scriptTableValues.canMovi = true;
            }
        }
    }
    void Chief(){
        DayTCScript.TimeOfDay(moment);
        if(DaySystem.dayTime == "Lunch"){
            RestNameList();
        }
        if ((DaySystem.day != 7 && (DaySystem.dayTime == "Afternoon" || DaySystem.dayTime == "Morning")) ||
        (DaySystem.day == 7 && (DaySystem.dayTime == "Afternoon" || DaySystem.dayTime == "Morning" || DaySystem.dayTime == "Night"))){
            
            rafflequestScript.DecideQuest();
            oneTime = false;
        }
        moment++; 
    }
    void EndGameSeringueiro(){
        DayTCScript.EndGameSeringueiro();
    }
    void GetIndexOfList(){
        switch(numeberOfWorker){
            case 0://1
                Worker0();
                break;
            case 2://3
                Worker2();
                break;
            case 4://5
                Worker4();
                break;
            case 5://6
                if(DaySystem.dayTime == "Night"){
                    Worker5();
                }
                break;
            default:
                break;
        }
    }
    void ActiveButtonsAnswer(){
        nextButton.SetActive(false);
        buttonPositive.SetActive(true);
        buttonNegative.SetActive(true);
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
        if(numeberOfWorker == 5){
            seringueiraFinal = false;
        }
        DisableButtonsAnswer();
    }
    void GivePlayerAnswer(List<string> give){
        posiButton.PlayerAnswersButtons(give);
        negaButton.PlayerAnswersButtons(give);
    }
    void Worker0(){//Assis tem final
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
            case 5:// puxar final
                escapeButton.SetActive(true);
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
    void Worker5(){//O fodao
        myCharacterAnswerPositive = characterWords.worker5AnswerPositive;
        myCharacterAnswerNegative = characterWords.worker5AnswerNegative;
        if(seringueiraFinal == true && placeNumber == 0){
            switch(firstTime % 3){
            case 0:
                characterWords.SpecialNight1();
                haveAnswer = true;
                break;
            case 1:
                characterWords.SpecialNight2();
                break;
            case 2:
                characterWords.SpecialNight3();
                break;
            }
            firstTime++;
        }
        if(seringueiraFinal == false){
            //frase generica
            characterWords.Rejected();
        }
        myCharacterlist = characterWords.workerSpecial;
        if(haveAnswer == true && placeNumber == 2) {
            ActiveButtonsAnswer();
            GivePlayerAnswer(characterWords.playerAnswers[5]);
            haveAnswer = false;
        }
    }
}
