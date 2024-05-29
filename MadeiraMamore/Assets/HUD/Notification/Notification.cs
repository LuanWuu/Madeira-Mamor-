using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField] private roadMap roadMapScriptable;
    [SerializeField] private TextMeshProUGUI textNotifi;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private Timer timerScript;
    [SerializeField] private GameObject iconChef;
    [SerializeField] private GameObject iconFood;
    [SerializeField] private GameObject iconBed;
    [SerializeField] private Animator animatorController;
    [SerializeField] private float time;
    [System.NonSerialized] public bool canNotify;
    private List<string> localList;
    private float localGodScore;
    private float localNormalScore;
    private float localBadScore;
    private int localScore;
    // Start is called before the first frame update
    void Start()
    {
        BaseNotifi();
    }
    public void GetValues(float good, float normal, float bad){
        localGodScore = good;
        localNormalScore = normal;
        localBadScore = bad;
    }
    public void BaseNotifi(){
        localList = roadMapScriptable.chiefScrean;
        textNotifi.text = localList[0];
        ChefIcon();
    }
    public IEnumerator StartMovement(){
        animatorController.SetBool("canMovi", true);
        yield return new WaitForSeconds(time);
        animatorController.SetBool("canMovi", false);
    }

    private void Update(){
        if(canNotify == true){
            CheckScore();      
        }           
    }
    void CheckScore(){
        localScore = (int)timerScript.timerleft;
        if(localGodScore == localScore){
            Good();
        }else if(localScore == localNormalScore){
            Normal();
        }else if(localScore == localBadScore){
            Bad();
        }
    }
    public void Night(){
        iconChef.SetActive(false);
        iconBed.SetActive(true);
        textNotifi.text = "Vá para a cama, amanhã se terá um longo dia";
    }
    public void Reward(){
        ChefIcon();
        textNotifi.text = "Fale comigo para receber o pagamento";
    }
    public void Instructions(){
        ChefIcon();
        textNotifi.text = "Use 'TAB' para acessar a lista de afazeres";
    }
    public void PanIcon(){
        iconChef.SetActive(false);
        iconFood.SetActive(true);
        if(DaySystem.day != 6 || DaySystem.day != 7) {
            textNotifi.text = "Hora do almoço: vá até o refeitório para comer";
        }else{
            textNotifi.text = "Hora do almoço: vá até o refeitório para comer, refeição media gratuita";
        }
    }
    void ChefIcon(){
        iconChef.SetActive(true);
        iconFood.SetActive(false);
        iconBed.SetActive(false);
    }
    void Good(){
        ChefIcon();
        textNotifi.text = localList[1];
        StartCoroutine(StartMovement());
    }
    void Normal(){
        ChefIcon();
        textNotifi.text = localList[2];
        StartCoroutine(StartMovement());
    }
    void Bad(){
        ChefIcon();
        textNotifi.text = localList[3];
        StartCoroutine(StartMovement());
    }
}
