using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anima;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    [SerializeField] private float moveVelo = 7f;
    [SerializeField] private float jumpHeight = 14f;
    /*
    int wholeNumber = 16; (number integer)
    float decimalNumber = 4.54f; (number decimal)
    string text = "blabla"; (text)
    bool boolean = false; (true/false)
    */ // <-- Comments

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveVelo, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            anima.SetBool("Walking", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            anima.SetBool("Walking", true);
            sprite.flipX = true;
        }
        else
        {
            anima.SetBool("Walking", false);
        }
    }
    
}
