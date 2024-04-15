using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float distCanGet;
    [SerializeField] private Transform hand;
    [SerializeField] private float outilineSize;
    [SerializeField] private float lerpVelocity;
   

    private bool canGet;
    private bool activeOneTime;
    private bool canCarry;
    private float distOfObjects;
    private GameObject target;
    private Renderer targetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Raio Vindo do Centro da camera
        RaycastHit hit; // alvo acertado pode ser qualquer objeto com collider
        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Box"){ // verificando qual o objeto foi acertado
            target = hit.collider.gameObject;

            distOfObjects = Vector3.Distance(target.transform.position, transform.position);// distance do player com o obejto
            //Debug.Log("distance doa objetos " + distOfObjects);
            if(distOfObjects <= distCanGet){ // se o Player esta perto do Objeto
                canGet = true; 
                if(activeOneTime == true && canCarry == false){
                    targetRenderer = target.GetComponent<Renderer>();
                    targetRenderer.material.SetFloat("_ValueMultiplay", outilineSize);// Ativando o Contorni
                    activeOneTime = false;
                }
            }else{
                ResetValues();
            }
            //Debug.Log("pegou a caixa + " + target.name);
        }else{
            ResetValues();
        }
        

        if (Input.GetMouseButtonDown(0)){ // pegando o Objeto
            if(canGet == true){
                canCarry = true;
            }else if(canCarry == true){
                canCarry = false;
                //Debug.Log("Solto");
            }

        }
        if(canCarry == true){
            Carry();
            //Debug.Log("Pego");
        }
     
    }
    void ResetValues(){// resetando as variaveis Quando nao pode haver interacao com o objeto
        canGet = false;
        activeOneTime = true;
        distOfObjects = float.NaN;
        if(targetRenderer != null){
            targetRenderer.material.SetFloat("_ValueMultiplay", 0);
        }
    }
    void Carry(){ 
        float targetTransX = target.transform.position.x;
        float targetTransY = target.transform.position.y;
        float targetTransZ = target.transform.position.z;
        target.transform.position = new Vector3(Mathf.Lerp(targetTransX,hand.transform.position.x,lerpVelocity), 
                                                Mathf.Lerp(targetTransY,hand.transform.position.y,lerpVelocity),
                                                Mathf.Lerp(targetTransZ,hand.transform.position.z,lerpVelocity));
        target.transform.rotation = transform.rotation;
    }

}
