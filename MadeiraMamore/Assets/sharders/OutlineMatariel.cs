using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMatariel : MonoBehaviour
{
    [SerializeField] private Material mater;
    [SerializeField] private Renderer render;
    [SerializeField] private float value;
    // Start is called before the first frame update
    void Start()
    {
        render.material = mater;
        render.material.SetFloat("_ValueMultiplay", value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
