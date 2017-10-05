using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	public StopGameTime stop_game_time = StopGameTime.Instance;
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			Move();
			Shot();
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

	public GameObject bullet;
	const float SHOT_RIGHT = 10.0f;
	const float SHOT_LEFT = -10.0f;
	const float SHOT_FRONT_MARGINE = 1.0f;
	const float SHOT_COOL_TIME = 0.05f;
	float shot_time = SHOT_COOL_TIME;
	
	void Shot(){
		if(Input.GetKeyDown(KeyCode.Z)){
			shot_time = SHOT_COOL_TIME;
		}

		if(Input.GetKey(KeyCode.Z)){
			if(shot_time >= SHOT_COOL_TIME){
				Instantiate(bullet, new Vector3(
					this.transform.position.x + SHOT_RIGHT,
					this.transform.position.y,
					this.transform.position.z + SHOT_FRONT_MARGINE
				),
				Quaternion.identity);
				Instantiate(bullet, new Vector3(
					this.transform.position.x + SHOT_LEFT,
					this.transform.position.y,
					this.transform.position.z + SHOT_FRONT_MARGINE
				),
				Quaternion.identity);

				shot_time = 0.0f;
			}else{
				shot_time += Time.deltaTime;
			}
		}
	}
}
