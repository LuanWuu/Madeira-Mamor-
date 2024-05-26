using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private float staminaBasae;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private Transform staminaBar;
    private float amoutStamina;
    private Vector3 valueStamina;
    private Vector3 originStaminabar;
    private Vector3 zeroStamina;
    // Start is called before the first frame update
    void Start()
    {
        scriptTableValues.baseStamina = staminaBasae;
        originStaminabar = staminaBar.localScale;
        zeroStamina = staminaBar.localScale;
        zeroStamina.y = 0;
        amoutStamina = staminaBar.localScale.y/staminaBasae;
        valueStamina.y = amoutStamina;
    }
    void Update(){
        //if(Input.GetKeyDown(KeyCode.M)) {
        //    StartCoroutine(IncreaseStamina(1));
        //}
        //if(Input.GetKeyDown(KeyCode.N)) {
        //    StartCoroutine(DecreaseStamina(1));
         // }
    }
    public IEnumerator DecreaseStamina(int amout){
        for(int i = 0; i < amout; i++) {
            if(staminaBar.localScale.y <= 0) {
                staminaBar.localScale = zeroStamina;
            } else {
                yield return new WaitForSeconds(0.1f); 
                staminaBar.localScale -= valueStamina;                   
            }
        }
    }
    public IEnumerator IncreaseStamina(int amout){
        for(int i = 0; i < amout; i++) {
            if(staminaBar.localScale.y >= originStaminabar.y) {
                staminaBar.localScale = originStaminabar;
            } else {
                yield return new WaitForSeconds(0.1f); 
                staminaBar.localScale += valueStamina;
            }
        }
    }
}
