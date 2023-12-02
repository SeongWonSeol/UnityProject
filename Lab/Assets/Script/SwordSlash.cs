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
            animator.SetTrigger("UseSkill"); // "Jump"�� �ִϸ��̼� Ŭ���� �̸��Դϴ�.
        }
    }
}
