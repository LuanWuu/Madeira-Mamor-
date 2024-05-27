using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IconButton : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Face");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Input.GetJoystickNames().Length > 0){
            text.text = "A";
        }else{
            text.text = "E";
        }
    }
}
