using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �L�[�{�[�h�ňړ�����
    bool isMoving;
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

            StartCoroutine(Move(new Vector2(x, y)));
        }
    }

    // �P�}�X���X�ɋ߂Â���
    IEnumerator Move(Vector3 direction)
    {
        isMoving = true;
        Vector3 targetPos = transform.position + direction;
        // ���݂̃^�[�Q�b�g�Əꏊ���Ⴄ�Ȃ�A�߂Â�������B
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // �߂Â���
            transform.position = Vector3.MoveTowards(transform.position, targetPos, 5f*Time.deltaTime); // (���ݒn, �ڕW�l, ���x)�@�ڕW�l�ɋ߂Â���
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
