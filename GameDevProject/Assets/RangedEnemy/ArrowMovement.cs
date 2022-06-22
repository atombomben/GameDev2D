using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        /*moveDirection = transform.right;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        transform.rotation = rotation;*/
    }

    private void OnCollisionEnter2D(){
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
