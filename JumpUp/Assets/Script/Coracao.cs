using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coracao : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coracaoObject;
    public GameObject coracao2Object;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coracaoObject.SetActive(false);
            coracao2Object.SetActive(true);
        }
    }
}
