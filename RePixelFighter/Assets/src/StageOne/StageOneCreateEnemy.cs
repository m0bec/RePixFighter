using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneCreateEnemy : BaseCreateEnemy {
	GameObject enemy_move_controller;
	GameObject enemy_shot_controller;
	int enemy_array_num;
	CreatePatternArray[] enemy_create_array;
	// Use this for initialization
	void Start () {
		enemy_move_controller = GameObject.Find("EnemyMoveController");
		enemy_shot_controller = GameObject.Find("EnemyShotController");
		enemy_array_num = 0;
		enemy_create_array = new CreatePatternArray[]{
		new CreatePatternArray {type_ = (int)StateInStage.Normal, time_ = 3.0f, create_pos_ = new Vector3(100, 300, OBJ_HEIGHT), 
						hp_ = 10, score_ = 5, move_type_ = (int)EnemyMoveNum.straight_down, shot_type_ = (int)EnemyShotNum.single_shot,
						bullet_type_ = (int)EnemyBulletName.straight_front, bullet_speed_ = 3.0f, move_speed_ = 1.0f,
						enemy_move_controller_ = enemy_move_controller, enemy_shot_controller_ = enemy_shot_controller},
		new CreatePatternArray {type_ = (int)StateInStage.MiddleBoss, time_ = 3.0f, create_pos_ = new Vector3(100, 300, OBJ_HEIGHT),
						hp_ = 10, score_ = 5, move_type_ = (int)EnemyMoveNum.straight_down, shot_type_ = (int)EnemyShotNum.single_shot,
						bullet_type_ = (int)EnemyBulletName.straight_front, bullet_speed_ = 3.0f, move_speed_ = 1.0f,
						enemy_move_controller_ = enemy_move_controller, enemy_shot_controller_ = enemy_shot_controller}
		};
	}
	const float OBJ_HEIGHT = -50.0f;

	float timer;
	int swich_controller = (int)StateInStage.Normal;
	public StopGameTime stop_game_time = StopGameTime.Instance;

	
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			timer += Time.deltaTime;
			swich_controller = enemy_create_array[enemy_array_num].type_;
			switch(swich_controller){
				case (int)StateInStage.Normal:
					if(timer > enemy_create_array[enemy_array_num].time_){
					base.CreateETFighterBG(enemy_create_array[enemy_array_num].create_pos_, enemy_create_array[enemy_array_num].hp_,
				 	 enemy_create_array[enemy_array_num].score_, enemy_create_array[enemy_array_num].move_type_,
				 	 enemy_create_array[enemy_array_num].shot_type_, enemy_create_array[enemy_array_num].bullet_type_,
				 	 enemy_create_array[enemy_array_num].bullet_speed_, enemy_create_array[enemy_array_num].move_speed_,
				 	 enemy_create_array[enemy_array_num].enemy_move_controller_, enemy_create_array[enemy_array_num].enemy_shot_controller_);
					enemy_create_array[enemy_array_num].GoNext(ref enemy_array_num);
				}
				break;

				case (int)StateInStage.MiddleBoss:
				break;
			}
			
		}
	}
}
