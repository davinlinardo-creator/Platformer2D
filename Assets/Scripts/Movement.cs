using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private float jumpStrength = 4f;
    private BoxCollider2D col;
    private GroundChecker groundcheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundcheck = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
        var newpos = new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
        transform.Translate(newpos);

        if (Input.GetKeyDown(KeyCode.Space) && groundcheck.isGrounded)
        {
            var y = new Vector2(0f, jumpStrength);
            rb.AddForce(y, ForceMode2D.Impulse);
           
        }
    }
}
