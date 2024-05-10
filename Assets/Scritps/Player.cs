using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float dashSpeed;
    public float dashDuration;
    private float dashTimeLeft;
    bool isDashing = false;
    private Rigidbody2D rigid;
    public Animator animator;
    public SpriteRenderer characterSR;
    public Vector2 moveInput;
    public Scanner scanner;
    public Hand[] hands;
    private void Awake()
    {   
        rigid = GetComponent<Rigidbody2D>();
        animator = characterSR.GetComponent<Animator>(); 
        scanner = GetComponent<Scanner>();
        hands = characterSR.GetComponentsInChildren<Hand>(true);
    }
    
    private void Update()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && dashTimeLeft <= 0)
        {
            moveSpeed += dashSpeed;
            dashTimeLeft = dashDuration;
            isDashing = true;
        }
        if (dashTimeLeft <=0 && isDashing == true)
        {
            moveSpeed -= dashSpeed;
            isDashing = false;
        }
        else
        {
            dashTimeLeft -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }
    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
        {
            return;
        }
        if (moveInput.x != 0)
        {
            characterSR.flipX = moveInput.x < 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive)
            return;
        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);
            }

            animator.SetTrigger("Dead");
            GameManager.instance.GameOver();

        }
    }
}
