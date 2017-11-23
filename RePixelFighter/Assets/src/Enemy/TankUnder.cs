using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUnder : BaseEnemy {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(base.data_keeper.StageNum == (int)Stage.One){
			Vector3 pos = this.transform.position;
			pos.y -= ScrollSpeedStruct.One;
			this.transform.position = pos;
		}
	}
}
