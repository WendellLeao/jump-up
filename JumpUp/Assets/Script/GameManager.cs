using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player variables")]
    public GameObject PainelMorreu;
    public GameObject PainelPause;

    private void Awake()
    {

    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Player.isDead)
        {
            Dead();
        }
    }

    public void Dead()
    {
        PainelMorreu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        PainelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Retomar()
    {
        PainelPause.SetActive(false);
        Time.timeScale = 1;
    }

    public void PressedPause()
    {
        GetComponent<AudioSource>().Play();
    }

}
