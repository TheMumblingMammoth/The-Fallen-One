using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {
	[SerializeField]protected float speed = 1f;
	
	protected bool isGrounded;
	[SerializeField]protected float jumpForce = 15f;
	new protected Rigidbody2D rigidbody;
	protected Animator animator;
	protected SpriteRenderer sprite;
	[SerializeField] protected CharState State{
		get {return(CharState)animator.GetInteger("State");}
		set { animator.SetInteger("State", (int)value);}
	}
	protected void Awake(){
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	// Update is called once per frame
	private void FixedUpdate(){
		CheckGround();
	}

	virtual public void TakeDamage(int Damage){}

	protected void Run(){
		Vector3 direction = transform.right * (sprite.flipX? 1: -1);
		transform.position = Vector3.MoveTowards(transform.position, transform.position  + direction, speed * Time.deltaTime);
		State = CharState.Run;
	}

	protected void Jump(){
		rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
	}

	protected void CheckGround(){
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,0.3f);
		isGrounded = colliders.Length>1;
	}

	protected void Die(){
		State = CharState.Die;
		Destroy(gameObject, 0.5f);
	}
}

public enum CharState{
	Idle,
	Run,
	Jump,
	Fall,
	Die
}