using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField] private float staminaBasae;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private RaffleQuest questScript;
    [SerializeField] private Transform staminaBar;
    [SerializeField] private Image staminaBarImage;
    [SerializeField] private Image staminaInterface;
    [SerializeField] private Image staminaBackGround;
    private float amoutStamina;
    private Vector3 valueStamina;
    private Vector3 originStaminabar;
    private Vector3 zeroStamina;
    // Start is called before the first frame update
    void Start()
    {
        scriptTableValues.staminaRecuperNight = 0;
        originStaminabar = staminaBar.localScale;
        zeroStamina = staminaBar.localScale;
        zeroStamina.y = 0;
        amoutStamina = staminaBar.localScale.y/staminaBasae;
        valueStamina.y = amoutStamina;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.M)) {
            StartCoroutine(IncreaseStamina(100));
        }
        if(Input.GetKeyDown(KeyCode.N)) {
            StartCoroutine(DecreaseStamina(95));
       }
    }
    public IEnumerator DecreaseStamina(int amout){
        StartCoroutine(EnabledStamina(amout));
        for(int i = 0; i < amout; i++) {
            if(staminaBar.localScale.y <= 0) {
                staminaBar.localScale = zeroStamina;
                questScript.NoStamina();
            } else {
                yield return new WaitForSeconds(0.075f); 
                staminaBar.localScale -= valueStamina;                   
            }
        }
    }
    public IEnumerator IncreaseStamina(int amout){
        StartCoroutine(EnabledStamina(amout));
        for(int i = 0; i < amout; i++) {
            if(staminaBar.localScale.y >= originStaminabar.y) {
                staminaBar.localScale = originStaminabar;
            } else {
                yield return new WaitForSeconds(0.075f); 
                staminaBar.localScale += valueStamina;
            }
        }
    }
    IEnumerator EnabledStamina(int amout){
        staminaBarImage.gameObject.SetActive(true);
        staminaInterface.gameObject.SetActive(true);
        staminaBackGround.gameObject.SetActive(true);
        staminaBarImage.color = Color.white;
        staminaInterface.color = Color.white;
        staminaBackGround.color = Color.white;
        float valuevisibility = 1;
        float valueTodecreased = (float) 1/amout;
        if(amout < 10) {
            valueTodecreased = 0.05f;
        }
        Color colorvalue = Color.white;
        while(colorvalue.a > 0){
            colorvalue.a = valuevisibility;
            staminaBarImage.color = colorvalue;
            staminaInterface.color = colorvalue;
            staminaBackGround.color = colorvalue;
            valuevisibility -= valueTodecreased;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.05f);
        staminaBarImage.gameObject.SetActive(false);
        staminaInterface.gameObject.SetActive(false);
        staminaBackGround.gameObject.SetActive(false);
    }
}
