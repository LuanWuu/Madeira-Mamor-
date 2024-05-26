using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;

    void OnCollisionEnter(Collision collision)
    {
        DaySystem.day++;
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        gameObject.SetActive(false);
    }
}
