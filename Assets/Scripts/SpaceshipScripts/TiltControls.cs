using UnityEngine;

public class TiltControls : MonoBehaviour
{
    float speed = 100.0f;
    public GameObject laserPrefab;

    void Update()
    {
        Vector3 dir = Vector3.zero;
        // we assume that the device is held parallel to the ground
        // and the Home button is in the right hand

        // remap the device acceleration axis to game coordinates:
        // 1) XY plane of the device is mapped onto XZ plane
        // 2) rotated 90 degrees around Y axis

        dir.y = -Input.acceleration.y;
        dir.x = Input.acceleration.x;

        // clamp acceleration vector to the unit sphere
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        // Make it move 10 meters per second instead of 10 meters per frame...
        dir *= Time.deltaTime;

        // Move object
        transform.Translate(dir * speed);

        if (Input.touchCount > 0)
        {
            Vector3 spawnPos = transform.position;
            Vector3 spawnPosLeft = spawnPos + new Vector3(-.7f, 8f, 0);
            Vector3 spawnPosRight = spawnPos + new Vector3(.7f, 8f, 0);
            Instantiate(laserPrefab, spawnPosLeft, Quaternion.identity);
            Instantiate(laserPrefab, spawnPosRight, Quaternion.identity);
        }

    }
}