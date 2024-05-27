using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenu : MonoBehaviour
{
    [SerializeField] private StaminaSystem staminaScript;
    [SerializeField] private MoneySystem moneyScript;
    [SerializeField] private Transform player;
    void Update(){
        transform.LookAt(player);
    }
    public void SmallFood(){
        StartCoroutine(staminaScript.IncreaseStamina(3));
        StartCoroutine(moneyScript.TakeMoney(1));
    }
    public void NormalFood () {
        StartCoroutine(staminaScript.IncreaseStamina(5));
        StartCoroutine(moneyScript.TakeMoney(2));
    }
    public void BigFood(){
        StartCoroutine(staminaScript.IncreaseStamina(7));  
        StartCoroutine(moneyScript.TakeMoney(3)); 
    }
}
