using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvensLvl : MonoBehaviour
{
    // Start is called before the first frame update
    public float move = -0.8f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
    }
}
