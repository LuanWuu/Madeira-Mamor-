using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MangerMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private string nameGame;    
    // Start is called before the first frame update dasda dasdas
    void Start()
    {


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
    }
    public void closeOptions()
    {
        menu.SetActive(true);
        options.SetActive(false);
    }
    public void openCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void closeCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quito");
    }
}
