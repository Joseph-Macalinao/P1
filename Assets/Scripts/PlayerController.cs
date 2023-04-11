using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    
    
    private bool isGrounded;
    private float fallSpeed;
    public int doubleJump = 2;
    public Vector3 jump;
    public float jumpHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        winTextObject.SetActive(false);

        SetCountText();
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 12){
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

    }
    
    
    void OnCollisionStay(){
        isGrounded = true;
    }


    void Update(){
        //fallSpeed += Physics.gravity.y * Time.deltaTime;


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            //fallSpeed = jumpHeight;    
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }

        //Vector3 velocity = mo

    }

    // private void Jump(){

    //     if(jump > 0){
    //         gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
    //         grounded = false;
    //         jump = jump - 1;
    //     }

    //     else if(jump == 0){
    //         return;
    //     }
    // }



}
