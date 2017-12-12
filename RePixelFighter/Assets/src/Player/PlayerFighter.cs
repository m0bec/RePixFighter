using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour {
	// Use this for initialization
	void Start () {
		data_keeper.PlayerPos = this.transform.position;
	}
	
	public StopGameTime stop_game_time = StopGameTime.Instance;
	public DataKeeper data_keeper = DataKeeper.Instance;
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			if(respone_fin_flag){
				Invalid();
				Move();
				Shot();
			}else{
				ResponeAction();
			}
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

		this.transform.position = data_keeper.PlayerPos = now_pos;
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

	const float RETRY_POS_Z = -100.0f; 
	public GameObject death_effect;
	void OnTriggerEnter2D(Collider2D other){
		if(!invalid_flag){
			if(other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Enemy")){
				Instantiate(death_effect, this.gameObject.transform.position, Quaternion.identity);
				data_keeper.Zanki = data_keeper.Zanki - 1;
				this.gameObject.transform.position = new Vector3(0.0f, -300.0f, RETRY_POS_Z);
				respone_fin_flag = false;
			}
		}
	}

	bool invalid_flag = false;
	const float INVALID_TIME = 2.0f;
	float timer = 0.0f;
	void Invalid(){
		if(invalid_flag){
			timer += Time.deltaTime;
			if(timer > INVALID_TIME){
				invalid_flag = false;
				timer = 0.0f;
			}	
		}
	}

	const float RESPONE_FIN_Y = GameDispRange.DOWN_LIMIT + 10.0f;
	const float RESPONS_MOVE_SPEED = 4.0f;
	Vector3 str_pos;
	bool respone_fin_flag = true;
	void ResponeAction(){
		invalid_flag = true;
		str_pos = this.gameObject.transform.position;
		str_pos.y += RESPONS_MOVE_SPEED;
		this.gameObject.transform.position = str_pos;
		if(str_pos.y > RESPONE_FIN_Y){
			respone_fin_flag = true;
		}

	}
}
