using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenu : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private StaminaSystem staminaScript;
    [SerializeField] private MoneySystem moneyScript;
    [SerializeField] private GameObject foodmenu;
    public void SmallFood(){
        if(playerValues.money >= 100) {
            StartCoroutine(staminaScript.IncreaseStamina(3));
            StartCoroutine(moneyScript.TakeMoney(1));
            Closed();  
        }
    }
    public void NormalFood () {
        if(playerValues.money >= 200 ||  DaySystem.day == 6 || DaySystem.day == 7) {
            StartCoroutine(staminaScript.IncreaseStamina(5));
            if(DaySystem.day != 6 || DaySystem.day != 7) {
               StartCoroutine(moneyScript.TakeMoney(2)); 
            }
            Closed();
        }
    }
    public void BigFood(){
        if(playerValues.money >= 300){ 
            StartCoroutine(staminaScript.IncreaseStamina(7));  
            StartCoroutine(moneyScript.TakeMoney(3)); 
            Closed();
        }
    }
    public void Closed(){
        playerValues.canMovi = true;
        playerValues.canOpenFoodMenu = false;
        playerValues.DisabledCursor();
        foodmenu.SetActive(false);
    }
}
