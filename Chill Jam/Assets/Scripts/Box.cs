using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ladder"){
            myRB.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            Debug.Log("Should be working");
        }
    }
    

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Ladder"){
            myRB.constraints = RigidbodyConstraints2D.None;
            myRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    
}
