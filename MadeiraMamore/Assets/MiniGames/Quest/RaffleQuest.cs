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
    [Header("Money")]
    [SerializeField] private MoneySystem MoneySystemScript;
    [Header("Roteiro")]
    [SerializeField] private roadMap roadMapScriptable;
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
        if(timerScript.timerleft != 0){
            if(timerScript.timerleft > goodScore){
                roadMapScriptable.GoodWork();
                StartCoroutine( MoneySystemScript.GetSalary(3));
            }else if(timerScript.timerleft  > normalScore){
                roadMapScriptable.MediumWork();
                StartCoroutine( MoneySystemScript.GetSalary(2));
            }else{
                roadMapScriptable.BadWork();
                StartCoroutine( MoneySystemScript.GetSalary(1));
            }
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
        timerScript.timerOn = true;
        timerScript.stop = false;
        timerScript.end = false;
    }
    
}
