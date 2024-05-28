using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighthChoses : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private Notification notificationScript;
    [SerializeField] private Bet BetScript;
    [SerializeField] private Transform localToDrink;
    [SerializeField] private Transform player;
    [SerializeField] private Transform tent;
    [SerializeField] private GameObject BetMenu;
    [SerializeField] private GameObject ChosesMenu;

    public void Sleep(){
        DaySystem.day++;
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        playerValues.DisabledCursor();
        player.position = tent.position;
        playerValues.staminaRecuperNight = 60;
        DisableChoses();
    }
    public void Drink(){
        player.position = localToDrink.position;
        notificationScript.Night();
        StartCoroutine(notificationScript.StartMovement());
        playerValues.DisabledCursor();
        playerValues.staminaRecuperNight = 20;
        DisableChoses();
    }
    public void Bet(){
        if(playerValues.money != 0){
            BetMenu.SetActive(true);
            DisableChoses();
        }
    }
    public void BetSleep(){
        BetScript.valueBet = 0;
        BetScript.valueTextBet = 0;
        BetScript.canBet = true;
        player.position = tent.position;
        playerValues.staminaRecuperNight = 30;
        DaySystem.day++;
        BetMenu.SetActive(false);
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        playerValues.DisabledCursor();
    }
    void DisableChoses(){
        ChosesMenu.SetActive(false);
    }
}
