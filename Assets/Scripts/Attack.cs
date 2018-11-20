using UnityEngine;

public class Attack : MonoBehaviour {
	[SerializeField]private float speed=10f;
	[SerializeField]private float lifetime = 3f;
	[SerializeField]private TargetType Target = TargetType.Player;
	[SerializeField]private int Damage = 1;
	private Vector3 direction;
	public Vector3 Direction{ set {direction = value;} }
	private Animator animator;
	private SpriteRenderer sprite;
	private AttState State{
		get {return(AttState)animator.GetInteger("State");}
		set { animator.SetInteger("State", (int)value);}
	}
	void Awake () {
		animator = GetComponent<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	void Start(){
		Destroy(gameObject, lifetime);
	}
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position,transform.position + direction, speed*Time.deltaTime);	
		State = AttState.Fly;
	}

	public void setFlip(bool flag){
		sprite.flipX = !flag;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other is BoxCollider2D){
			switch (Target){
				case TargetType.Player: 
					if(other.tag == "Player")
						other.GetComponent<Player>().TakeDamage(Damage);
					break;
				case TargetType.Mobs: 
					if(other.tag == "Mob")
						other.GetComponent<Mob>().TakeDamage(Damage);
					break;
			}		
		}
	}
}

public enum TargetType{
	Player,Mobs
}
public enum AttState{
	Fly,Hit
}