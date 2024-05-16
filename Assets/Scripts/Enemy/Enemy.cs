using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    
    private int HP = 100;
    public Animator animator;
    public Slider healthBar;

    private void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}




// using System;
// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public enum EnemyType { Dense, Soft };
//     [SerializeField] private float _speed;
//     [HideInInspector] public Player player;

//     public EnemyType enemyType;
//     public float health = 100f;

//     private void TakeDamage(float damage)
//     {
//         if (enemyType == EnemyType.Dense)
//         {
//             if (currentDamageType == DamageType.Cutting)
//                 damage *= 0.8f; 
//             else if (currentDamageType == DamageType.Crushing)
//                 damage *= 1.2f; 
//         }

//         health -= damage;

//         if (health <= 0)
//         {
//             Die();
//         }
//     }

//     private void Die()
//     {
//         Destroy(gameObject);
//     }
    
//     private void Update()
//     {
//         transform.up = player.transform.position - transform.position;
//         transform.position += _speed * Time.deltaTime * transform.up;
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.attachedRigidbody.gameObject == player.gameObject)
//         {
//             Destroy(gameObject);
//             player.TakeDamage(1);
//         }
//         if (other.gameObject.tag == "Projectile")
//         {
//             Destroy(gameObject);
//             Destroy(other.gameObject);
//         }
//     }
// }



// using UnityEngine;

// public class Enemy : MonoBehaviour
// {
//     public float detectionRange = 10f;
//     public float movementSpeed = 5f;
//     public float attackDamage = 10f;
//     public float attackCooldown = 2f;
//     public float health = 100f;

//     private Transform player;
//     private bool isAttacking = false;

//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//     }

//     void Update()
//     {
//         // Check if player is within detection range
//         if (Vector3.Distance(transform.position, player.position) <= detectionRange)
//         {
//             // Move towards the player
//             MoveTowardsPlayer();

//             // Attack the player if not already attacking
//             if (!isAttacking)
//             {
//                 AttackPlayer();
//             }
//         }
//     }

//     void MoveTowardsPlayer()
//     {
//         // Calculate direction to the player
//         Vector3 direction = (player.position - transform.position).normalized;

//         // Move towards the player
//         transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);

//         // Rotate towards the player (optional)
//         transform.LookAt(player);
//     }

//     void AttackPlayer()
//     {
//         // Perform attack actions here
//         // For simplicity, let's just reduce player health for now
//         PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
//         if (playerHealth != null)
//         {
//             playerHealth.TakeDamage(attackDamage);
//             isAttacking = true;

//             // Reset attack after cooldown
//             Invoke("ResetAttack", attackCooldown);
//         }
//     }

//     void ResetAttack()
//     {
//         isAttacking = false;
//     }

//     public void TakeDamage(float damage)
//     {
//         // Reduce enemy health
//         health -= damage;

//         // Check if the enemy is defeated
//         if (health <= 0)
//         {
//             Destroy(gameObject); // or handle defeat in another way
//         }
//     }
// }

