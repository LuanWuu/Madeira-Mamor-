using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighthChoses : MonoBehaviour
{
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private DayTimeController DayTCScript;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StaminaSystem staminaController;
    [SerializeField] private Transform localToDrink;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject BetMenu;

    public void Sleep(){
        DaySystem.day++;
        DayTCScript.TimeOfDay(0);
        DayTCScript.ChangedDay();
        playerValues.DisabledCursor();
        staminaController.IncreaseStamina(60);
        DisableChoses();
    }
    public void Drink(){

        Debug.Log("beber");
        playerValues.DisabledCursor();
        staminaController.IncreaseStamina(20);
        DisableChoses();
    }
    public void Bet(){

        Debug.Log("Bet");
        staminaController.IncreaseStamina(30);
        DisableChoses();
    }
    void DisableChoses(){
        gameObject.SetActive(false);
    }
}
