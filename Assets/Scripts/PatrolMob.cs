using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMob : FigthMob {

	private float startX;
	[SerializeField] private float patrolrange = 1;
	new void Awake(){
		base.Awake();
		startX = transform.position.x;
	}
	new void Update () {
		base.Update();
		if(!active){
			if(Mathf.Abs(transform.position.x - startX) > patrolrange)
				sprite.flipX = !sprite.flipX;
			Run();
		}
	}
}
