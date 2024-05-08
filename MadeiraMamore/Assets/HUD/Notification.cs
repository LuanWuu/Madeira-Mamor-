using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Notification : MonoBehaviour
{
    [SerializeField] private roadMap roadMapScriptable;
    [SerializeField] private TextMeshProUGUI textNotifi;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private Transform targetPosi;
    private List<string> localList;
    private float localGodScore;
    private float localNormalScore;
    private float localBadScore;
    private int localScore;
    private bool canMoviNoti;
    private bool canBack = false;
    private bool canPause = false;
    private bool canNotify = false;
    private float time;
    private Vector3 iniPosition;
    // Start is called before the first frame update
    void Start()
    {
        localList = roadMapScriptable.chiefScrean;
        localGodScore = rafflequestScript.goodScore;
        localNormalScore = rafflequestScript.normalScore;
        localBadScore = rafflequestScript.badScore;
        textNotifi.text = localList[0];
        iniPosition = transform.position;
        canMoviNoti = true;
        time = 5;
    }
    void StartMoviment(){
        transform.position = Vector3.Lerp(transform.position, targetPosi.position, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPosi.position);
        if(distance <= 3){
            transform.position = targetPosi.position;
            canPause = true;
            canMoviNoti = false;
        }
    }
    IEnumerator PuaseMoviment(){
        canPause = false;
        yield return new WaitForSeconds(time);
        canBack = true;
    }
    void BackMovimente(){
        transform.position = Vector3.Lerp(transform.position,  iniPosition, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, iniPosition);
        if(distance <= 50){
            transform.position = iniPosition;
            canBack = false;
            canNotify = true;
        }
    }
    private void Update() {
        CheckScore();
        if(canMoviNoti == true){
           StartMoviment();
        }
        if(canPause == true){
            StartCoroutine(PuaseMoviment());
        }
        if(canBack == true) {
            BackMovimente();
        } 
    }
    void CheckScore(){
        localScore = (int)rafflequestScript.score;
        if(canNotify == true){
            time = 3;
            if(localGodScore == localScore ){
                Good();
            }else if(localScore == localNormalScore){
                Normal();
            }else if(localScore == localBadScore){
                Bad();
            }
        }
    }
    void Good(){
        canNotify = false;
        textNotifi.text = localList[1];
        canMoviNoti = true;

    }
    void Normal(){
        canNotify = false;
        textNotifi.text = localList[2];
        canMoviNoti = true;
    }
    void Bad(){
        canNotify = false;
        textNotifi.text = localList[3];
        canMoviNoti = true;
    }
}
