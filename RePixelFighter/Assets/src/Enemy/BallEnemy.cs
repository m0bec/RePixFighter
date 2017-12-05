using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnemy : BaseEnemy {
	const float ROLL_SPEED = 5.0f;
	public float angle;
	public bool f;
	// Use this for initialization
	void Start () {
		f = true;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(!stop_game_time.StopFlag){
			if(f)	this.transform.Rotate(new Vector3(0, 4, 0));
			else	this.transform.Rotate(new Vector3(0, -4, 0));
			if(f && this.transform.localEulerAngles.y < 100 && this.transform.localEulerAngles.y > 90)	f = false;
			if(!f && this.transform.localEulerAngles.y > 250 && this.transform.localEulerAngles.y < 270 ) f = true;
			
		}
		angle = this.transform.localEulerAngles.y ;
	}
}
