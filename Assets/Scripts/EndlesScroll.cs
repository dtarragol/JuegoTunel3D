using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlesScroll : MonoBehaviour
{
    public float scrollFactor = -1;
    public Vector3 gameVelocity;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = gameVelocity * scrollFactor;
    }

    void OnTriggerExit(Collider gameArea){
        transform.position += Vector3.forward * (gameArea.bounds.size.z + GetComponent<BoxCollider>().size.z);

    }
    void OnCollisionEnter(Collision other){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
