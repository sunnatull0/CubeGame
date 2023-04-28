using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private static float speed = 20f;

    private void FixedUpdate()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }

    public void ChangeSpeed(float newspeed)
    {
        speed += newspeed;
    }

    public void ResetSpeed()
    {
        speed = 20f;
    }
}
