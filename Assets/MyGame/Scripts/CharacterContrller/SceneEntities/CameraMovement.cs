using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float cameraDelta_x = 3;
    [SerializeField] private float cameraDelta_y = 1.2f;
    //
    private bool needMove = false;
    private Vector2 laspPos = Vector2.zero;
    private float lerpTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (!needMove)
        {
            if (playerTransform.position.x > transform.position.x + cameraDelta_x ||
                playerTransform.position.x < transform.position.x - cameraDelta_x||
                playerTransform.position.y > transform.position.y + cameraDelta_y ||
                playerTransform.position.y < transform.position.y - cameraDelta_y)
            {
                laspPos = transform.position;
                lerpTimer = 0;
                needMove = true;
            }
        }
        else
        {
            lerpTimer += Time.deltaTime * 0.85f;
            transform.position = Vector2.Lerp(laspPos, playerTransform.position, lerpTimer);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            //
            if (lerpTimer >= 1)
            {
                needMove = false;
            }
        }
    }
}
