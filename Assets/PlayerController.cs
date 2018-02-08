using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int Health;
    public float speed;
    public bool move;
    public GameObject Pointer;
    private Vector3 target;


    void Start()
    {
        Health = 50;
        
    }

    void Update()
    {
        FaceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            move = true;

            if (move == false)
            {
               
               move = true;
               Instantiate(Pointer, target, Quaternion.identity);
            }
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            move = false;
        }

        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

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

