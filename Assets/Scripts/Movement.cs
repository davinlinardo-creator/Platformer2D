using System.Runtime.CompilerServices;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpStrength = 4f;
    private BoxCollider2D col;
    private GroundChecker groundcheck;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundcheck = GetComponentInChildren<GroundChecker>();
        animator = GetComponent<Animator>();
        GameManager.instance.GameManagerCheck();
    }

    private void walkAnimation()
    {
        animator.SetTrigger("goWalk");
    }

    private void Idle()
    {
        animator.SetTrigger("goIdle");
    }

    private void Jump()
    {
        animator.SetTrigger("goJump");
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        var newpos = new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(newpos);


        if (horizontalInput != 0 && groundcheck.isGrounded)
        {
            // Debug.Log("yo animation should be working nowww!!");
            walkAnimation();
        }
        else if (horizontalInput == 0 && groundcheck.isGrounded) 
        {
            Idle();
        }

        if (Input.GetKeyDown(KeyCode.Space) && groundcheck.isGrounded)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
            Jump();
        }
    }
}
