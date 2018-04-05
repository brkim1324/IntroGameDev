using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    ParticleSystem hitParticles;
    bool isDead;
    bool isSinking;
	// Use this for initialization
	void Awake () {
        hitParticles = GetComponentInChildren<ParticleSystem>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);

        }
	}

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= amount;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }

    }

    void Death()
    {
        isDead = true;

    }

    public void StartSinking()
        {
        GetComponent<Rigidbody>().isKinematic = false;

    }
}
