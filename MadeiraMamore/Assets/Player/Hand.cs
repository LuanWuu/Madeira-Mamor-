using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private float distCanGet;
    [SerializeField] private float outilineSizeBox;
    [SerializeField] private float lerpVelocity;
    [SerializeField] private float durationLerpMovi;
    [SerializeField] private GameObject speechBubble;

    [SerializeField] private PlayerCamera playerCameraScript;
   
    private bool canGet;
    private bool activeOneTime;
    private bool activeOneTime2;
    private bool canCarry;
    private bool canMoviLerp;
    private bool canGive;
    private bool canActiveCharaceterLines;
    private float startCarryTime;
    private GameObject target;
    private GameObject targetTrain;
    private GameObject targetCharacter;
    private Renderer targetRenderer;
    private Renderer targetRendererDelivery;
    private Ray ray;
    private MensageController mensageControllerScript;
    private Vector3 screenCenter;
    // Start is called before the first frame update
    void Start()
    {
        screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        canMoviLerp = true;
    }

    // Update is called once per frame
    void Update()
    {
        ray =  Camera.main.ScreenPointToRay(screenCenter); //Raio Vindo do Centro da camera

        InputManager();
        RaycastCheck();
        if(canCarry == true){
            Carry();
            //Debug.Log("Pego");
        }
    }
    void InputManager(){
        if (Input.GetKeyDown("e") && canActiveCharaceterLines == true){ // Ativando Caixa de teste
            speechBubble.SetActive(true);
            playerCameraScript.canMoviCamera = false;
        }
        if (Input.GetKeyDown("e")){ // pegando o Objeto
            if(canGet == true){
                canCarry = true;
                startCarryTime = Time.time + durationLerpMovi;
            }else if(canCarry == true){
                canCarry = false;
                canMoviLerp = true;
                //Debug.Log("Solto");
                if(canGive == true){
                    if(targetTrain != null){
                        targetTrain.GetComponent<ToFillTrain>().CheckLayerPackage(target.GetComponent<Renderer>().materials[1].color,
                                                                                  target.layer,target);
                    }
                    canGive = false;
                    canCarry = false;
                    target = null;
                }
            }
        }
    }
    void RaycastCheck(){
        RaycastHit hit; // alvo acertado pode ser qualquer objeto com collider
        if(Physics.Raycast(ray, out hit, distCanGet)){
            switch(hit.collider.gameObject.tag){
                case "Character":
                    canActiveCharaceterLines = true;
                    targetCharacter = hit.collider.gameObject;
                    Debug.Log("hit");
                    break;
                case "Train":
                    if(canCarry == true){
                        targetTrain = hit.collider.gameObject;
                        CheckDelivery();
                    }
                    break;
                case "Box":
                    if(canCarry == false){
                        target = hit.collider.gameObject;
                        CarrySystem();
                    }
                    break;
                default:
                    break;
            }
        }else{
            Reset();
        }
    }

    void CheckDelivery(){
        if(activeOneTime2 == true){
            canGive = true;
            targetRendererDelivery = targetTrain.GetComponent<Renderer>();
            targetTrain.GetComponent<ToFillTrain>().CompatibleLayer(target.layer);
        }
    }
    void CarrySystem(){
        if(activeOneTime == true){
            canGet = true;
            targetRenderer = target.GetComponent<Renderer>();
            targetRenderer.material.SetFloat("_ValueMultiplay", outilineSizeBox);// Ativando o Contorno
            activeOneTime = false;
            //Debug.Log("game " + target.name);
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

    void Reset(){
        canActiveCharaceterLines = false;
        if(speechBubble != null){
            speechBubble.SetActive(false);
        }
        playerCameraScript.canMoviCamera = true;
        
        activeOneTime2 = true;
        if(targetRendererDelivery != null){
            targetRendererDelivery.material.SetFloat("_ValueMultiplay", 0);
        }

        canGet = false;
        activeOneTime = true;
        if(targetRenderer != null){
            targetRenderer.material.SetFloat("_ValueMultiplay", 0);
        }
    }
}
