using UnityEngine;
using System.Collections;

public class SwordSlash : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("UseSkill"); // "Jump"은 애니메이션 클립의 이름입니다.
        }
    }
}
