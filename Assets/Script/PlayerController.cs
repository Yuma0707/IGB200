using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Navigate by keyboard  �L�[�{�[�h�ňړ�����

    Animator animator;
    bool isMoving;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving == false)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x != 0)
            {
                y = 0;
            }

            if (x != 0 || y != 0)
            {
                animator.SetFloat("InputX", x);
                animator.SetFloat("InputY", y);
                StartCoroutine(Move(new Vector2(x, y)));
            }
        }
        animator.SetBool("IsMoving", isMoving);
    }

    // Gradually move one square closer together. �P�}�X���X�ɋ߂Â���
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        // If the current target and location are different, keep moving closer. ���݂̃^�[�Q�b�g�Əꏊ���Ⴄ�Ȃ�A�߂Â�������B
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // put close �߂Â���
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime); // (���ݒn, �ڕW�l, ���x)�@�ڕW�l�ɋ߂Â���
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
