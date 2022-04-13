using UnityEngine;

public class MoveCube : MonoBehaviour
{

    
public Animator animator;

public float moveSpeed = 0.01f;

public Rigidbody2D rb;


Vector2 movement;

    void Update()
    {
       float xDirection = Input.GetAxis("Horizontal");
       float zDirection = Input.GetAxis("Vertical");

       animator.SetFloat("Horizontal", xDirection);
       animator.SetFloat("Vertical",zDirection);
      

       
       
       //spriteRenderer.flipX = movement.x < 0.01 ? true : false;
       

       Vector3 moveDirection = new Vector3(xDirection, zDirection, 0.0f);
       
       transform.position += moveDirection * moveSpeed;

      
    }

   


  
}