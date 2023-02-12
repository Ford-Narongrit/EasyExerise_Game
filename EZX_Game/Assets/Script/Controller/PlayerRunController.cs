using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunController : MonoBehaviour
{
    public GameObject player;
    public float MaxSpeed = 4f;
    public float MinSpeed = -4f;

    private float currentMovementSpeed = 1f;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            IncreaseMoveSpeed();
        }
        else
        {
            DecreaseMoveSpeed();
        }
        Move();
    }
    private void IncreaseMoveSpeed()
    {
        if (currentMovementSpeed < MaxSpeed)
            currentMovementSpeed += 2f;
    }

    private void DecreaseMoveSpeed()
    {
        if (currentMovementSpeed > MinSpeed)
            currentMovementSpeed -= 0.1f;
    }

    private void Move()
    {
        player.transform.position = player.transform.position + new Vector3(1 * currentMovementSpeed * Time.deltaTime, 0, 0);
    }
}
