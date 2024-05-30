using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malaria : MonoBehaviour
{
    [SerializeField] private GameObject malariaLow;
    [SerializeField] private GameObject malaraHigh;
    [SerializeField] private float coolDownMalariaLow;
    [SerializeField] private float durationMalariaLow;
    [SerializeField] private float coolDownMalariaHigh;
    [SerializeField] private float durationMalariaHigh;

    public IEnumerator lowMalaria(){
        malariaLow.SetActive(false);
        yield return new WaitForSeconds(coolDownMalariaLow);
        malariaLow.SetActive(true);
        yield return new WaitForSeconds(durationMalariaLow);
        StartCoroutine(lowMalaria());
        Debug.Log("low");
    }
    public IEnumerator HighMalaria(){
        malariaLow.SetActive(false);
        malaraHigh.SetActive(false);
        yield return new WaitForSeconds(coolDownMalariaHigh);
        malaraHigh.SetActive(true);
        yield return new WaitForSeconds(durationMalariaHigh);
        StartCoroutine(HighMalaria());
        Debug.Log("high");
    }
    public void DeadMalaria() {
         StopAllCoroutines();
         malariaLow.SetActive(false);
         malaraHigh.SetActive(true);
    }
    
}
