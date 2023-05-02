using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public static Controles instance;

    //Movimiento
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
    public float rotateSpeed = 5f;
	private Vector3 moveDirection;

	//Camara
	public CharacterController charController;
    public Camera playerCamera;
    public GameObject playerModel;
    public Animator animator;

    //Daño
    public bool isKnocking;
    public float knockBackLength = .5f;
    private float knockBackCounter;
    public Vector2 knockbackPower;

    //Animacion de daño
    public GameObject[] playerPieces;

    public void Awake()
    {

        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sino nos golpean..
        if (!isKnocking) { 

			//Movimiento
			float yStore = moveDirection.y;
			moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;

            //Salto >> Aqui hacer doble salto, si hace falta

            if(charController.isGrounded ) {

         

			    if (Input.GetButtonDown("Jump"))
			    {

				    moveDirection.y = jumpForce;
			    }

		    }


            //Gravedad
            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            //Girodecamara
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {

		        transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);

		    }
		}
        //Si nos golpean..
        if(isKnocking)
        {
            knockBackCounter -= Time.deltaTime;

			float yStore = moveDirection.y;
			moveDirection = (playerModel.transform.forward * knockbackPower.x);
			moveDirection.y = yStore;

			moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

			charController.Move(moveDirection * Time.deltaTime);

			if (knockBackCounter <= 0) 
            {

                isKnocking = false;
            
            }
        }

		//Animacion Correr
		animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));

        //Animacion saltar
        animator.SetBool("Grounded", charController.isGrounded);

     
      
    }

    public void Knockback()
    {
        isKnocking = true;
        knockBackCounter = knockBackLength;
        Debug.Log("Knocked Back");
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }

}

