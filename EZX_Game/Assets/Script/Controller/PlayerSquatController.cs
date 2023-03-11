using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquatController : MonoBehaviour
{
    Animator animator;
    int isSquatingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isSquatingHash = Animator.StringToHash("isSquating");
    }

    // Update is called once per frame
    void Update()
    {
        bool isSquating = animator.GetBool(isSquatingHash);
        bool squatPress = Input.GetKey("space");
        // if player press space key
        if (!isSquating && squatPress)
        {
            // then set the isSquating boolean to be true
            animator.SetBool(isSquatingHash,true);
        }
        // if player not press space key
        if (isSquating && !squatPress)
        {
            // then set the isSquating boolean to be false
            animator.SetBool(isSquatingHash,false);
        }
    }
}
