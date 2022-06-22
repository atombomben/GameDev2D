using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform center;
    public Vector3 axis;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;
    public float speed = 4.0f;
    public float attackRange = 6.0f;
    public Attack attackScript;
    
    private void Orbit() {
        spriteRenderer.flipX = center.position.x < transform.position.x;
        
        transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
/*
        if(Vector2.Distance(transform.position, center.position) < attackRange)
        {
            attackScript.Shoot();
        }
*/
    }

    public void Start() {
        center = GameObject.Find("player").transform;
        //transform.position = (transform.position - center.position).normalized * radius + center.position;
    }
    
    public void Update() {
    }

    public void FixedUpdate() {
        animator.SetFloat("speed", rotationSpeed);
        Orbit();
    }
}