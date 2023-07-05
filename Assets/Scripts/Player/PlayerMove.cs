using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed=8f;
    private float jumpForce=10f;
    private bool isFacingRight=true;
    //Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashPower = 20f;
    private float dashTime = 0.2f;
    private Vector2 dashDir;
    private float dashCd = 1f;
    //
    private Rigidbody2D rig;
    [SerializeField] private Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;
    private TrailRenderer trail;
    PlayerCore core;
    void Start()
    {
        core = FindObjectOfType<PlayerCore>();
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        groundCheck = GameObject.Find("GroundCheck").transform;
        trail = GameObject.Find("Trail").GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            
        }
        if(Input.GetButtonUp("Jump") && rig.velocity.y > 0f)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y * 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)&& canDash)
        {
            StartCoroutine(Dash());
        }
        Flip();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rig.velocity = new Vector2(horizontal * speed, rig.velocity.y);
    }
    private bool IsGrounded()
    { 
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        core.podeReceberDano = false;
        dashDir = new Vector2(horizontal, vertical);
        if (dashDir == Vector2.zero)
        {
            dashDir = new Vector2(transform.localScale.x, y: 0)*dashPower;
        }
        rig.velocity = dashDir.normalized * dashPower;
        trail.emitting = true;
        yield return new WaitForSeconds(dashTime);
        trail.emitting = false;
        core.podeReceberDano = true;
        isDashing = false;
        //Freeze all positions
        yield return new WaitForSeconds(dashCd);
        canDash = true;
    }
}