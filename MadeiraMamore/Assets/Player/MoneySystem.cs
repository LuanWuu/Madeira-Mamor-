using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneySystem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private ScrpitTablePlayer playerValues;
    // Start is called before the first frame update
    void Start()
    {
        playerValues.money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator GetSalary(int salary){
        int totalIncrease = salary * 100;
        int grow = 10;
        int counter = totalIncrease / grow;

        for(int i = 0; i < counter; i++) {
            yield return new WaitForSeconds(0.1f); 
            moneyText.text = string.Format("${0:0}", playerValues.money += grow); 
        }
    }
}
