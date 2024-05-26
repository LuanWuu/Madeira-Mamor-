using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Bed : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private StaminaSystem staminaController;
    [SerializeField] private VideoPlayer videoPlayer;
    void OnCollisionEnter(Collision collision)
    {
        if(DaySystem.dayTime == "Night"){
            DaySystem.day++;
            DayTCScript.TimeOfDay(0);
            DayTCScript.ChangedDay();
            videoPlayer.loopPointReached += OnVideoEnd;
        }
    }
    void OnVideoEnd(VideoPlayer vp){
        staminaController.IncreaseStamina(20);
    }
}
