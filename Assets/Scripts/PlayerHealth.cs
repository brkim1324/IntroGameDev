using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public int Health = 100;
    public Slider healthSlider;
    public Image damageImage;
    public float flashspeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    KeyboardController playerMovement;

    bool isDead;
    bool Damaged;

	// Use this for initialization
	void Awake () {
        playerMovement = GetComponent<KeyboardController> ();
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (Damaged)
        {
            damageImage.color = flashColor;
        }else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashspeed * Time.deltaTime);

        }
        Damaged = false;


	}

    public void TakeDamage (int amount)
    {
        Damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        
        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Enemy")
        {
            currentHealth -= 10;
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        isDead = true;

        
        GameMaster.KillPlayer(this);
    }

}
