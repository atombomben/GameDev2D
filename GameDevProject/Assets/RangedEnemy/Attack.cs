using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject arrow;
    public Transform player;
    public float launchForce;
    public Transform shotPoint;
    private float currentCooldown;
    public float shotCooldown;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = shotCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCooldown <= 0){
            Shoot();
            currentCooldown = shotCooldown;
        } else {
            currentCooldown -= Time.deltaTime;
        }
    }

    public void Shoot(){
        Vector2 direction = new Vector2(player.position.x - shotPoint.position.x, player.position.y - shotPoint.position.y);
        shotPoint.transform.up = direction;
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        Physics2D.IgnoreCollision(newArrow.GetComponent<BoxCollider2D>(), GetComponent<CapsuleCollider2D>(), true);
    }
}
