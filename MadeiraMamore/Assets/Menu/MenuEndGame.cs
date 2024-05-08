using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEndGame : MonoBehaviour
{
    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    [SerializeField] private string nameScene;
    public void BackMenu () {
        SceneManager.LoadScene(nameScene);
    }
    public void Quit () {
        Application.Quit();
        Debug.Log("Quito");
    }
}
