using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour {

	Vector3 pos;
	public GameObject bullet;
	public StopGameTime stop_game_time = StopGameTime.Instance;
	public DataKeeper data_keeper = DataKeeper.Instance;
	// Update is called once per frame
	protected virtual void Update () {
		if(!stop_game_time.StopFlag){
			Move();
			Shot();
			Death();
		}
	}

	void Shot(){
		enemy_shot_controller.GetComponent<EnemyShotController>().Shot(this.gameObject.transform.position, shot_type, bullet, bullet_type, bullet_colr, bulle_speed, ref timer);
	}

	float timer = 0.0f;
	void Move(){
		pos = enemy_move_controller.GetComponent<EnemyMoveController>().Move(this.gameObject.transform.position, move_type, move_speed);
		if(in_flag){
			if(pos.y > GameDispRange.UP_LIIMT + this.transform.localScale.y + GameDispRange.MARGIN){
				Destroy(this.gameObject);
			}else if(pos.y < GameDispRange.DOWN_LIMIT - this.transform.localScale.y - GameDispRange.MARGIN){
				Destroy(this.gameObject);
			}
			if(pos.x > GameDispRange.RIGHT_LIMIT + this.transform.localScale.x + GameDispRange.MARGIN){
				Destroy(this.gameObject);
			}else if(pos.x < GameDispRange.LEFT_LIMIT - this.transform.localScale.x - GameDispRange.MARGIN){
				Destroy(this.gameObject);
			}
		}

		this.gameObject.transform.position = pos;
		InCheck();
	}

	bool in_flag = false;
	void InCheck(){
		if(pos.y < GameDispRange.UP_LIIMT + this.transform.localScale.y + GameDispRange.MARGIN
		&& pos.y > GameDispRange.DOWN_LIMIT - this.transform.localScale.y - GameDispRange.MARGIN
		&& pos.x < GameDispRange.RIGHT_LIMIT + this.transform.localScale.x + GameDispRange.MARGIN
		&& pos.x > GameDispRange.LEFT_LIMIT - this.transform.localScale.x - GameDispRange.MARGIN){
			in_flag = true;
		}
	}

	public float hp;
	public float HP{
		get{  return hp;  }
		set{  hp = value;  }
	}
	int  score;
	int move_type;
	int shot_type;
	int bullet_type;
	int bullet_colr;
	float bulle_speed;
	float move_speed;
	GameObject enemy_move_controller;
	GameObject enemy_shot_controller;

	public void SetStatus(float hp_, int score_, int move_type_, int shot_type_, int bullet_type_, int bullet_colr_, float bullet_speed_, 
	float move_speed_, GameObject enemy_move_controller_, GameObject enemy_shot_controller_){
		hp = hp_;
		score = score_;
		move_type = move_type_;
		shot_type = shot_type_;
		bullet_type = bullet_type_;
		bullet_colr = bullet_colr_;
		move_speed = move_speed_;
		bulle_speed = bullet_speed_;
		enemy_move_controller = enemy_move_controller_;
		enemy_shot_controller = enemy_shot_controller_;
	}

	public GameObject death_effect;
	void Death(){
		if(hp <= 0){
			data_keeper.Score = score + data_keeper.Score;
			Instantiate(death_effect, this.gameObject.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if(pos.y < GameDispRange.UP_LIIMT + this.transform.localScale.y
		&& pos.y > GameDispRange.DOWN_LIMIT - this.transform.localScale.y
		&& pos.x < GameDispRange.RIGHT_LIMIT + this.transform.localScale.x
		&& pos.x > GameDispRange.LEFT_LIMIT - this.transform.localScale.x){
			if(other.gameObject.CompareTag("PlayerBullet")){
				hp -= other.gameObject.GetComponent<PlayerBullet>().DAMAGE;
				Destroy(other.gameObject);
			}
		}
	}	
}
