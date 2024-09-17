using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   
    private bool isGrabbing;
    private float jumpStrength;
    private bool isJumping = true;

    [SerializeField]
    private float strengthMultiplier;
    [SerializeField]
    private float jumpDelay;
    [SerializeField]
    private float maxStreangth;


    private Rigidbody2D rb;
    private Bar Bar;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bar = FindObjectOfType<Bar>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isJumping )
        {
            jump();
        }
    }
    private void jump()
    {
        isJumping = false;
        Bar.isOsilating = false;
        jumpStrength = Mathf.Min( Bar.barSlider.value * strengthMultiplier, maxStreangth);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector2 jumpDirection = mousePosition - transform.position;
        jumpDirection= jumpDirection.normalized;
        rb.velocity = jumpDirection * jumpStrength;
        StartCoroutine(OscilateAgain());// Slider starts oscilating after few seconds
    }
    IEnumerator OscilateAgain()
    {
        yield return new WaitForSeconds(jumpDelay);
        Bar.isOsilating = true;
    }
   public void Grab( Transform grabPoint)
    {
        isJumping = true;// stops the player from double jumping and player can only jump id it grabs the window 
        Debug.Log("object Grabbed");
        isGrabbing = true;
        rb.velocity = Vector2.zero;
        StartCoroutine(SmoothGrab(grabPoint.position));
        //Logic for grabbing the object
        rb.gravityScale = 0f;// when the player grabs the object gravity goes zero so that the player wont fall 
    }
    IEnumerator SmoothGrab(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float duration = 0.2f;
        Vector3 initialPosition = transform.position;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
    public void Release()
    {
        isGrabbing = false;
        rb.gravityScale = 1f;// gravity is back on 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground")) 
        {
            isJumping = true;// if the player lands on ground he can jump again
        }   
    }
}
