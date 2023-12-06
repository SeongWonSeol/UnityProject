using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSplashAnimationManage : MonoBehaviour
{
    private Animator animator;
    private bool playedAnimation = false;
    private int playAnimationIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playedAnimation)
        {
            playedAnimation = true;
            animator.Play("SwordSplash1");
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                animator.Play("Notting");
            }
        }
    }
}
