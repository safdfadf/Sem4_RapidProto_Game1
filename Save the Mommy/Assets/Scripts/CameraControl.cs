using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform player;  // Player's transform
    [SerializeField]
    public float offsetY = 2f;  // Vertical offset from the player
    [SerializeField]
    public float smoothSpeed = 5f;  // Smoothing speed

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y + offsetY, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}