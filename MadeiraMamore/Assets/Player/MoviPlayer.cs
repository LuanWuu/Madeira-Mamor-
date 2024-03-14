using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Input.GetJoystickNames().Length > 0)
        {
         Debug.Log("Controle Conectado");
        }
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Keyboard();
        if (Input.GetJoystickNames().Length > 0)
        {
            JoyStick();
        }
    }
    private void Keyboard()
    {
        float horizontalInput = Input.GetAxis("KeyBoardH");
        float verticalInput = Input.GetAxis("KeyBoardY");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
            rb.velocity = movement;
        }

    }
    private void JoyStick()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.fixedDeltaTime;
            rb.velocity = movement;
        }

    }
}
