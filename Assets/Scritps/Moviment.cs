﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Moviment : MonoBehaviour
{
    
    Vector3 start_position;
    Vector3 end_position;
    Vector3 direction;
    Rigidbody2D rigidbdy;
    bool is_moving;
    float distance;
    [HideInInspector]
    public bool is_conected;
    [Range(1,15)]
    public float velocity = 10;
    [Space(10)]
    public Transform conector;
    [Range(0.1f,2.0f)]
    public float min_conector_distance;

    // Start is called before the first frame update
    void Start()
    {
     rigidbdy = transform.root.GetComponent<Rigidbody2D>();
     rigidbdy.gravityScale = 1;
     Physics.IgnoreLayerCollision(8, 8);
     
    }

    void OnMouseDown() {
        
        start_position = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rigidbdy.gravityScale = 0;
        is_moving = true;
        is_conected = false; 
    }

    void OnMouseDrag() {
        end_position = start_position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = end_position - transform.root.position;
        rigidbdy.velocity = direction * velocity;
    }

    void OnMouseUp()
    {
        rigidbdy.gravityScale = 1;
        is_moving = false;
    }
    
    void FixedUpdate()
    {
        if(!is_moving && !is_conected ){
            distance = Vector2.Distance(transform.root.position, conector.position);
            if(distance< min_conector_distance){
                rigidbdy.gravityScale = 0;
                rigidbdy.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position,0.2f);    
            }
            
            if(distance< 0.01){
                is_conected = true;
                transform.root.position = conector.position;
                GameObject obj = conector.gameObject;
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void Update()
    {
        
    }
}
