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
    [SerializeField] private GameObject mornig;
    [SerializeField] private GameObject afternoon;
    [SerializeField] private GameObject night;
    [SerializeField] private TextMeshProUGUI DayText;
    [SerializeField] private GameObject chuva;

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
        for(int i = 0; i < dayTime.Length; i++) {
            if(i == moment) {
                DaySystem.dayTime = dayTime[i];
                break;
            }
        }
        switch(DaySystem.dayTime){
            case "Morning": 
                cutscene.GiveAmbianceSound(database.ambiance);              
                train.SetActive(true);
                roadMapController.ChefWords();
                mornig.SetActive(true);
                afternoon.SetActive(false);
                night.SetActive(false);
                break;
            case "Lunch":              
                roadMapController.ChefWords();
                break;
            case "Afternoon":
                cutscene.PlayVideo(database.transition);
                mornig.SetActive(false);
                afternoon.SetActive(true);
                night.SetActive(false);
                break;
            case "Night":
                cutscene.PlayVideo(database.transition);
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
        mensageControllerScript.moment = 0;
        mensageControllerScript.RestNameList();
        switch(DaySystem.day){
            case 1:
                cutscene.PlayVideo(database.cutscene1);
                roadMapController.InitializeWorkerTalkDay1();
                DayText.text = "Dia " + DaySystem.OrderDay[0].ToString();
                break;
            case 2:
                cutscene.GiveAmbianceSound(database.Mosquito);
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay2();
                DayText.text = "Dia " + DaySystem.OrderDay[1].ToString();
                break;
            case 3:
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
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay22();
                DayText.text = "Dia " + DaySystem.OrderDay[4].ToString();
                break;
            case 6:
                cutscene.GiveAmbianceSound(database.workSound);
                cutscene.PlayVideo(database.transition);
                chuva.SetActive(false);
                roadMapController.InitializeWorkerTalkDay25();
                DayText.text = "Dia " + DaySystem.OrderDay[5].ToString();
                break;
            case 7:
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay26();
                DayText.text = "Dia " + DaySystem.OrderDay[6].ToString();
                break;
            case 8:
                cutscene.PlayVideo(database.transition);
                roadMapController.InitializeWorkerTalkDay27();
                DayText.text = "Dia " + DaySystem.OrderDay[7].ToString();
                break;
            case 9:
                cutscene.PlayVideo(database.end1);
                DayText.text = "Dia " + DaySystem.OrderDay[8].ToString();
                Invoke("EndGame", 30);
                break;
            default:
                break;
        }
 
        mensageControllerScript.PickWorkerWords();
        cutscene.SoundEffect(database.Alarm);
        
    }
    void EndGame(){
        SceneManager.LoadScene("EndGame");
    }
}
