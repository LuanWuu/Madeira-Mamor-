using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private ScrpitTablePlayer playerValues;
    [SerializeField] private AudioSource effect;
    [SerializeField] private AudioClip effectMoney;
    // Start is called before the first frame update
    void Start()
    {
        playerValues.money = 200;
        moneyText.text = "$200"; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Equals)) {
           StartCoroutine(GetSalary(2));
        }
    }
    public IEnumerator GetSalary(int salary){
        effect.clip = effectMoney;
        effect.Play();
        int totalIncrease = salary * 100;
        int valueMoney = playerValues.money;
        playerValues.money += totalIncrease;
        int grow = 10;
        int counter = totalIncrease / grow;

        for(int i = 0; i < counter; i++) {
            yield return new WaitForSeconds(0.1f); 
            moneyText.text = string.Format("${0:0}", valueMoney += grow); 
        }
    }
    public IEnumerator TakeMoney(int salary){
        int totalIncrease = salary * 100;
        int valueMoney = playerValues.money;
        playerValues.money -= totalIncrease;
        int grow = 10;
        int counter = totalIncrease / grow;

        for(int i = 0; i < counter; i++) {
            yield return new WaitForSeconds(0.1f); 
            moneyText.text = string.Format("${0:0}", valueMoney -= grow); 
        }
    }
}
