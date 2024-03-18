using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MangerMenu : MonoBehaviour
{
    [Header("menus")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;

    [Header("Primeiros botoes selecionados pelo controle")]
    [SerializeField] private GameObject playFirtButton;
    [SerializeField] private GameObject optionsFirstButton;
    [SerializeField] private GameObject closeCreditsFirstButton;

    [Header("Nome da primeira fase")]
    [SerializeField] private string nameGame;    

    void Start()
    { 
        FirtButton();

    }
    void FirtButton(){
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playFirtButton);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(nameGame);
    }
    public void openOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }
    public void closeOptions()
    {
        menu.SetActive(true);
        options.SetActive(false);
        FirtButton();
    }
    public void openCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(closeCreditsFirstButton);
    }
    public void closeCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
        FirtButton();
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quito");
    }
}
