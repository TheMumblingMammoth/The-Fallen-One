using UnityEngine;

public class Player : Character {

	private Attack attack;
	[SerializeField] private int r,p,s;
	new private void Awake(){
		base.Awake();
		attack = Resources.Load<Attack>("Slash");
	}
	private void Update () {
		r=Wheel.rage;
		p=Wheel.pain;
		s=Wheel.sanity;
		if(isGrounded)
			State = CharState.Idle;
		if(Input.GetButtonDown("Fire1")) Shoot();
		if(Input.GetButton("Horizontal")) Run();
		if(Input.GetButtonDown("Jump")&&isGrounded) Jump();
	}

	override public void TakeDamage(int Damage){
		Wheel.AddPain(Damage);
	}

	new private void Run(){
		Vector3 direction = transform.right * Input.GetAxis("Horizontal");
		transform.position = Vector3.MoveTowards(transform.position, transform.position  + direction, speed * Time.deltaTime);
		sprite.flipX = direction.x > 0f;
		State = CharState.Run;
	}

	private void Shoot(){
		Wheel.AddRage(1);
		Vector3 position = transform.position;
		position.y += 1f;
		position.x += (sprite.flipX ? 0.5f: -0.5f);
		Attack newAttack = Instantiate(attack,position,attack.transform.rotation) as Attack;
		newAttack.Direction = newAttack.transform.right *(sprite.flipX ? 1 : -1);
		newAttack.setFlip(sprite.flipX);
	}
}