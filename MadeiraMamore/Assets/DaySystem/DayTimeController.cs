using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayTimeController : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Awake()
    {
        DaySystem.day = 1;
        ChangedDay();
        TimeOfDay(0);
        roadMapController.SpecialNight1();
        roadMapController.NotWords();
        roadMapController.ChefWords();
        StartCoroutine(DayAnimator());
    }
    IEnumerator DayAnimator(){
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
                //chamar as cutscene transiçao
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
                mornig.SetActive(false);
                afternoon.SetActive(true);
                night.SetActive(false);
                break;
            case "Night":
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
        switch(DaySystem.day){
            case 1:
                roadMapController.InitializeWorkerTalkDay1();
                DayText.text = "Dia " + DaySystem.OrderDay[0].ToString();
                break;
            case 2:
                roadMapController.InitializeWorkerTalkDay2();
                DayText.text = "Dia " + DaySystem.OrderDay[1].ToString();
                break;
            case 3:
                roadMapController.InitializeWorkerTalkDay12();
                DayText.text = "Dia " + DaySystem.OrderDay[2].ToString();
                break;
            case 4:
                roadMapController.InitializeWorkerTalkDay20();
                DayText.text = "Dia " + DaySystem.OrderDay[3].ToString();
                break;
            case 5:
                roadMapController.InitializeWorkerTalkDay22();
                DayText.text = "Dia " + DaySystem.OrderDay[4].ToString();
                break;
            case 6:
                roadMapController.InitializeWorkerTalkDay25();
                DayText.text = "Dia " + DaySystem.OrderDay[5].ToString();
                break;
            case 7:
                roadMapController.InitializeWorkerTalkDay26();
                DayText.text = "Dia " + DaySystem.OrderDay[6].ToString();
                break;
            case 8:
                roadMapController.InitializeWorkerTalkDay27();
                DayText.text = "Dia " + DaySystem.OrderDay[7].ToString();
                break;
            case 9:
                DayText.text = "Dia " + DaySystem.OrderDay[8].ToString();
                Invoke("EndGame", 2);
                break;
            default:
                break;
        }
 
        mensageControllerScript.PickWorkerWords();
        
        StartCoroutine(DayAnimator());
    }
    void EndGame(){
        SceneManager.LoadScene("EndGame");
    }
}
