using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private RectTransform limit; 
    [SerializeField] private float velocidade = 100f; 

    private bool moviDirection; 
    public void RandomDirection(){
        moviDirection = GetRandomBool();
    }
    bool GetRandomBool(){
        int randomNumber = Random.Range(0, 2);
        return randomNumber == 1;
    }

    void FixedUpdate()
    {
        float leftLimit = limit.rect.xMin;
        float rightLmit = limit.rect.xMax;

        if (transform.localPosition.x >= rightLmit){
            moviDirection = false;
        }else if (transform.localPosition.x <= leftLimit)
        {
            moviDirection = true;
        }
        float movimento = velocidade * Time.fixedDeltaTime * (moviDirection ? 1 : -1);
        transform.localPosition = new Vector3(transform.localPosition.x + movimento, transform.localPosition.y, transform.localPosition.z);
    }
    public void ResetPointer()
    {
        moviDirection = GetRandomBool();
        transform.localPosition = moviDirection ? new Vector3(limit.rect.xMax + limit.localPosition.x, transform.localPosition.y, transform.localPosition.z)
        : new Vector3(limit.rect.xMin + limit.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}
