using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody EnemyRB;
    GameObject player;
    
    public float speed = 4.0f;
    private float yBoundary = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        EnemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yBoundary)
        {
            Destroy(gameObject);
        }
        EnemyRB.AddForce((player.transform.position - transform.position).normalized * speed * Time.deltaTime);
    }
}
