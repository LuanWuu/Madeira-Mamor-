using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FoodMenu : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private StaminaSystem staminaScript;
    [SerializeField] private MoneySystem moneyScript;
    [SerializeField] private GameObject foodmenu;
    [SerializeField] private GameObject firstFood;
    private bool canActive = true;
    void Update(){
        if(foodmenu.activeSelf && canActive) {
            if (Input.GetJoystickNames().Length > 0){ 
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(firstFood);
                canActive = false;
            }
        }
    }
    public void SmallFood(){
        if(playerValues.money >= 100) {
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(3));
            StartCoroutine(moneyScript.TakeMoney(20));
            Closed();  
        }
    }
    public void NormalFood () {
        if(playerValues.money >= 200 ||  DaySystem.day == 6 || DaySystem.day == 7) {
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(40));
            if(DaySystem.day != 6 || DaySystem.day != 7) {
               StartCoroutine(moneyScript.TakeMoney(2)); 
            }
            Closed();
        }
    }
    public void BigFood(){
        if(playerValues.money >= 300){ 
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(60));  
            StartCoroutine(moneyScript.TakeMoney(3)); 
            Closed();
        }
    }
    public void Closed(){
        canActive = true;
        playerValues.canMovi = true;
        playerValues.DisabledCursor();
        foodmenu.SetActive(false);
    }
}
