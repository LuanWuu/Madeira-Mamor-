using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class DayTimeController : MonoBehaviour
{
    [SerializeField] private CutsceneController cutscene;
    [SerializeField] private DatabaseCutscene database;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private roadMap roadMapController;
    [SerializeField] private MensageController mensageControllerScript;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private Notification notificationScript;
    [SerializeField] private DisableCharacters disableCha;
    [SerializeField] private HammerMinigame hammerScript;
    [SerializeField] private Tutorial TutorialScript;
    [SerializeField] private Malaria malariaScript;
    [SerializeField] private string[] dayTime;
    [SerializeField] private GameObject train;
    [SerializeField] private GameObject DayIcon;
    [SerializeField] private TextMeshProUGUI DayText;
    [SerializeField] private GameObject mornig;
    [SerializeField] private GameObject afternoon;
    [SerializeField] private GameObject night;
    [SerializeField] private GameObject chuva;
    [SerializeField] private GameObject mosquito;
    [SerializeField] private GameObject Baltasar;
    [SerializeField] private GameObject FoodIcon;
    [SerializeField] private GameObject terNormal;
    [SerializeField] private GameObject terLandslide;
    [SerializeField] private GameObject terAfterLandslide;

    void Awake()
    {
        DaySystem.day = 1;
        DaySystem.dayTime = "Morning";
        ChangedDay();
        roadMapController.NotWords();
        roadMapController.ChefWords();
        //StartCoroutine(DayAnimator());
    }

    public IEnumerator DayAnimator(){
        DayIcon.SetActive(true);
        yield return new WaitForSeconds(4);
        DayIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l")){
            DaySystem.day++;
            ChangedDay();
        }
        if (Input.GetKeyDown("u")){
            TimeOfDay(3);
        }
    }
    public void TimeOfDay(int moment){
        for(int i = 0; i < dayTime.Length; i++) {
            if(i == moment) {
                DaySystem.dayTime = dayTime[i];
                break;
            }
        }
        switch(DaySystem.dayTime){
            case "Morning":  
                cutscene.MuteMusic(true);
                DayText.text = "Primeiro turno";          
                train.SetActive(true);
                roadMapController.ChefWords();
                mornig.SetActive(true);
                night.SetActive(false);
                Baltasar.SetActive(true);
                if(DaySystem.day == 1 || DaySystem.day == 6) {
                    TutorialScript.Active();
                }else{
                    cutscene.PlayVideo(database.transition);
                }
                break;
            case "Lunch":    
                DayText.text = "Almoço";
                notificationScript.PanIcon();
                FoodIcon.SetActive(true);
                playerValues.canOpenFoodMenu = true;
                StartCoroutine(notificationScript.StartMovement());
                cutscene.MuteMusic(false);
                cutscene.MusicAmbiente(database.lunchMoment);
                cutscene.PlayVideo(database.transition);                     
                roadMapController.ChefWords();
                break;
            case "Afternoon":
                cutscene.MuteMusic(true);
                DayText.text = "Segundo turno"; 
                mornig.SetActive(false);
                afternoon.SetActive(true);
                if(DaySystem.day == 1) {
                    TutorialScript.Active();
                }else{
                    cutscene.PlayVideo(database.transition);
                }
                break;
            case "Night":
                DayText.text = "Noite"; 
                cutscene.MuteMusic(true);
                cutscene.MusicAmbiente(database.night);   
                cutscene.SoundEffect(database.Trem);
                if(DaySystem.day != 7) {
                   train.SetActive(false); 
                   Baltasar.SetActive(false);
                }else{
                    hammerScript.DestroyTree();
                }
                roadMapController.ChefOrders();
                afternoon.SetActive(false);
                night.SetActive(true);
                cutscene.PlayVideo(database.transition);
                break;
            default:
                    break;
        }
    }
    public void ChangedDay(){
        notificationScript.BaseNotifi();
        mensageControllerScript.moment = 0;
        mensageControllerScript.RestNameList();
        mensageControllerScript.PickWorkerWords();
        switch(DaySystem.day){
            case 1://1
                cutscene.PlayVideo(database.cutscene1);
                roadMapController.InitializeWorkerTalkDay1();
                DayText.text = "Dia " + DaySystem.OrderDay[0].ToString();
                break;
            case 2://2
                cutscene.PlayVideo(database.transition);
                mosquito.SetActive(true);
                roadMapController.InitializeWorkerTalkDay2();
                DayText.text = "Dia " + DaySystem.OrderDay[1].ToString();
                break;
            case 3://12
                cutscene.PlayVideo(database.cutscene2);
                roadMapController.InitializeWorkerTalkDay12();
                DayText.text = "Dia " + DaySystem.OrderDay[2].ToString();
                break;
            case 4://20
                disableCha.DisableDia4();
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay20();
                DayText.text = "Dia " + DaySystem.OrderDay[3].ToString();
                break;
            case 5://22
                disableCha.DisableDia5();
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay22();
                DayText.text = "Dia " + DaySystem.OrderDay[4].ToString();
                break;
            case 6://25
                hammerScript.EnabledTree();
                disableCha.DisableDia6();
                cutscene.PlayVideo(database.transition);
                chuva.SetActive(true);
                cutscene.SecondeSoundEffect(database.Chuva);
                terLandslide.SetActive(true);
                terNormal.SetActive(false);
                roadMapController.InitializeWorkerTalkDay25();
                DayText.text = "Dia " + DaySystem.OrderDay[5].ToString();
                break;
            case 7://26
                playerValues.moveSpeed = 400;
                cutscene.PlayVideo(database.transition);
                cutscene.SecondeSoundEffect(database.Chuva);
                roadMapController.InitializeWorkerTalkDay26();
                StartCoroutine(malariaScript.lowMalaria());
                DayText.text = "Dia " + DaySystem.OrderDay[6].ToString();
                break;
            case 8://27
                playerValues.moveSpeed = 200;
                terLandslide.SetActive(false);
                terAfterLandslide.SetActive(true);
                cutscene.SecondeSoundEffect(database.Chuva);
                cutscene.PlayVideo(database.transition);
                StartCoroutine(malariaScript.HighMalaria());
                roadMapController.InitializeWorkerTalkDay27();
                DayText.text = "Dia " + DaySystem.OrderDay[7].ToString();
                break;
            case 9://30 
                cutscene.SecondeSoundEffect(database.Chuva);
                malariaScript.DeadMalaria();
                DayText.text = "Dia " + DaySystem.OrderDay[8].ToString();
                break;
            default:
                break;
        }
        cutscene.SoundEffect(database.Alarm);
        
    }
    public void EndGame(){
        database.chosenEnding = database.end1;
        SceneManager.LoadScene("EndGame");
    }
    public void EndGameSeringueiro(){
        database.chosenEnding = database.end3;
        SceneManager.LoadScene("EndGame");
    }
     public void EndGameEscape(){
        database.chosenEnding = database.end2;
        SceneManager.LoadScene("EndGame");
    }
}
