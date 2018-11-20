using UnityEngine;
public class Wheel : MonoBehaviour {
	public static int rage=30, sanity=30, pain=30;
	public static float playerX, playerY;
	private static int minR=10, minS=10, minP=10;
	
	void Update(){
		playerX = transform.position.x;
		playerY = transform.position.y;
	}

	static int Total(){
		return rage+sanity+pain;
	}
	public static void AddPain(int i){
		pain +=i;
		rage -=i;
		if(rage<minR)
			AddRage(minR-rage);
	}
	public static void AddRage(int i){
		rage +=i;
		sanity -=i;
		if(sanity<minS)
			AddSanity(minS-sanity);
	}
	public static void AddSanity(int i){
		sanity +=i;
		pain -=i;
		if(pain<minP)
			AddPain(minP-pain);
	}

}
