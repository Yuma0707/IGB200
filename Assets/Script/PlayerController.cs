using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Navigate by keyboard  キーボードで移動する

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

    // Gradually move one square closer together. １マス徐々に近づける
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        // If the current target and location are different, keep moving closer. 現在のターゲットと場所が違うなら、近づけ続ける。
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // put close 近づける
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime); // (現在地, 目標値, 速度)　目標値に近づける
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
