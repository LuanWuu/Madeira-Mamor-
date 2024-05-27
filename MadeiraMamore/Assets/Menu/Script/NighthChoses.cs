using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighthChoses : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StaminaSystem staminaController;
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
        staminaController.IncreaseStamina(60);
        DisableChoses();
    }
    public void Drink(){
        player.position = localToDrink.position;
        playerValues.DisabledCursor();
        staminaController.IncreaseStamina(20);
        DisableChoses();
    }
    public void Bet(){
        BetMenu.SetActive(true);
        staminaController.IncreaseStamina(30);
        DisableChoses();
    }
    public void BetSleep(){
        BetScript.valueBet = 0;
        BetScript.valueTextBet = 0;
        player.position = tent.position;
        BetMenu.SetActive(false);
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        playerValues.DisabledCursor();
    }
    void DisableChoses(){
        ChosesMenu.SetActive(false);
    }
}
