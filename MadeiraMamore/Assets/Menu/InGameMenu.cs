using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private RectTransform mainMenu;
    [SerializeField] private GameObject optionsFirstButton;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.anchoredPosition = new Vector2(0,127);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(isOpen == false){
                menu.SetActive(true);
                Cursor.visible = true;//cursos invisivel
                Cursor.lockState = CursorLockMode.None;//cursor livre
                isOpen = true;
                Debug.Log("Abriu");
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionsFirstButton);
            }else{
                menu.SetActive(false);
                Cursor.visible = false;//cursos invisivel
                Cursor.lockState = CursorLockMode.Locked;//cursor travado no mesmo local
                isOpen = false;
                Debug.Log("Fechou");
            }
        }
    }
    public void BackToGame(){
        menu.SetActive(false);
        isOpen = false;
        Cursor.visible = false;//cursos invisivel
        Cursor.lockState = CursorLockMode.Locked;//cursor travado no mesmo local
    }
}
