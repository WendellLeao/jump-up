using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusica : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Creditos()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Creditos");
        DontDestroyOnLoad(transform.gameObject);
    }


}
