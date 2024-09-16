using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float jumpStrength;
    [SerializeField]
    private float strengthMultiplier;


    private Rigidbody2D rb;
    private Bar Bar;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bar = FindObjectOfType<Bar>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }
    private void jump()
    {
        Bar.isOsilating = false;
        jumpStrength = Bar.barSlider.value * strengthMultiplier;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector2 jumpDirection = mousePosition - transform.position;
        rb.velocity = jumpDirection * jumpStrength;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("GrabableObject"))
        {
            // logic for grabing window 
        }
    }
}
