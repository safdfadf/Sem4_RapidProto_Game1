using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    private bool playerInRange;
    private PlayerController controller;
    private void Start()
    {
        controller = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in the collider");
       //     controller = GetComponent<PlayerController>();
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            controller.Release();// when the player leaves the area of the collider gravity is applied again 
            
        }
    }
    private void Update()
    {
     if(controller!= null)
        {
            GrabObject();
        } 
     
    }
    private void GrabObject()
    {
        if (playerInRange && Input.GetMouseButtonDown(0))
        {
            controller.Grab(transform);
        }
    }
}
