using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaffleQuest : MonoBehaviour
{
    [Header("Mangers dos minigames")]
    [SerializeField] private CarryMinimage carryScript;
    [SerializeField] private GameObject carryUI;
    [SerializeField] private ManagerDescharge ManagerDesScript;
    [SerializeField] private GameObject DepositUI;
    [Header("Timer")]
    [SerializeField] private GameObject timer;
    [Header("Timer of Carry Minigame")]
    [SerializeField] private float carryTime;
    [Header("Timer of Descharge wagons")]
    [SerializeField] private float deschargeTime;
    [Header("Total Points of time")]
    [SerializeField] private float pointTimeQuest;
    [Header("Nivelamento")]
    public float goodScore;
    public float normalScore;
    public float badScore;
    [Header("Roteiro")]
    [SerializeField] private roadMap roadMapScriptable;
    [System.NonSerialized] public float score;
    [SerializeField] private MensageController mensagControlScrpt;
    [Header("Day time")]
    [SerializeField] private StoragaDayValues DaySystem;
    [Header("Day time")]
    [SerializeField] private Hand handScript;
    private Timer timerScript;
    private int numberMinigame;
    private int beforeNumberMinigame;
    private float timeMinigame = 0;
    // Start is called before the first frame update
    void Start()
    {
        timerScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        score = (timerScript.timerleft * pointTimeQuest)/timeMinigame;
        if(Input.GetKeyDown("v")){
            CompleteQuest();
        }
    }
    public void CompleteQuest(){
        switch(DaySystem.dayTime){
            case "Morning":
                DepositUI.SetActive(false);
                break;
            case "Afternoon":
                carryUI.SetActive(false);
                carryScript.ResetFillWagons();
                break;
            default:
                    break;
        }
        mensagControlScrpt.oneTime = true;
        timerScript.stop = true;
        //Debug.Log("Complete" +  score);
        if(score > goodScore){
            roadMapScriptable.GoodWork();
            //Debug.Log("Complete" +  score);
        }else if(score > badScore){
            roadMapScriptable.MediumWork();
           // Debug.Log("Complete" +  score);
        }else{
            roadMapScriptable.BadWork();
           // Debug.Log("Complete" +  score);
        }
        timer.SetActive(false);
    }
    public void EndTime(){
        Debug.Log("time is over");
        carryUI.SetActive(false);
        carryScript.ResetFillWagons();
        mensagControlScrpt.oneTime = true;
        timerScript.stop = true;
        carryScript.DestroyPackages();
    }
    void Reset(){
        //SceneManager.LoadScene("SecondArea");
    }
    public void DecideQuest(){
         switch(DaySystem.dayTime){
            case "Morning":
                ManagerDesScript.StartMinigame();
                timeMinigame = deschargeTime;
                handScript.takePackage = true;
                Debug.Log(" mornig " + handScript.takePackage);
                break;

            case "Afternoon":
                carryScript.DecideAmoutBox();
                timeMinigame = carryTime;
                handScript.takePackage = false;
                Debug.Log(" Afternoon" + handScript.takePackage);
                break;
            default:
                    break;
        }
        timer.SetActive(true);
        timerScript.timerleft = timeMinigame;
        timerScript.stop = false;
        timerScript.end = false;
    }
    
}
