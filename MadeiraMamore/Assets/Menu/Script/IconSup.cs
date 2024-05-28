using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IconSup : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject iconFood;
    [SerializeField] private GameObject iconButton;
    [SerializeField] private TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        if(dist < 9) {
            if (iconFood.activeInHierarchy){
                iconFood.SetActive(false);
            }else if(!iconButton.activeInHierarchy){
                iconButton.SetActive(true);
            }
        }else{
           if (!iconFood.activeInHierarchy){
                iconFood.SetActive(true);
            }else if(iconButton.activeInHierarchy){
                iconButton.SetActive(false);
            } 
        }
        transform.LookAt(player.transform);
        if (Input.GetJoystickNames().Length > 0){
            text.text = "A";
        }else{
            text.text = "E";
        }
    }
}
