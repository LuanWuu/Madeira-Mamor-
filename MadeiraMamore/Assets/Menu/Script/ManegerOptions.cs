using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class ManegerOptions : MonoBehaviour
{

    [SerializeField] private GameObject keyboardOptions;
    [SerializeField] private GameObject mouseOptions;
    [SerializeField] private GameObject controlOptions;
    [SerializeField] private GameObject soundOptions;

    [Header("Slider Mouse Sensitivity")]
    [SerializeField] private TextMeshProUGUI mouseXText;
    [SerializeField] private TextMeshProUGUI mouseYText;

    [Header("Slider Control Sensitivity")]
    [SerializeField] private TextMeshProUGUI controlXText;
    [SerializeField] private TextMeshProUGUI controlYText;

    
    [Header("Ponter Size")]
    [SerializeField] private TextMeshProUGUI cursorSizeText;

    [Header("SALVANDO VALORES")]
    [SerializeField] private OptionsValue optionsScriptable;

    [Header("Mixer")]
    [SerializeField] private AudioMixer mixer;
    [Header("Audio text")]
    [SerializeField] private TextMeshProUGUI masterText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI effectText;

    void Start(){
        masterText.text = optionsScriptable.masterSound.ToString();
        musicText.text = optionsScriptable.music.ToString();
        effectText.text = optionsScriptable.effect.ToString();
        cursorSizeText.text  = optionsScriptable.cursorSize.ToString();
        controlXText.text = optionsScriptable.controlSensitX.ToString();
        controlYText.text = optionsScriptable.controlSensitY.ToString();
        mouseXText.text = optionsScriptable.sensitX.ToString();
        mouseYText.text = optionsScriptable.sensitY.ToString();
        mixer.SetFloat("Master", 20f * optionsScriptable.masterSound);
        mixer.SetFloat("Music", 20f * optionsScriptable.music);
        mixer.SetFloat("Effects", 20f * optionsScriptable.effect);
    }
    
    public void KeyBoard(){
        keyboardOptions.SetActive(true);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(false);
        soundOptions.SetActive(false);
    }
    public void Mouse () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(true);
        controlOptions.SetActive(false);
        soundOptions.SetActive(false);
    }
    public void Control () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(true);
        soundOptions.SetActive(false);
    }
    public void  Sound () {
        keyboardOptions.SetActive(false);
        mouseOptions.SetActive(false);
        controlOptions.SetActive(false);
        soundOptions.SetActive(true);
    }
    //ponteiro
    public void SetPonterSize(float intensity){
        optionsScriptable.cursorSize = intensity;
        cursorSizeText.text = intensity.ToString();
    }
    // Control
    public void SetControlX(float intensity){
        optionsScriptable.controlSensitX = intensity;
        controlXText.text = intensity.ToString();
    }
    public void SetControlY(float intensity){
        optionsScriptable.controlSensitY = intensity;
        controlYText.text = intensity.ToString();
    }
    //Mouse
    public void SetMouseX(float intensity){
        optionsScriptable.sensitX = intensity;
        mouseXText.text = intensity.ToString();
    }
    public void SetMouseY(float intensity){
        optionsScriptable.sensitY = intensity;
        mouseYText.text = intensity.ToString();
    }
    // Sound
    public void SetMasterVolume(float intensity){
        optionsScriptable.masterSound = intensity;
        masterText.text = intensity.ToString();
    }
    public void SetMusicVolume(float intensity){
        optionsScriptable.music = intensity;
        musicText.text = intensity.ToString();
    }
    public void SetEffectsVolume(float intensity){
        optionsScriptable.effect = intensity;
        effectText.text = intensity.ToString();
    }
    public void ApplyConfig(){
        Debug.Log("teste");
        mixer.SetFloat("Master", 20f * Mathf.Log10(optionsScriptable.masterSound));
        mixer.SetFloat("Music", 20f * Mathf.Log10(optionsScriptable.music));
        mixer.SetFloat("Effects", 20f * Mathf.Log10(optionsScriptable.effect));
    }
}
