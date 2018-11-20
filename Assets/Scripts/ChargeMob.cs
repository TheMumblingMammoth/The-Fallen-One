using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeMob : FigthMob {

	
	new void Update () {
		base.Update();
		if(!active)
			Run();
	}
}
