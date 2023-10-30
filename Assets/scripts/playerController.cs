using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControles : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speddMove;
    public float jumpingPower;
    public SpriteRenderer sprtRnd;
    public Animator animplayer;
    public Transform transformplayer;
    public GameObject arrowPrefab;
    public float waitShootTime;

    public float horizontal;
    public bool isFacingRight = true;
    private Vector2 directionArrow;
    private float lastShoot;
    private float wiathShootTime;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speddMove, rb.velocity.y);
        checkMovement();
    }

    private void checkMovement()
    {

        //Debug.Log(horizontal);



        if (Mathf.Abs(horizontal) != 0f)
        {
            //Debug.Log("Entra a correr");
            animplayer.SetBool("isRunning", true);
        }
        else
        {
            animplayer.SetBool("isRunning", false);
        }


        if (checkGround.isGrounded)
        {
            //comprobador de salto nnnn
            rb.velocity = new Vector2(horizontal * speddMove, rb.velocity.y);
            animplayer.SetBool("isGrounded", true);
        }
        else
        {
            animplayer.SetBool("isGrounded", false);
        }

        if (!isFacingRight && horizontal > 0f)
        {
            isFacingRight = true;
            sprtRnd.flipX = false;
        }
        else if (isFacingRight && horizontal < 0f)
        {
            isFacingRight = false;
            sprtRnd.flipX = true;
        }





    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Jump()
    {
        if (checkGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }


    }



    public void Shoot() {
        if (Time.time > lastShoot + wiathShootTime) {

            GameObject arrow = Instantiate(arrowPrefab, transformplayer.position, Quaternion.identity);
            if (sprtRnd.flipX)
            { // mira hacia la izquierda 
                directionArrow = Vector2.left;
            }
            else
            { // mira hacia la derecha
                directionArrow = Vector2.right;
            }
            arrow.GetComponent<ArrowController>().setDirection(directionArrow);

            lastShoot = Time.time;


        }
        //Debug.Log("disparo");
       


    }
    




}
