using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] public int level = 1;

    public void SavePlayer() 
    {
        SaveSystem.SavePlayer(this);
    }


    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new Exception("Damage is negative!");
        
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
    }
}
