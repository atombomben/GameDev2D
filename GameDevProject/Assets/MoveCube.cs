using UnityEngine;

public class MoveCube : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

void Start() {
    rb2d = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
}

public float speed = .01f;
    void Update()
    {
       float xDirection = Input.GetAxis("Horizontal");
       float zDirection = Input.GetAxis("Vertical");

       Vector3 moveDirection = new Vector3(xDirection, zDirection, 0.0f);
       
       transform.position += moveDirection * speed;

        if (xDirection != 0 || zDirection != 0) {
            animator.SetFloat("X", xDirection);
            animator.SetFloat("Y", zDirection);

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }


    }


  
}