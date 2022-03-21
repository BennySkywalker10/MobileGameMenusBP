using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{

    public Vector3 touchStartPos;
    public Vector3 direction;
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position. Save it as our touchStartPos
                    touchStartPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 30));
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 30));
                    direction = touchPosition - touchStartPos;
                    transform.position = direction;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    // maybe reset the touchStartPos?
                    // anyway, if we NEED to reset something, do it here

                    Vector3 touchEndPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 30));

                    Vector3 swipe = new Vector3(touchEndPos.x - touchStartPos.x, touchEndPos.y - touchStartPos.y);
                    
                    if (swipe.magnitude < 0.17f)
                    {
                        Vector3 spawnPos = transform.position;
                        Vector3 spawnPosLeft = spawnPos + new Vector3(-.4f, .7f, 0);
                        Vector3 spawnPosRight = spawnPos + new Vector3(.4f, .7f, 0);
                        Instantiate(laserPrefab, spawnPosLeft, Quaternion.identity);
                        Instantiate(laserPrefab, spawnPosRight, Quaternion.identity);

                        //elapsedTime = 0f;
                    }

                    break;
            }
        }
    }
}