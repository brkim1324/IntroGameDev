using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int Health;
    public float speed;
    public bool move;
    public GameObject Pointer;
    public Vector3 target;
    bool moveCheck;
    
    


    void Start()
    {
        Health = 50;
        moveCheck = false;
        
    }

    void Update()
    {
        Movement();
        //FaceMouse();
     
        
    }

    void Movement ()
    {
        if(Input.GetAxis("Fire2") > 0f)
        {
            moveCheck = true;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        }
        //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

       if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            moveCheck = false;
        }
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        transform.up = direction;
}

    }

