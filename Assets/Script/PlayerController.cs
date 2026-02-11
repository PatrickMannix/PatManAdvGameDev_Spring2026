using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    private float jumpSpeed;
    private float xMove;
    private float xVelocity;

    private Rigidbody2D rb;

    private bool jumpFlag = false;

    public GameObject meleeAttack;

    public LayerMask ground;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float facingDirection;

    private float attackOffset = 0.02f;

    public float meleeDuration = 0.25f;
    private float timeElapseSinceMelee = 0;

    bool meleeTriggered = false;

    public

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFlag = true;
        }
        if (xMove != 0)
        {
            facingDirection = xMove;
        }
        if (meleeTriggered)
        {
            if (timeElapseSinceMelee < meleeDuration)
            {
                timeElapseSinceMelee += Time.deltaTime;
            }
            else
            {
                meleeAttack.SetActive(false);
                timeElapseSinceMelee = 0;
                meleeTriggered = false;
            }
        }

        //Debug.Log(IsGrounded());
        //transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0);
    }
    private void FixedUpdate()
    {
        float xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if(jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;
        }
    }

    private void RangedAttack()
    {
        Vector3 pos = new Vector3(attackOffset * facingDirection, 0, 0);
        Instantiate(BulletPrefab, pos, Quaternion.identity);
    }

    private void meleeAttack()
    {
        meleeAttack.SetActive(true);
        meleeAttack.transform.localPosition = new Vector3(attackOffset * facingDirection, meleeAttack.tranform.localposition.y, 0);
    }

    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist);
    }
}
