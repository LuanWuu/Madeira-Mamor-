using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private RectTransform stamina;
    [SerializeField] private float normalVelocity;
    [SerializeField] private float localAcceleraWalk;

    Rigidbody rb;

    private float localSpeed;
    // Start is called before the first frame update
    void Start()
    {
        scriptTableValues.canMovi = true;
        rb = GetComponent<Rigidbody>();
        SaveOrigin();
    }
    // Update is called once per frame
    void SaveOrigin(){
        scriptTableValues.moveSpeed = normalVelocity;
        scriptTableValues.acceleraWalk = localAcceleraWalk;
    }
    private void FixedUpdate()
    {
        if(scriptTableValues.canMovi == true){
            if (Input.GetAxis("VerticalMoviJoystick") != 0 || Input.GetAxis("HorizontalMoviJoystick") != 0){
                MovePlayer(Input.GetAxis("HorizontalMoviJoystick"),  Input.GetAxis("VerticalMoviJoystick"));
            }else if(Input.GetAxis("KeyBoardH") != 0 || Input.GetAxis("KeyBoardY") != 0){
                MovePlayer(Input.GetAxis("KeyBoardH"), Input.GetAxis("KeyBoardY"));
            }else{
                rb.velocity = new Vector3(0,0,0);
                localSpeed = 0;
            }
        }else{
            rb.velocity = new Vector3(0,0,0);
            localSpeed = 0;
        }
    }
    void MovePlayer(float horizontal, float vertical){
        AccelerationWalk();  
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * localSpeed * Time.fixedDeltaTime;

        Vector3 localMovement = transform.TransformDirection(movement);

        rb.velocity = new Vector3(localMovement.x, rb.velocity.y, localMovement.z);
    }
    void AccelerationWalk(){
        if(localSpeed < scriptTableValues.moveSpeed){
            localSpeed += localAcceleraWalk;
        }else{
            localSpeed = scriptTableValues.moveSpeed;
        }
    }

}
