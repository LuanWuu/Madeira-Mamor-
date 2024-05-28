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
    [SerializeField] private GameObject menuFood;
    [SerializeField] private MensageController mensageControllerScript;
    [SerializeField] private StoragaDayValues DaySystem;
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private StaminaSystem staminaController;

    [System.NonSerialized] public bool takePackage;

    private bool canGet;
    private bool activeOneTime;
    private bool canCarry;
    private bool canMoviLerp;
    private bool canGive;
    private bool canActiveCharaceterLines;
    private bool canGetPackage;
    private bool pickedUp = false;
    private bool lookBox;

    private float startCarryTime;

    private GameObject target;
    private GameObject targetTrain;
    private GameObject targetCharacter;
    private GameObject targetDesposit;
    private GameObject targetFood;
    private GameObject lastHitObject; 
    private GameObject iconButton;
    private Renderer targetRenderer;
    private Renderer targetRendererDelivery;
    private Renderer targetRendererDeposity;
    private Renderer targetRendererFoood;
    private Ray ray;
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
        if(canCarry == true && target != null){
            Carry();
        }
    }
    void InputManager(){
        if (Input.GetButtonDown("Interactions")){ 
            if(canActiveCharaceterLines == true){ // Ativando Caixa de teste
                mensageControllerScript.GiveTalk(targetCharacter.name);
            }
            if(targetFood != null && scriptTableValues.canOpenFoodMenu == true){ // Ativando Caixa de teste
                menuFood.SetActive(true);
                scriptTableValues.EnabledCursor();
                scriptTableValues.canMovi = false;
            }
            if(target != null && pickedUp == false) {
                StartCoroutine(staminaController.DecreaseStamina(1));
                pickedUp = true;
            }
            if(target != null && lookBox == true) {
                target.tag = "CloneBox";
            }
            if(iconButton != null) {
                iconButton.SetActive(false);
            }
            switch(DaySystem.dayTime){
            case "Morning":
                ControlerHadMorning();
                break;
            case "Afternoon":
                ControlerHadAfternoon();
                break;
            default:
                    break;
            }
        }
    }
    void ControlerHadAfternoon(){
        if(canGet == true){
            canCarry = true;
            startCarryTime = Time.time + durationLerpMovi;
        }else if(canCarry == true && canGive == true && targetTrain != null && canCarry == true){
            GameObject box = target.transform.GetChild(1).gameObject;
            Renderer boxColor = box.GetComponent<Renderer>();
            targetTrain.GetComponent<ToFillTrain>().CheckLayerPackage(boxColor.materials[1].color, target.layer,target);
            pickedUp = false;
            canMoviLerp = true;
            canCarry = false;
            canGive = false;
            target = null;
        }
    }
    void ControlerHadMorning(){
        if(canGetPackage == true){
            targetTrain.GetComponent<DeschargeMinigame>().GiveClone(hand); 
            canGetPackage = false;
        }
        if(canGet == true){
            canCarry = true;
            startCarryTime = Time.time + durationLerpMovi;
        }else if(canCarry == true && canGive == true && targetDesposit  != null ){
            GameObject box = target.transform.GetChild(1).gameObject;
            Renderer boxColor = box.GetComponent<Renderer>();
            targetDesposit .GetComponent<PackgeController>().CheckLayerPackage(boxColor.materials[1].color, target.layer,target);
            pickedUp = false;
            canMoviLerp = true;
            canCarry = false;
            canGive = false;
            target = null;
        }      
    }
    void RaycastCheck(){
        RaycastHit hit; // alvo acertado pode ser qualquer objeto com collider
        if(Physics.Raycast(ray, out hit, distCanGet)){
            if(hit.collider.gameObject != lastHitObject){
                Reset();
                switch(hit.collider.gameObject.tag){
                    case "Character":
                            canActiveCharaceterLines = true;
                            targetCharacter = hit.collider.gameObject;
                            IconEnabled(targetCharacter);
                            lastHitObject = hit.collider.gameObject;
                        break;
                    case "Train":
                            if(canCarry == true) {
                                targetTrain = hit.collider.gameObject;
                                CheckDelivery();
                            }else if(takePackage == true){
                                targetTrain = hit.collider.gameObject;
                                GetPackage();
                            }
                            lastHitObject = hit.collider.gameObject;
                        break;
                    case "Box":
                        if(canCarry == false){
                            target = hit.collider.gameObject;
                            CarrySystem();
                            IconEnabled(target);
                            lastHitObject = hit.collider.gameObject;
                        }
                        break;
                    case "Desposit":
                        targetDesposit = hit.collider.gameObject;
                        CheckDeposit();
                        lastHitObject = hit.collider.gameObject;
                        break;
                    case "Food":
                        if(DaySystem.dayTime == "Lunch" && scriptTableValues.canOpenFoodMenu == true){
                            targetFood = hit.collider.gameObject;
                            FoodOutilene();
                            IconEnabled(targetFood);
                            lastHitObject = hit.collider.gameObject;
                        }
                        break;
                    default:
                        Reset();
                        break;
                }
            }
        }else{
            Reset();
        }
    }
    void IconEnabled(GameObject luckTarget){
        if(luckTarget != null) {
            for(int i = 0; i < luckTarget.transform.childCount; i++) {
                GameObject chield = luckTarget.transform.GetChild(i).gameObject;
                if(chield.tag == "Icon") {
                    iconButton = chield;
                    break;
                }
            }
            if(iconButton != null) {
                iconButton.gameObject.SetActive(true); 
            }
        }
    }
    void FoodOutilene(){
        if(targetFood != null) {
            targetRendererFoood = targetFood.GetComponent<Renderer>();
            targetRendererFoood.material.SetFloat("_ValueMultiplay", outilineSizeBox);
        }
    }
    void CheckDelivery(){
        targetRendererDelivery = targetTrain.GetComponent<Renderer>();
        canGive = targetTrain.GetComponent<ToFillTrain>().CompatibleLayer(target.layer);
    }
    void GetPackage(){
        canGetPackage = true;
        targetTrain.GetComponent<DeschargeMinigame>().ActiveOutiline();
        targetRendererDelivery = targetTrain.GetComponent<Renderer>();
    }
    void CheckDeposit(){
        if(target != null){
            targetRendererDeposity = targetDesposit.GetComponent<Renderer>();   
            canGive = targetDesposit.GetComponent<PackgeController>().CompatibleLayer(target.layer);
            if(canGive == true){
                IconEnabled(targetDesposit);
            }      
        }
    }
    void CarrySystem(){
        if(activeOneTime == true){
            canGet = true;
            lookBox = true;
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
        if(speechBubble != null){
            speechBubble.SetActive(false);
        }
        if(targetRendererDelivery != null){
            targetRendererDelivery.material.SetFloat("_ValueMultiplay", 0);
        }
        if(targetRendererDeposity  != null){
            targetRendererDeposity.material.SetFloat("_ValueMultiplay", 0);
        }
         if(targetRendererFoood != null) {
            targetRendererFoood.material.SetFloat("_ValueMultiplay", 0);
        }
        if(iconButton != null) {
            iconButton.SetActive(false);
        }
        if(targetRenderer != null){
            targetRenderer.material.SetFloat("_ValueMultiplay", 0);
        }
        IconEnabled(null);
        targetFood = null;
        lastHitObject = null;
        canGetPackage = false;
        canGet = false;
        lookBox = false;
        activeOneTime = true;
        canActiveCharaceterLines = false;
    }
}
