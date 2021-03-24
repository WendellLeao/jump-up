using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
       
    }

    public void Jogar()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        DontDestroyOnLoad(transform.gameObject);
    }

    public void JogarMute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void Creditos()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
            DontDestroyOnLoad(transform.gameObject);
    }
    public void MenuMute()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuMute");
    }
    public void Sair()
    {
        Application.Quit();
    }
}
