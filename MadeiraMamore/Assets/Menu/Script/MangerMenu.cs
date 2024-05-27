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
    [SerializeField] private GameObject canvas;

    [Header("Primeiros botoes selecionados pelo controle")]
    [SerializeField] private GameObject playFirtButton;
    [SerializeField] private GameObject optionsFirstButton;
    [SerializeField] private GameObject closeCreditsFirstButton;

    [Header("Nome da primeira fase")]
    [SerializeField] private string nameGame;  

    [Header("Script do Menu")]
    [SerializeField] private ManegerOptions scriptManegerOptions;  

    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("menu");
        if (objs.Length > 1)
        {
            Destroy(menu);
        }
    }
    void Start()
    { 
        FirtButton();

    }
    void FirtButton(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playFirtButton);
    }
    void SecondButton(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    { 
        SceneManager.LoadScene(nameGame);
        closeMenuInGame.SetActive(true);
    }

    public void openOptions()
    {
        firstMenu.SetActive(false);
        options.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
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
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeCreditsFirstButton);
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
