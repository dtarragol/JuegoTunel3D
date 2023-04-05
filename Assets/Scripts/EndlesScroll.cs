using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlesScroll : MonoBehaviour
{
    public float scrollFactor = -1.0f;
    public Vector3 gameVelocity;
    Rigidbody rb;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Escena3")
        {
            scrollFactor = Mathf.Lerp(scrollFactor, -7.0f, Time.deltaTime / 90.0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }
    
    
    void OnTriggerExit(Collider gameArea){
        transform.position += Vector3.forward * (gameArea.bounds.size.z + GetComponent<BoxCollider>().size.z);

    }

    void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



}
