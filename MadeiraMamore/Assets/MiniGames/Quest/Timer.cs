using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [System.NonSerialized] public float timerleft;
    [System.NonSerialized] public bool timerOn;
    [System.NonSerialized] public bool stop;
    [System.NonSerialized] public bool end;
    [SerializeField] private RaffleQuest rafflequestScript;
    [SerializeField] private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(stop == false){ 
            if(timerOn == true){
                if(timerleft > 0){
                    timerleft -= Time.deltaTime;
                    UpdateTimer(timerleft);
                }else{
                    timerleft = 0;
                    end = true;
                    timerOn = false;
                }
            }
            if(end == true) {
                rafflequestScript.EndTime();
                stop = true;
            }
        }
    }
    void UpdateTimer(float currrentTime){
        currrentTime += 1;
        float minutes = Mathf.FloorToInt(currrentTime / 60);
        float seconds = Mathf.FloorToInt(currrentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
