using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class SwordSplashAnimationManage : MonoBehaviour
{
    private Animator animator;
    private bool playedAnimation = false;
    private int playAnimationIndex = 1;

    public int delayTime = 800;

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
            playAnimation();
        }
    }

    async void playAnimation()
    {
        if (playAnimationIndex == 1)
        {
            animator.Play("SwordSplash1");
            playedAnimation = true;
        }

        if (playAnimationIndex == 2)
        {
            animator.Play("SwordSplash2");
            playedAnimation = true;
        }

        if (playAnimationIndex == 3)
        {
            animator.Play("SwordSplash3");
            playedAnimation = true;
        }

        playAnimationIndex++;

        if (playAnimationIndex == 4)
        {
            playAnimationIndex = 1;
        }

        await Task.Delay(delayTime);

        playedAnimation = false;
    }
}
