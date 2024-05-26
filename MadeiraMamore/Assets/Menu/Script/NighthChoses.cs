using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighthChoses : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private Transform localToDrink;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject BetMenu;
    public void Sleep(){
        DaySystem.day++;
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        DisableChoses();
    }
    public void Drink(){

        Debug.Log("beber");
        DisableChoses();
    }
    public void Bet(){

        Debug.Log("Bet");
        DisableChoses();
    }
    void DisableChoses(){
        gameObject.SetActive(false);
    }
}
