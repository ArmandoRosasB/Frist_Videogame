using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpingStrength;
    public Game_manager gameManager;
    
    private int jump_count;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        jump_count = 0;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if (jump_count == 0){
                animator.SetBool("isJumping", true);
                rigidbody2D.AddForce(new Vector2(0,jumpingStrength));
                jump_count++;
            }
            else if (jump_count == 1){
                animator.SetBool("isJumpingHigher", true);
                rigidbody2D.AddForce(new Vector2(0,jumpingStrength));
                jump_count++;
            }

            else{

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor"){
            animator.SetBool("isJumping", false);
            animator.SetBool("isJumpingHigher", false);
            jump_count = 0;
        }

        if (collision.gameObject.tag == "Enemy"){
            gameManager.gameOver = true;
        }
    }
}
