using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current speed from the SpeedManager
        float currentSpeed = SpeedManager.Instance.GetCurrentSpeed();

        // Move the ground tile based on the current speed
        transform.position += new Vector3(0, 0, -currentSpeed) * Time.deltaTime;

    }
}
