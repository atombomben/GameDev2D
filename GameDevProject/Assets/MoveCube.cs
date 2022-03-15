using UnityEngine;

public class MoveCube : MonoBehaviour
{

public float speed = .01f;
    void Update()
    {
       float xDirection = Input.GetAxis("Horizontal");
       float zDirection = Input.GetAxis("Vertical");

       Vector3 moveDirection = new Vector3(xDirection, zDirection, 0.0f);
       
       transform.position += moveDirection * speed;
    }


  
}