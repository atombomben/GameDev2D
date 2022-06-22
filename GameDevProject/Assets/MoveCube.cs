using UnityEngine;

public class MoveCube : MonoBehaviour
{

    
public Animator animator;

public float moveSpeed = 0.01f;

public Rigidbody2D rb;

void Start(){
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
}

Vector2 movement;


public bool facingRight = true; //Depends on if your animation is by default facing right or left
 
void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if(h > 0 && !facingRight)
            Flip();
        else if(h < 0 && facingRight)
            Flip();
     }
void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    void Update()
    {
       float xDirection = Input.GetAxis("Horizontal");
       float zDirection = Input.GetAxis("Vertical");

       animator.SetFloat("Horizontal", xDirection);
       animator.SetFloat("Vertical",zDirection);
      
 
     


    

       
       //spriteRenderer.flipX = movement.x < 0.01 ? true : false;
       

       Vector3 moveDirection = new Vector3(xDirection, zDirection, 0.0f);
       
       transform.position += moveDirection * moveSpeed;


       if (xDirection != 0 || zDirection != 0) {
            animator.SetFloat("Horizontal", xDirection);
            animator.SetFloat("Vertical", zDirection);

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }

      
    }

   


  
}