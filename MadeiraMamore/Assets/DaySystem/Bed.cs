using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Bed : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    void OnCollisionEnter(Collision collision)
    {
        if(DaySystem.dayTime == "Night"){
            DaySystem.day++;
            DayTCScript.TimeOfDay(0);
            DayTCScript.ChangedDay();
        }
    }
}
