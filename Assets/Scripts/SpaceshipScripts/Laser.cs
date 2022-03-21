using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector2(0f, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //gameManager.AddScore();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
