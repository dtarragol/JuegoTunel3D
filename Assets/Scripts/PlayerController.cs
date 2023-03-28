using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 gravity;
    public Vector3 jumpSpeed;

    Rigidbody rb;
    bool isGrounded=false;

    void Awake(){
        Physics.gravity = gravity;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update(){
        if (Input.anyKeyDown && isGrounded){
            rb.velocity = jumpSpeed;
            isGrounded=false;
        }
        
    }
    void OnCollisionEnter(Collision collision){
        isGrounded= true;
    }
}
