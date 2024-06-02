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
        if(foodmenu.activeSelf && Cursor.visible ==false) {
           playerValues.EnabledCursor();
        }
    }
    public void SmallFood(){
        if(playerValues.money >= 200) {
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(20));
            StartCoroutine(moneyScript.TakeMoney(2));
            Closed();  
        }
    }
    public void NormalFood () {
        if(playerValues.money >= 400 ||  DaySystem.day == 6 || DaySystem.day == 7) {
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(40));
            if(DaySystem.day != 6 || DaySystem.day != 7) {
               StartCoroutine(moneyScript.TakeMoney(4)); 
            }
            Closed();
        }
    }
    public void BigFood(){
        if(playerValues.money >= 600){ 
            playerValues.canOpenFoodMenu = false;
            StartCoroutine(staminaScript.IncreaseStamina(60));  
            StartCoroutine(moneyScript.TakeMoney(6)); 
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
