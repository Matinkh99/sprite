using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;
public class playerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D mybody;
    private Animator myAnimator;
    [SerializeField] private int speed = 5;
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

   private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        if (movement.x != 0 || movement.y != 0)
        {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);
            myAnimator.SetBool("isWalking", true);
        }
        else
        {
            myAnimator.SetBool("isWalking", false);

        }

    }
    private void FixedUpdate()
    {
        mybody.linearVelocity = movement * speed;
    }
}
