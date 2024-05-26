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
    [SerializeField] private string[] dayTime;
    [SerializeField] private GameObject train;
    [SerializeField] private GameObject bed;
    [SerializeField] private GameObject DayIcon;
    [SerializeField] private TextMeshProUGUI DayText;
    [SerializeField] private GameObject mornig;
    [SerializeField] private GameObject afternoon;
    [SerializeField] private GameObject night;
    [SerializeField] private GameObject chuva;
    [SerializeField] private GameObject mosquito;

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
        if(Input.GetKeyDown("j")){
                  Debug.Log("DaySystem.dayTime " + DaySystem.dayTime);  
        }
    }
    public void TimeOfDay(int moment){
        Debug.Log("mommente");
        cutscene.PlayVideo(database.transition);
        for(int i = 0; i < dayTime.Length; i++) {
            if(i == moment) {
                DaySystem.dayTime = dayTime[i];
                break;
            }
        }
        switch(DaySystem.dayTime){
            case "Morning":  
                DayText.text = "Periodo do dia: " + "Primeiro turno";
                cutscene.GiveAmbianceSound(database.workSound);            
                train.SetActive(true);
                roadMapController.ChefWords();
                mornig.SetActive(true);
                afternoon.SetActive(false);
                night.SetActive(false);
                break;
            case "Lunch":    
                DayText.text = "Periodo do dia: " + "Almoço"; 
                cutscene.GiveAmbianceSound(database.lunchMoment);                     
                roadMapController.ChefWords();
                break;
            case "Afternoon":
                DayText.text = "Periodo do dia: " + "Segundo turno"; 
                cutscene.GiveAmbianceSound(database.workSound);
                mornig.SetActive(false);
                afternoon.SetActive(true);
                night.SetActive(false);
                break;
            case "Night":
                DayText.text = "Periodo do dia: " + "Noite"; 
                cutscene.GiveAmbianceSound(database.night);   
                cutscene.SoundEffect(database.Trem);
                train.SetActive(false);
                roadMapController.ChefOrders();
                bed.SetActive(true);
                mornig.SetActive(false);
                afternoon.SetActive(false);
                night.SetActive(true);
                break;
            default:
                    break;
        }
    }
    public void ChangedDay(){
        Debug.Log("changeaday");
        mensageControllerScript.moment = 0;
        mensageControllerScript.RestNameList();
        switch(DaySystem.day){
            case 1:
                cutscene.GiveAmbianceSound(database.ambiance);
                cutscene.PlayVideo(database.cutscene1);
                roadMapController.InitializeWorkerTalkDay1();
                DayText.text = "Dia " + DaySystem.OrderDay[0].ToString();
                break;
            case 2:
                mosquito.SetActive(true);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay2();
                DayText.text = "Dia " + DaySystem.OrderDay[1].ToString();
                break;
            case 3:
                mosquito.SetActive(false);
                cutscene.GiveAmbianceSound(database.ambiance);
                cutscene.PlayVideo(database.cutscene2);
                roadMapController.InitializeWorkerTalkDay12();
                DayText.text = "Dia " + DaySystem.OrderDay[2].ToString();
                break;
            case 4:
                cutscene.GiveAmbianceSound(database.Chuva);
                chuva.SetActive(true);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay20();
                DayText.text = "Dia " + DaySystem.OrderDay[3].ToString();
                break;
            case 5:
                cutscene.GiveAmbianceSound(database.Chuva);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay22();
                DayText.text = "Dia " + DaySystem.OrderDay[4].ToString();
                break;
            case 6:
                cutscene.GiveAmbianceSound(database.ambiance);
                cutscene.PlayVideo(database.transition);
                chuva.SetActive(false);
                roadMapController.InitializeWorkerTalkDay25();
                DayText.text = "Dia " + DaySystem.OrderDay[5].ToString();
                break;
            case 7:
                cutscene.GiveAmbianceSound(database.ambiance);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay26();
                DayText.text = "Dia " + DaySystem.OrderDay[6].ToString();
                break;
            case 8:
                cutscene.GiveAmbianceSound(database.ambiance);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay27();
                DayText.text = "Dia " + DaySystem.OrderDay[7].ToString();
                break;
            case 9:
                DayText.text = "Dia " + DaySystem.OrderDay[8].ToString();
                Invoke("EndGame", 5);
                break;
            default:
                break;
        }
 
        mensageControllerScript.PickWorkerWords();
        cutscene.SoundEffect(database.Alarm);
        
    }
    void EndGame(){
        database.chosenEnding = database.end1;
        SceneManager.LoadScene("EndGame");
    }
    public void EndGameSeringueiro(){
        database.chosenEnding = database.end3;
        SceneManager.LoadScene("EndGame");
    }
}
