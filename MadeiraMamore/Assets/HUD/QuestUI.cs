using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private Transform targetPosi;
    private Vector3 iniPosition;
    private bool isOpen;
    private bool isClosed;
    // Update is called once per frame
    void Start(){
        iniPosition = transform.position;
        isOpen = false;
        isClosed = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            if(isClosed == false){
                isOpen = false;
                isClosed = true;
            }else if(isOpen == false){
                isClosed = false;
                isOpen = true;
            }
        }
        if(isClosed == true){
            StartMoviment();
        }
        if(isOpen == true){
            BackMovimente();
        }
    }
    void StartMoviment(){
        transform.position = Vector3.Lerp(transform.position, targetPosi.position, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPosi.position);
        if(distance <= 3){
            transform.position = targetPosi.position;
        }
    }
    void BackMovimente(){
        transform.position = Vector3.Lerp(transform.position,  iniPosition, 1 * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, iniPosition);
        if(distance <= 50){
            transform.position = iniPosition;
        }
    }
}
