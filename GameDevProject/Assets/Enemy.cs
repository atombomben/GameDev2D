using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animaitor;

    public int maxHealth = 100;
    int curentHealth;
    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        // Play hurt animaiton

        animaitor.SetTrigger("Hurt");

        if(curentHealth <=0)
        {
            Die();
        }
    }


    public void Die()
    {
        Debug.Log("Enemy died!");

        // play Die animation
        animaitor.SetBool("IsDead", true);

        // disable enemy

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false; 

    }
   
}
