using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Transform targetPosi;
    private Vector3 iniPosition;
    private bool isOpen;
    // Update is called once per frame
    void Start(){
        iniPosition = transform.position;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(isOpen == false){
                StartMoviment();
            }else{
                BackMovimente();
                isOpen = false;
            }
        }
    }
    void StartMoviment(){
        transform.position = Vector3.Lerp(transform.position, targetPosi.position, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPosi.position);
        if(distance <= 3){
            transform.position = targetPosi.position;
             isOpen = true;
        }
    }
    void BackMovimente(){
        transform.position = Vector3.Lerp(transform.position,  iniPosition, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, iniPosition);
        if(distance <= 50){
            transform.position = iniPosition;
            isOpen = false;
        }
    }
}
