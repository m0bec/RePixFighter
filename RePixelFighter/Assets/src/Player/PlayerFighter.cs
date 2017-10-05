using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	MenueDisp menue_disp;
	// Use this for initialization
	void Start () {
		menue_disp = GameObject.Find("MenueDisp").GetComponent<MenueDisp>();
	}
	
	// Update is called once per frame
	void Update () {
		if(menue_disp.StopGameFlag){

		}else{
			Move();
		}
	}

	Vector3 now_pos;
	const float MOVE_NORMAL_SPEED = 4.0f;
	void Move(){
		now_pos = this.transform.position;
		if(Input.GetKey(KeyCode.DownArrow)){
			now_pos.y -= MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			now_pos.y += MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			now_pos.x += MOVE_NORMAL_SPEED;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			now_pos.x -= MOVE_NORMAL_SPEED;
		}

		if(now_pos.x > GameDispRange.RIGHT_LIMIT){
			now_pos.x = GameDispRange.RIGHT_LIMIT;
		}
		if(now_pos.x < GameDispRange.LEFT_LIMIT){
			now_pos.x = GameDispRange.LEFT_LIMIT;
		}
		if(now_pos.y > GameDispRange.UP_LIIMT){
			now_pos.y = GameDispRange.UP_LIIMT;
		}
		if(now_pos.y < GameDispRange.DOWN_LIMIT){
			now_pos.y = GameDispRange.DOWN_LIMIT;
		}

		this.transform.position = now_pos;
	}
}
