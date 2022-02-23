using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;

    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f; 

    private PlayerControls playerActionControls;
    public LayerMask ground;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerActionControls = new PlayerControls();
    }

    private void Start()
    {
        playerActionControls.Land.Jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    private void Update()
    {
        //read movement value
        float moveInput = playerActionControls.Land.Move.ReadValue<float>();
        //move the player
        Vector2 currentPosition = transform.position;
        currentPosition.x += moveInput * moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    private void Jump ()
    {
        if(rb.velocity.y < .1 && rb.velocity.y > -.1)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
