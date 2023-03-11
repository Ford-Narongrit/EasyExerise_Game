using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunController : MonoBehaviour
{
    public GameObject player;
    private Animator playerAnimator;
    public float point = 0;
    public float MaxSpeed = 4f;
    public float MinSpeed = -4f;
    private AudioSource audioSource;
    public AudioClip itemSound;

    private float currentMovementSpeed = 1f;
    private void Awake()
    {
        playerAnimator = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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
        playerAnimator.SetFloat("Blend", 0.6f);
    }

    public void OnCollisionEnter(Collision other)
    {
        try
        {
            Damageable damageObject = other.gameObject.GetComponent<Damageable>();
            point = point - damageObject.damage();
            Destroy(other.gameObject);
            audioSource.PlayOneShot(itemSound);
            if (point <= 0) point = 0;
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
            return;
        }
    }
}
