using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaffleQuest : MonoBehaviour
{
    [Header("Mangers dos minigames")]
    [SerializeField] private CarryMinimage carryScript;
    [SerializeField] private GameObject carryUI;
    [SerializeField] private ManagerDescharge ManagerDesScript;
    [SerializeField] private GameObject DepositUI;
    [SerializeField] private HammerMinigame hammerScript;
    [SerializeField] private DeschargeMinigame[] descharger;

    [Header("Timer")]
    [SerializeField] private GameObject timer;

    [Header("Timer of Carry Minigame")]

    [SerializeField] private float carryTime;

    [Header("Timer of Descharge wagons")]
    [SerializeField] private float deschargeTime;

    [Header("Timer of Broken Tree")]
    [SerializeField] private float axeTime;

    [Header("Nivelamento Carry")]
    [SerializeField] private float carryGoodTime;
    [SerializeField] private float carryNormalTime;
    [SerializeField] private float carryBadTime;

    [Header("Nivelamento Axe")]
    [SerializeField] private float axeGoodTime;
    [SerializeField] private float axeNormalTime;
    [SerializeField] private float axeBadTime;

    [Header("Nivelamento Descharge")]
    [SerializeField] private float deschargerGoodTime;
    [SerializeField] private float deschargerNormalTime;
    [SerializeField] private float deschargerBadTime;

    [Header("Total Points of time")]
    [SerializeField] private float pointTimeQuest;

    [Header("Money")]
    [SerializeField] private MoneySystem MoneySystemScript;

    [Header("Roteiro")]
    [SerializeField] private roadMap roadMapScriptable;
    [SerializeField] private MensageController mensagControlScrpt;

    [Header("Day time")]

    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;

    [SerializeField] private Hand handScript;
    [Header("Positions Dont Finished Game")]

    [SerializeField] private Transform DontFinishPosi;
    [SerializeField] private Transform player;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [Header("Notification")]

    [SerializeField] private Notification notificationScript;
    [System.NonSerialized] public int salary;
    [System.NonSerialized] public bool fineshed;


    private Timer timerScript;
    private int numberMinigame;
    private int beforeNumberMinigame;
    private float timeMinigame = 0;
    private float goodScore;
    private float normalScore;
    private float badScore;
    // Start is called before the first frame update
    void Start()
    {
        timerScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("v")){
            EndTime();
        }
    }
    public void CompleteQuest(){
        notificationScript.Reward();
        StartCoroutine(notificationScript.StartMovement());
        mensagControlScrpt.RestNameList();
        fineshed = true;
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
        if(timerScript.timerleft != 0){
            if(timerScript.timerleft > goodScore){
                roadMapScriptable.GoodWork();
                salary = 3;
            }else if(timerScript.timerleft  > normalScore){
                roadMapScriptable.MediumWork();
                salary = 2;
            }else{
                roadMapScriptable.BadWork();
                salary = 1;
            }
        }
        scriptTableValues.salary = salary;
        notificationScript.canNotify = false;
        timer.SetActive(false);
    }
    public void NoStamina(){
        roadMapScriptable.DontStamina();
        DesableMinigame();
    }
    public void EndTime(){
        roadMapScriptable.DontFinishWork();
        DesableMinigame();
    }
    void  DesableMinigame(){
        salary = 0;
        mensagControlScrpt.RestNameList();
        mensagControlScrpt.oneTime = true;
        fineshed = true;
        timerScript.stop = true;
        timer.SetActive(false);
        ManagerDesScript.Reset();
        scriptTableValues.dontFineshed = true;
        scriptTableValues.canMovi = false;
        player.position =  DontFinishPosi.position;
        notificationScript.canNotify = false;
        switch(DaySystem.dayTime){
            case "Morning":
                ManagerDesScript.Reset();
                DepositUI.SetActive(false);
                handScript.takePackage = false;
                for(int i = 0; i < descharger.Length; i++) {
                   descharger[i].Reset();
                }
                break;
            case "Afternoon":
                carryUI.SetActive(false);
                carryScript.ResetFillWagons();
                carryScript.DestroyPackages();
                break;
            case "Night":
                carryUI.SetActive(false);
                carryScript.ResetFillWagons();
                carryScript.DestroyPackages();
                break;
            default:
                    break;
        }
        Invoke("NeedDestroy", 1.5f);
    }
    void NeedDestroy(){
        GameObject[] ObjectsRemaining = GameObject.FindGameObjectsWithTag("CloneBox");
        if(ObjectsRemaining != null) {
            for(int i = 0; i < ObjectsRemaining.Length; i++) {
                if(ObjectsRemaining[i] != null) {
                    Destroy(ObjectsRemaining[i]);
                }
            }
        }
    }
    void Reset(){
        //SceneManager.LoadScene("SecondArea");
    }
    public void DecideQuest(){
        if(DaySystem.day == 6 || DaySystem.day == 7){
            if(DaySystem.dayTime == "Night") {
                carryScript.DecideAmoutBox();
                handScript.takePackage = false;
                DecideEvaluation(deschargerGoodTime,deschargerNormalTime,deschargerBadTime, deschargeTime);
            }else{
                hammerScript.StartMinigame();
                DecideEvaluation(axeGoodTime, axeBadTime, axeBadTime,axeTime);
            }
        }else{
            switch(DaySystem.dayTime){
                case "Morning":
                    ManagerDesScript.StartMinigame();
                    handScript.takePackage = true;
                    DecideEvaluation(deschargerGoodTime,deschargerNormalTime,deschargerBadTime,deschargeTime);
                    break;

                case "Afternoon":
                    carryScript.DecideAmoutBox();
                    handScript.takePackage = false;
                    DecideEvaluation(carryGoodTime, carryNormalTime, carryBadTime,carryTime);
                    break;
                default:
                        break;
            }
        }
        fineshed = false;
        salary = 0;
        notificationScript.Instructions();
        notificationScript.canNotify = true;
        StartCoroutine(notificationScript.StartMovement());
        if(DaySystem.day == 9) {
            Invoke("EndGame", 40);
        }
    }
    void DecideEvaluation(float good, float normal, float bad, float time){
        goodScore = good;
        normalScore = normal;
        badScore = bad;
        timeMinigame = time;
        timer.SetActive(true);
        timerScript.timerleft = timeMinigame;
        timerScript.timerOn = true;
        timerScript.stop = false;
        timerScript.end = false;
        notificationScript.GetValues(good, normal, bad);
    }
    void EndGame(){
        DayTCScript.EndGame();
    }
}
