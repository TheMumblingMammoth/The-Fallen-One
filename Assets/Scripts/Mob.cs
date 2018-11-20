using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Character {

	[SerializeField] protected int HP = 3;
	
	override public void TakeDamage(int Damage){
		HP -=  Damage;
		if(HP<=0)
			Die();
	}
	
	void Update () {
		CheckGround();
		if(isGrounded && HP>0)
			State = CharState.Idle;
	}
}
