using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    private Rigidbody2D player;
    private Collider2D myCol;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        myCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.velocity.y > 0){
            myCol.enabled = false;
        }else{
            myCol.enabled = true;
        }
    }
}
