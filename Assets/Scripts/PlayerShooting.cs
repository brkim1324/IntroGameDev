using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public int damagePerShot = 20;
    public float ShootDelays = 0.15f;
    public float Range = 100f;

    float timer;
    Ray ShootRay;
    RaycastHit shootHit;
    int ShootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;

    float effectTime = 0.2f;

	// Use this for initialization
	void Awake () {
        ShootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(Input.GetButton ("Fire2") && timer >= ShootDelays)
        {
            Shoot();
        }

        if(timer >= ShootDelays * effectTime)
        {
            DisableEffects();
        }
	}

    public void DisableEffects()
    {
       // gunLine.enabled = false;

    }

    void Shoot()
    {
        timer = 0f;

        ShootRay.origin = transform.position;
        ShootRay.direction = transform.forward;

        if(Physics.Raycast(ShootRay, out shootHit, Range, ShootableMask))
        {
            SoldierHealth soldierHealth = shootHit.collider.GetComponent<SoldierHealth>();
            if (soldierHealth != null)
            {
                soldierHealth.TakeDamage(damagePerShot, shootHit.point);

            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, ShootRay.origin + ShootRay.direction * Range);


        }
    }

}
