using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;
    public Hand[] hands;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition (rigid.position + nextVec);
    }

    private void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed",inputVec.magnitude);
        

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
