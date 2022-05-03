using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
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
