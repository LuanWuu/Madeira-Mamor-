using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField] private roadMap roadMapScriptable;
    [SerializeField] private TextMeshProUGUI textNotifi;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private Timer timerScript;
    [SerializeField] private Transform targetPosi;
    [SerializeField] private GameObject iconChef;
    [SerializeField] private GameObject iconFood;
    [SerializeField] private float time;
    private List<string> localList;
    private float localGodScore;
    private float localNormalScore;
    private float localBadScore;
    private int localScore;
    private bool isNotify;
    private bool canNotify;
    private Vector3 iniPosition;
    // Start is called before the first frame update
    void Start()
    {
        localGodScore = rafflequestScript.goodScore;
        localNormalScore = rafflequestScript.normalScore;
        localBadScore = rafflequestScript.badScore;
        iniPosition = transform.position;
        StartCoroutine(BaseNotifi());
    }
    IEnumerator BaseNotifi(){
        localList = roadMapScriptable.chiefScrean;
        textNotifi.text = localList[0];
        while(Vector3.Distance(transform.position, targetPosi.position) >=3){
            transform.position = Vector3.Lerp(transform.position, targetPosi.position, 2 * Time.deltaTime);
            yield return new WaitForSeconds(0.25f); 
        }
        transform.position = targetPosi.position;
    }
    public IEnumerator StartMoviment(){
        while(Vector3.Distance(transform.position, targetPosi.position) >=3){
            transform.position = Vector3.Lerp(transform.position, targetPosi.position, 2 * Time.deltaTime);
            yield return new WaitForSeconds(0.25f); 
        }
        transform.position = targetPosi.position;
        StartCoroutine(PuaseMoviment());
    }
    IEnumerator PuaseMoviment(){
        yield return new WaitForSeconds(time);
        StartCoroutine(BackMovimente());
    }
    public IEnumerator BackMovimente(){
        while(Vector3.Distance(transform.position, iniPosition) >= 50){
            transform.position = Vector3.Lerp(transform.position,  iniPosition, 2 * Time.deltaTime);    
            yield return new WaitForSeconds(0.25f);       
        }
        transform.position = iniPosition;
        canNotify = true;
    }
    private void Update(){
        if(canNotify == true){
            CheckScore();      
        }           
    }
    void CheckScore(){
        localScore = (int)timerScript.timerleft;
        if(localGodScore == localScore){
            StartCoroutine(Good());
        }else if(localScore == localNormalScore){
            StartCoroutine(Normal());
        }else if(localScore == localBadScore){
            StartCoroutine(Bad());
        }
    }
    public void PanIcon(){
        iconChef.SetActive(false);
        iconFood.SetActive(true);
        textNotifi.text = "Hora do almoço: vá até o refeitório para comer";
    }
    void ChefIcon(){
        iconChef.SetActive(true);
        iconFood.SetActive(false);
    }
    IEnumerator Good(){
        canNotify = false;
        ChefIcon();
        textNotifi.text = localList[1];
        isNotify = false;
        if(isNotify == false){
           StartCoroutine(StartMoviment());
        }else{
            yield return StartCoroutine(BackMovimente());
            yield return StartCoroutine(StartMoviment());
        }
        isNotify = true;
    }
    IEnumerator Normal(){
        canNotify = false;
        ChefIcon();
        textNotifi.text = localList[2];
        if(isNotify == false){
           StartCoroutine(StartMoviment());
        }else{
            yield return StartCoroutine(BackMovimente());
            yield return StartCoroutine(StartMoviment());
        }
        isNotify = true;
    }
    IEnumerator Bad(){
        canNotify = false;
        ChefIcon();
        textNotifi.text = localList[3];
        if(isNotify == false){
           StartCoroutine(StartMoviment());
        }else{
            yield return StartCoroutine(BackMovimente());
            yield return StartCoroutine(StartMoviment());
        }
        isNotify = true;
    }
}
