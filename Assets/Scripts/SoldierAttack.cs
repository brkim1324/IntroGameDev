using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttack : MonoBehaviour {

    public float AttackDelays = 0.5f;
    public int AttackDamage = 10;

    GameObject Player;
    PlayerHealth playerHealth;

    bool playerInRange;
    float timer;

	// Use this for initialization
	void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();

	}

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject == Player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            playerInRange = false;
        }
    }
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if(timer >= AttackDelays && playerInRange)
        {
            Attack();
        }

        if(playerHealth.currentHealth <= 0)
        {

        }
	}

    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(AttackDamage);
        }
    }

}
