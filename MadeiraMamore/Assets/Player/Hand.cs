using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform hand;
    [SerializeField] private float distCanGet;
    [SerializeField] private float distCanGiveTrain;
    [SerializeField] private float outilineSizeBox;
    [SerializeField] private float outilineSizeTrain;
    [SerializeField] private float lerpVelocity;
    [SerializeField] private float durationLerpMovi;
   

    private bool canGet;
    private bool activeOneTime;
    private bool activeOneTime2;
    private bool canCarry;
    private bool canMoviLerp;
    private bool canGive;
    private float startCarryTime;
    private float distOfObjects;
    private float distTrain;
    private GameObject target;
    private GameObject targetTrain;
    private Renderer targetRenderer;
    private Renderer targetRendererDelivery;
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        canMoviLerp = true;
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition); //Raio Vindo do Centro da camera
        CarrySystem();
        InputManager();
        CheckDelivery();
    }
    void InputManager(){
        if (Input.GetMouseButtonDown(0)){ // pegando o Objeto
            if(canGet == true){
                canCarry = true;
                startCarryTime = Time.time + durationLerpMovi;
            }else if(canCarry == true){
                canCarry = false;
                canMoviLerp = true;
                //Debug.Log("Solto");
                if(canGive == true){
                    Debug.Log("entregou");
                    if(targetTrain != null){
                        targetTrain.GetComponent<ToFillTrain>().CheckLayerPackage(target.GetComponent<Renderer>().materials[1].color,
                                                                                  target.layer);
                    }
                    Destroy(target, 0.2f);
                    target = null;
                    canGive = false;
                }
            }
        }
    }
    void CheckDelivery(){
        RaycastHit hitTrain;
        if(Physics.Raycast(ray, out hitTrain) && hitTrain.collider.gameObject.tag == "Train" && canCarry == true){
            targetTrain = hitTrain.collider.gameObject;
            distTrain = Vector3.Distance(targetTrain.transform.position, transform.position);
            if(distTrain <= distCanGiveTrain){
                if(activeOneTime2 == true){
                    canGive = true;
                    targetRendererDelivery = targetTrain.GetComponent<Renderer>();
                    targetRendererDelivery.material.SetFloat("_ValueMultiplay", outilineSizeTrain);// Ativando o Contorno
                }
            }else{
                ResetValuesDelivery();
            }
        }else{
            ResetValuesDelivery();
        }
    }
    void CarrySystem(){
        RaycastHit hit; // alvo acertado pode ser qualquer objeto com collider
        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Box" && canCarry == false){ // verificando qual o objeto foi acertado
            target = hit.collider.gameObject;
            distOfObjects = Vector3.Distance(target.transform.position, transform.position);// distance do player com o obejto
            //Debug.Log("distance doa objetos " + distOfObjects);
            if(distOfObjects <= distCanGet){ // se o Player esta perto do Objeto
                if(activeOneTime == true && canCarry == false){
                    canGet = true;
                    targetRenderer = target.GetComponent<Renderer>();
                    targetRenderer.material.SetFloat("_ValueMultiplay", outilineSizeBox);// Ativando o Contorno
                    activeOneTime = false;
                }
            }else{
                ResetValuesCarry();
            }
            //Debug.Log("pegou a caixa + " + target.name);
        }else{
            ResetValuesCarry();
        }
        if(canCarry == true){
            Carry();
            //Debug.Log("Pego");
        }
     
    }
    void Carry(){ 
        target.transform.rotation = transform.rotation;
        if(canMoviLerp == true){
            if (startCarryTime > Time.time){
                LerpMovi();
            }else{
                canMoviLerp = false;
            }
        }else if(canMoviLerp == false){ 
            target.transform.position = Vector3.MoveTowards(target.transform.position , hand.transform.position, 10);
        }
    }
    void LerpMovi(){
        float targetTransX = target.transform.position.x;
        float targetTransY = target.transform.position.y;
        float targetTransZ = target.transform.position.z;
        target.transform.position = new Vector3(Mathf.Lerp(targetTransX,hand.transform.position.x,lerpVelocity), 
                                                   Mathf.Lerp(targetTransY,hand.transform.position.y,lerpVelocity),
                                                   Mathf.Lerp(targetTransZ,hand.transform.position.z,lerpVelocity));
    }
    void ResetValuesCarry(){// resetando as variaveis Quando nao pode haver interacao com o objeto
        canGet = false;
        activeOneTime = true;
        distOfObjects = float.NaN;
        if(targetRenderer != null){
            targetRenderer.material.SetFloat("_ValueMultiplay", 0);
        }
    }
    void ResetValuesDelivery(){
        activeOneTime2 = true;
        distTrain = float.NaN;
        if(targetRendererDelivery != null){
            targetRendererDelivery.material.SetFloat("_ValueMultiplay", 0);
        }
    }
}
