using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRB;
    private Collider2D myCol;
    private Vector2 moveDir;
    private Animator anim;
    [SerializeField]
    private int speed;
    private float moveX;
    private float moveY;
    private bool canMoveVertical = false;
    private bool isGrounded;
    private float checkDistance = .1f;
    private bool isFacingRight = true;

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
        myCol = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }

    void CheckForInput(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        isGrounded = IsGrounded();

        if(canMoveVertical){
            moveDir = new Vector2(moveX * speed, moveY * speed);
        }else if(isGrounded){
            moveDir = new Vector2(moveX * speed, 0);
        }else{
            moveDir = new Vector2(moveX * speed, myRB.velocity.y);
        }
    }

    void MoveAndAnimatePlayer(){
        myRB.velocity = moveDir;
        if(canMoveVertical){
            anim.SetBool("onLadder", true);
        }else{
            anim.SetBool("onLadder", false);
        }

        if(Mathf.Abs(myRB.velocity.y) > .01){
            anim.SetBool("moveY", true);
        }else{
            anim.SetBool("moveY", false);
        }

        if(Mathf.Abs(myRB.velocity.x) > .01){
            anim.SetBool("moveX", true);
        }else{
            anim.SetBool("moveX", false);
        }

        if((moveX < 0 && isFacingRight) || (moveX > 0 && !isFacingRight)){
            Flip();
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Ladder"){
            canMoveVertical = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Ladder"){
            canMoveVertical = false;
        }
    }

    private bool IsGrounded(){
        RaycastHit2D hit = Physics2D.BoxCast(myCol.bounds.center, myCol.bounds.size, 0f, Vector2.down, checkDistance);
        Debug.DrawRay(myCol.bounds.center + new Vector3(myCol.bounds.extents.x, 0), Vector2.down * (myCol.bounds.extents.y + checkDistance), Color.green);
        Debug.DrawRay(myCol.bounds.center - new Vector3(myCol.bounds.extents.x, 0), Vector2.down * (myCol.bounds.extents.y + checkDistance), Color.green);

        if(hit){
            return true;
        }else{
            return false;
        }
    }

    private void Flip(){
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
