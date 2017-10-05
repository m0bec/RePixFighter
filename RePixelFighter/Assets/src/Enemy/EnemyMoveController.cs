using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Vector3 pos;
	public Vector3 Move(Vector3 pos_, int move_num_, float move_speed_){
		pos = pos_;
		switch(move_num_){
			case (int)EnemyMoveNum.straight_down:
				pos.y -= move_speed_;
				break;
		}

		return pos;
	}
}
