using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Slider Mouse Sensitivity")]
    [SerializeField] private Slider sensitivityX;
    [SerializeField] private Slider sensitivityY;

    [System.NonSerialized] public float valueSensitX;
    [System.NonSerialized] public float valueSensitY;

    [Header("Slider Control Sensitivity")]
    [SerializeField] private Slider controlSensitivityX;
    [SerializeField] private Slider controlSensitivityY;

    [System.NonSerialized] public float valueControlSensitX;
    [System.NonSerialized] public float valueControlSensitY;
    void Update()
    {
        valueSensitX = sensitivityX.value;
        valueSensitY = sensitivityY.value;
        valueControlSensitX = controlSensitivityX.value;
        valueControlSensitY = controlSensitivityY.value;
    }
}
