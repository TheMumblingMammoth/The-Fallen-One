using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
	[SerializeField] private float rangeX = 6, rangeY=4, speed = 3f;
	[SerializeField] private GameObject target;
	void Update () {
		if(target.transform.position.x > transform.position.x + rangeX)
			transform.position = Vector3.MoveTowards(transform.position, transform.position  + transform.right, speed * Time.deltaTime);
		if(target.transform.position.x < transform.position.x - rangeX)
			transform.position = Vector3.MoveTowards(transform.position, transform.position  - transform.right, speed * Time.deltaTime);
		
		transform.position = Vector3.MoveTowards(transform.position, transform.position  + transform.up, target.transform.position.y - transform.position.y + rangeY);	
	}
}
