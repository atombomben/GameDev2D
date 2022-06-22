using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    public Animator animaitor;
    public Image healthBar;
    public float healthAmount = 100;


    public int maxHealth = 100;
    int curentHealth;

    void Start()
    {
        curentHealth = maxHealth;
    }


     private void Awake()
    {
        animaitor = GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        // Play hurt animaiton
       

        animaitor.SetTrigger("Hurt");

        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;

        if(curentHealth <=0)
        {
            Die();
            SceneManager.LoadScene(2);
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


    private void Update()
    {
     

    
     if(Input.GetKeyDown(KeyCode.E))
    {
        Healing(10);
    }
 }
/*
    public void TakeDamage1(int Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }*/
   
    public void Healing(float healPoints)
    {
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount,0,100);
        
        healthBar.fillAmount = healthAmount / 100;

    }
}