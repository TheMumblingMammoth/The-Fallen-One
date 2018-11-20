using UnityEngine;

public class NPC : Character {

	override public void TakeDamage(int Damage){
		Die();
	}
	
	void Update () {
		State = CharState.Idle;
	}
}
