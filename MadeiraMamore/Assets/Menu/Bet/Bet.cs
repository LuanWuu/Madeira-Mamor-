using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bet : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private MoneySystem moneyScript;
    [SerializeField] private NighthChoses NighthChosesScript;
    [SerializeField] private TextMeshProUGUI ChoseNumberText;
    [SerializeField] private TextMeshProUGUI betText;
    [System.NonSerialized] public int valueBet = 0;
    [System.NonSerialized] public int valueTextBet = 0;
    [System.NonSerialized] public bool canBet = true;
    [SerializeField] private Image dice;
    [SerializeField] private Sprite[] diceFaces;
    private int number;
    private bool canGetMOney = true;
    public void NumberMore(){
        if (!canBet) return;
        if(number < 6) {
            number++;
            ChoseNumberText.text = number.ToString();
        }else{
            number = 1;
            ChoseNumberText.text = number.ToString();
        }
    }
    public void NumberLess(){
        if (!canBet) return;
        if(number > 1) {
            number--;
            ChoseNumberText.text = number.ToString();
        }else{
            number = 6;
            ChoseNumberText.text = number.ToString();
        }
    }
    public void BetMore(){
        if (!canBet) return;
        if(canGetMOney == true) {
             StartCoroutine(GetMoney(1));
        }
    }
    public void BetLess(){
        if (!canBet) return;
        if(valueBet > 0  && canGetMOney == true) {
             StartCoroutine(RefundMoney(1));
        }else{
            betText.text = "$0";
        }
    }
    public void Play(){
        if (!canBet) return;
        if(valueBet != 0 && number != 0) {
            StartCoroutine(BetGame());
        }
    }
    IEnumerator GetMoney(int money){
        if(playerValues.money >= 100) {
            canGetMOney = false;
            valueBet++;
            int totalIncrease =  money * 100;
            int grow = 10;
            int counter = totalIncrease / grow;
            StartCoroutine(moneyScript.TakeMoney(money));  
            for(int i = 0; i < counter; i++) {
                yield return new WaitForSeconds(0.1f); 
                betText.text = string.Format("${0:0}", valueTextBet += grow); 
            }
            canGetMOney = true;          
        }
    }
    IEnumerator RefundMoney(int money){
        valueBet--;
        canGetMOney = false;
        int totalIncrease =  money * 100;
        int grow = 10;
        int counter = totalIncrease / grow;
        StartCoroutine(moneyScript.GetSalary(1)); 
        for(int i = 0; i < counter; i++) {
            yield return new WaitForSeconds(0.1f); 
            betText.text = string.Format("${0:0}", valueTextBet -= grow); 
        } 
        canGetMOney = true;          
    }
    IEnumerator BetGame(){
        canBet = false;
        int DiceNumber = Random.Range(0,6);
        int diceRotation = 0;
        while(diceRotation < 3){
            for(int i = 0; i < diceFaces.Length; i++) {
                dice.sprite = diceFaces[i];
                yield return new WaitForSeconds(0.25f);
            }
            diceRotation++;
        }
        dice.sprite = diceFaces[DiceNumber];
        if(DiceNumber == number-1) {
            StartCoroutine(Win());
        }else{
            StartCoroutine(Lose());
        }
    }
    IEnumerator Win(){
        int diceRotation = 0;
        valueBet = valueBet * 2;
        while(diceRotation < 3){
            dice.color = Color.green;
            yield return new WaitForSeconds(0.25f);
            dice.color = Color.white;
            diceRotation++;
        }    
        yield return StartCoroutine(moneyScript.GetSalary(valueBet)); 
        yield return new WaitForSeconds(0.5f);
        ChoseNumberText.text = "";
        betText.text = "$0";
        NighthChosesScript.BetSleep();
    }
    IEnumerator Lose(){
        int diceRotation = 0;
        while(diceRotation < 3){
            dice.color = Color.red;
            yield return new WaitForSeconds(0.25f);
            dice.color = Color.white;
            diceRotation++;
        }    
        ChoseNumberText.text = "";
        betText.text = "";
        NighthChosesScript.BetSleep();
    }
}
