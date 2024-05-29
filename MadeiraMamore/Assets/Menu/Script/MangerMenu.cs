using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MangerMenu : MonoBehaviour
{
    [Header("menus")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject firstMenu;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject closeMenuInGame;

    [Header("Primeiros botoes selecionados pelo controle")]
    [SerializeField] private GameObject playFirtButton;
    [SerializeField] private GameObject optionsFirstButton;
    [SerializeField] private GameObject closeCreditsFirstButton;

    [Header("Nome da primeira fase")]
    [SerializeField] private string nameGame;  
    [Header("SALVANDO VALORES")]
    [SerializeField] private OptionsValue optionsScriptable;

    void Awake()
    { 
        optionsScriptable.sensitX = 0.1f;
        optionsScriptable.sensitY = 0.1f;
        optionsScriptable.controlSensitX = 0.1f;
        optionsScriptable.controlSensitY = 0.1f;
        optionsScriptable.cursorSize = 0.1f;
        optionsScriptable.masterSound = 0.1f;
        optionsScriptable.music = 0.1f;
        optionsScriptable.effect = 0.1f;
        if (Input.GetJoystickNames().Length > 0){ 
            FirtButton();
        }
    }
    void FirtButton(){
        if (Input.GetJoystickNames().Length > 0){ 
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(playFirtButton);
        }
    }
    void SecondButton(){
        if (Input.GetJoystickNames().Length > 0){ 
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsButton);
        }
    }

    public void StartGame()
    { 
        SceneManager.LoadScene(nameGame);
    }

    public void openOptions()
    {
        firstMenu.SetActive(false);
        options.SetActive(true);
        if (Input.GetJoystickNames().Length > 0){ 
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(optionsFirstButton);
        }
    }
    public void closeOptions()
    {
        firstMenu.SetActive(true);
        options.SetActive(false);
        FirtButton();
    }
    public void openCredits()
    {
        firstMenu.SetActive(false);
        credits.SetActive(true);
        if (Input.GetJoystickNames().Length > 0){ 
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(closeCreditsFirstButton);
        }
    }
    public void closeCredits()
    {
        firstMenu.SetActive(true);
        credits.SetActive(false);
        FirtButton();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
