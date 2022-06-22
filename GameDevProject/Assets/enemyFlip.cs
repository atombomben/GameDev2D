using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlip : MonoBehaviour
{
     public Transform Target;
 private GameObject enemy;
 private GameObject player;
 private float Range;
 public float Speed;
    // Start is called before the first frame update
    void Start()
    {
    enemy = GameObject.FindGameObjectWithTag ("Enemy");
    player = GameObject.FindGameObjectWithTag ("Player");  
    } 

    // Update is called once per frame
    void Update()
    {
        Range = Vector2.Distance (enemy.transform.position, player.transform.position);
     if (Range <= 8f) {
         transform.Translate(Vector2.MoveTowards (enemy.transform.position, player.transform.position, Range) * Speed * Time.deltaTime);
     }
    }
}
