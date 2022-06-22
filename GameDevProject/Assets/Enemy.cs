using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animaitor;
[SerializeField] private float attackCooldown;
[SerializeField] private int attackDamage = 40;
[SerializeField] private float range;
[SerializeField] private float colliderDistance;
[SerializeField] private BoxCollider2D boxCollder;
[SerializeField] private LayerMask playerLayer;
private float cooldownTimer = Mathf.Infinity;
private Health playerHealth;
private float nextAttackTime;



    public int maxHealth = 100;
    int curentHealth;
    // Start is called before the first frame update
    void Start()
    {
        curentHealth = maxHealth;
    }

    private void Awake()
    {
        animaitor = GetComponent<Animator>();
    }


    private void Update()
    {
        
        cooldownTimer += Time.deltaTime;

        //Attack only when player is in range
        if (PlayerInSight())
        {
             if (cooldownTimer >= attackCooldown)
        {
            //Attack
            cooldownTimer = 0;
            animaitor.SetTrigger("EnemyAttack");
        }
        }
    }

        /*bool PlayerInSight()
       {
         Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
          foreach(Collider2D player in hitPlayer)
        {
           Debug.Log("Hit" + player.name);
        }
        return true;
       }*/



       /*void OnDrawGizmosSelected()
       {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
       }*/



    private bool PlayerInSight()
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollder.bounds.center + transform.right * range * transform.localScale.x* colliderDistance,
             new Vector3(boxCollder.bounds.size.x * range, boxCollder.bounds.size.y, boxCollder.bounds.size.z),
              0, Vector2.left, 0, playerLayer);
              //need fix
              if(hit.collider !=null)
              if(Time.time > nextAttackTime)
              {
                  hit.transform.GetComponent<Health>().TakeDamage(attackDamage);
              Debug.Log("ihit");
              //playerHealth = hit.transform.GetComponent<Health>().TakeDamage(damage);
              float attackRate = 0.8f;
              nextAttackTime = Time.time + attackRate;
              }
            
            return hit.collider != null;
        }


     private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollder.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollder.bounds.size.x * range, boxCollder.bounds.size.y, boxCollder.bounds.size.z));
        }


       /* private void DamagePlayer()
        {
            if(PlayerInSight())
            {
                playerHealth.TakeDamage(attackDamage);
            }
        }*/

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
