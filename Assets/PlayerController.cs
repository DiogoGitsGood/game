using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

public float moveSpeed = 1f;
public float collisionOffset = 0.05f;
public ContactFilter2D movementFilter;
public bool isAlive = true;
Vector2 movementInput;

Rigidbody2D rb;
public bool canMove = true;
Animator animator;

SpriteRenderer spriteRenderer;

List <RaycastHit2D> castCollision = new List <RaycastHit2D>();
    // Start is called before the first frame update
public bool isMoving;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
   private void FixedUpdate()
    {
		if(canMove){
        if(movementInput != Vector2.zero){
        bool sucess = TryMove(movementInput);
        
        	if(!sucess){
        	sucess = TryMove(new Vector2(movementInput.x, 0));
        		if(!sucess){
        		sucess = TryMove(new Vector2(0, movementInput.y));
        
        }
    }

    animator.SetBool("isMoving", sucess);
    } else {
    animator.SetBool("isMoving", false);
    }
    print("isMoving: " + animator.GetBool("isMoving"));

    if(movementInput.x <0) {
    spriteRenderer.flipX = true;
    } else if (movementInput.x >0){
    spriteRenderer.flipX = false; }
    }
	}
private bool TryMove(Vector2 direction){
	if(direction != Vector2.zero){
		int count = rb.Cast(
		direction, 
		movementFilter,
		castCollision, 
		moveSpeed * Time.fixedDeltaTime + collisionOffset);

			if(count ==0){
				rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
				return true;
			}
			else{
				return false;
			}
		}
				else{
					return false;
				}
			}


void OnMove(InputValue movementValue){
    movementInput = movementValue.Get<Vector2>();
    }

public void OnFire()
{
animator.SetTrigger("swordAttack");


}
public void LockMovement(){
canMove = false;}

public void UnlockMovement(){
canMove=true;}
}
