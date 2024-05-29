using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private ScrpitTablePlayer scriptTableValues;
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject canvas;
    [SerializeField] private string nameSceneMenu;
    [SerializeField] private GameObject firstMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!speechBubble.activeSelf) {
            if(Input.GetKeyDown("escape")){
                if(isOpen == false){
                    canvas.SetActive(true);
                    //Debug.Log("Abriu");
                    scriptTableValues.EnabledCursor();
                    isOpen = true;
                    Time.timeScale = 0;
                    //EventSystem.current.SetSelectedGameObject(null);
                    //EventSystem.current.SetSelectedGameObject(optionsFirstButton);
                }else{
                    BackToGame();
                }
            }
        }
    }
    public void BackToGame(){
        Time.timeScale = 1;
        scriptTableValues.DisabledCursor();
        canvas.SetActive(false);
        isOpen = false;
    }
    public void BackToMenu() {
        SceneManager.LoadScene(nameSceneMenu);
    }
    public void openOptions()
    {
        firstMenu.SetActive(false);
        options.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }
    public void closeOptions()
    {
        firstMenu.SetActive(true);
        options.SetActive(false);
    }
    public void openCredits()
    {
        firstMenu.SetActive(false);
        credits.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(closeCreditsFirstButton);
    }
    public void closeCredits()
    {
        firstMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quito");
    }
}
