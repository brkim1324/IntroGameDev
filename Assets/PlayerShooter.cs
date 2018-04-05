using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask NotToHit;

    public Transform bulletTrailPreFab;
    public GameObject Player;
    
    public GameObject Gun;
    Transform gunEnd;

    float timeToFire = 0;
    

  //  GameObject <Bullet>;

	// Use this for initialization
	void Awake () {
        gunEnd = this.gameObject.transform.GetChild(0);
        if (gunEnd == null)
        {
            Debug.LogError("Cannot Find it");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
            else
            {
                if(Input.GetButtonDown("Fire1") && Time.time > timeToFire)
                {
                    timeToFire = Time.time + 1/fireRate;
                    Shoot();
                }
            }
        }
	}

    void Shoot()
    {
        Debug.Log("Test");
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(gunEnd.position.x, gunEnd.position.y);
        RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, NotToHit);
        Effect();

        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);

    }

    void Effect()
    {
        Instantiate(bulletTrailPreFab, gunEnd.position, gunEnd.rotation);

    }
}
