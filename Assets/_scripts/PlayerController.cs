using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]  private CharacterController controller;
  [SerializeField] private Vector3 dir;
   [SerializeField] private int speed;

    [SerializeField] private int lineToMove = 1;
    [SerializeField] private int lineToDistance = 4;
    [SerializeField] private float jumpForce ;
    [SerializeField] private float gravity ;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if(lineToMove < 2)
            {
                lineToMove ++;
            }
        }
        if (SwipeController.swipeLeft)
        {
            if(lineToMove > 0)
            {
                lineToMove --;
            }
        }
        if (SwipeController.swipeUp)
        {
            if(controller.isGrounded)
                Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineToDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineToDistance;
        transform.position = targetPosition;
    }
  private  void FixedUpdate()
    {
       dir.z = speed ;
        dir.y += gravity * Time.fixedDeltaTime;
       controller.Move(dir * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        dir.y = jumpForce;
    }
}
