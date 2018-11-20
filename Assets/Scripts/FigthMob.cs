using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigthMob : Mob {

	[SerializeField] private int cooldown = 25;
	[SerializeField] private string attackname = "ShadowBall";
	protected bool active = false;
	private int temp=1;
	private Attack attack;
	new protected void Awake(){
		base.Awake();
		attack = Resources.Load<Attack>(attackname);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player")
			active = true;
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player")
			active = false;
	}

	protected void Update () {
		if(active){
			sprite.flipX = Wheel.playerX > transform.position.x;
			temp--;
			if(temp == 0){
				temp = cooldown;
				Shoot();
			}
		}
	}

	private void Shoot(){
		Vector3 position = transform.position;
		position.x += (sprite.flipX ? 0.5f: -0.5f);
		Attack newAttack = Instantiate(attack,position,attack.transform.rotation) as Attack;
		newAttack.Direction = newAttack.transform.right *(sprite.flipX ? 1 : -1);
		newAttack.setFlip(sprite.flipX);
	}
}
