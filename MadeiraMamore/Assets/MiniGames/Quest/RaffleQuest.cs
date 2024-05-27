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
    [SerializeField] private DeschargeMinigame[] descharger;
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
    [Header("Positions Dont Finished Game")]
    [SerializeField] private Transform DontFinishPosi;
    [SerializeField] private Transform player;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
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
            EndTime();
        }
    }
    public void CompleteQuest(){
        mensagControlScrpt.RestNameList();
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
    public void NoStamina(){
        roadMapScriptable.DontStamina();
        DesableMinigame();
    }
    public void EndTime(){
        roadMapScriptable.DontFinishWork();
        DesableMinigame();
    }
    void  DesableMinigame(){
        mensagControlScrpt.RestNameList();
        mensagControlScrpt.oneTime = true;
        timerScript.stop = true;
        timer.SetActive(false);
        ManagerDesScript.Reset();
        scriptTableValues.dontFineshed = true;
        scriptTableValues.canMovi = false;
        player.position =  DontFinishPosi.position;
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
            default:
                    break;
        }
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
                break;

            case "Afternoon":
                carryScript.DecideAmoutBox();
                timeMinigame = carryTime;
                handScript.takePackage = false;
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
