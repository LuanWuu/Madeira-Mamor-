using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject optionsFirstButton;
    [SerializeField] private GameObject buttonBackToMenu;
    [SerializeField] private GameObject playFirtButton;
    [SerializeField] private string nameSceneMenu;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(isOpen == false){
                Time.timeScale = 0;
                canvas.SetActive(true);
                isOpen = true;
                Debug.Log("Abriu");
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionsFirstButton);
            }else{
                Time.timeScale = 1;
                canvas.SetActive(false);
                isOpen = false;
                Debug.Log("Fechou");
            }
        }
    }
    public void BackToGame(){
        Time.timeScale = 1;
        canvas.SetActive(false);
        isOpen = false;
    }
    public void BackToMenu() {
        canvas.SetActive(true);
        buttonBackToMenu.SetActive(false);
        SceneManager.LoadScene(nameSceneMenu);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playFirtButton);
        gameObject.SetActive(false);
    }
}
