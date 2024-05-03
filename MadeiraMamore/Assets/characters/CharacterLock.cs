using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLock : MonoBehaviour
{
    [SerializeField] private Transform player;
    Transform playerPositions;
    // Start is called before the first frame update
    void Start()
    {
        playerPositions.localEulerAngles = new Vector3(0, player.position.y,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerPositions);
    }
}
