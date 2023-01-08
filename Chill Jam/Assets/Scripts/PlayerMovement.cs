using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRB;
    private Vector2 moveDir;
    [SerializeField]
    private int speed;
    private float moveX;
    private float moveY;
    private bool canMoveVertical = false;

    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
        MoveAndAnimatePlayer();
    }

    void FindComponents(){
        myRB = GetComponent<Rigidbody2D>();
    }

    void CheckForInput(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if(canMoveVertical){
            moveDir = new Vector2(moveX, moveY);
        }else{
            moveDir = new Vector2(moveX, 0);
        }
    }

    void MoveAndAnimatePlayer(){
        //myRB.AddForce(moveDir, ForceMode2D.Impulse);
        myRB.velocity = moveDir * speed;
    }


    void OnTriggerEnter2D(){
        canMoveVertical = true;
    }

    void OnTriggerExit2D(){
        canMoveVertical = false;
    }
}
