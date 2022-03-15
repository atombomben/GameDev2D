using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Transform Player;

    private float aggroRange = 5f;

    public Rigidbody2D rigidBody;
    private Vector2 movement;
    private float speed = 5f;
    private float rotSpeed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }

    void OrbitPlayer(float currentAngle)
    {
        Vector3 newPos = transform.position;

        float newAngle = currentAngle + (rotSpeed * 2 * Mathf.PI);

        float xScaled = Mathf.Cos(newAngle);
        float yScaled = Mathf.Sin(newAngle);

        newPos.x = Player.transform.position.x + (aggroRange * xScaled);
        newPos.y = Player.transform.position.y + (aggroRange * yScaled);

        Debug.Log("newPos is : " + newPos);
        Debug.Log("Current Pos is : " + transform.position);

        transform.position = Vector3.MoveTowards(
            transform.position,
            newPos,
            speed * Time.deltaTime
        );
    }

    void FixedUpdate()
    {
        float currentDist = Vector2.Distance(transform.position, Player.transform.position);

        if(currentDist > aggroRange)
        {
            Debug.Log("Moving!");
            transform.position = Vector2.MoveTowards(
            transform.position, 
            Player.transform.position, 
            speed*Time.deltaTime);
        }
        else
        {
            Debug.Log("Hey we're trying to orbit.");
            OrbitPlayer(Vector2.Angle(transform.position, Player.transform.position));
        }
    }
}
