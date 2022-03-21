using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoeyMovement : MonoBehaviour
{
    public static float speed = -2f;
    private static float meteorTimer = 0f;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        meteorTimer += Time.deltaTime;

        if (meteorTimer >= 20f)
        {
            speed = -2.1f;
            rigidBody.velocity = new Vector2(0, speed);
            meteorTimer = 0;
        }
    }


}
