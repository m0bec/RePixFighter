using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneCreateEnemy : BaseCreateEnemy {
	GameObject enemy_move_controller;
	GameObject enemy_shot_controller;
	int enemy_array_num;
	CreatePatternArray[] enemy_create_array;
	CSVReader stage_one_reader = new CSVReader();
	// Use this for initialization
	void Start () {
		enemy_move_controller = GameObject.Find("EnemyMoveController");
		enemy_shot_controller = GameObject.Find("EnemyShotController");
		enemy_array_num = 0;
		stage_one_reader.CsvRead("StageOne", enemy_move_controller, enemy_shot_controller);
	}
	const float OBJ_HEIGHT = -50.0f;

	float timer;
	int swich_controller = (int)StateInStage.Normal;
	public StopGameTime stop_game_time = StopGameTime.Instance;
	bool read_flag;
	
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			timer += Time.deltaTime;
			swich_controller = stage_one_reader.enemy_data[enemy_array_num].type_;
			
			switch(swich_controller){
				case (int)StateInStage.Normal:
					if(timer > stage_one_reader.enemy_data[enemy_array_num].time_){
					base.CreateETFighterBG(stage_one_reader.enemy_data[enemy_array_num].create_pos_, stage_one_reader.enemy_data[enemy_array_num].hp_,
				 	stage_one_reader.enemy_data[enemy_array_num].score_, stage_one_reader.enemy_data[enemy_array_num].move_type_,
				 	 stage_one_reader.enemy_data[enemy_array_num].shot_type_, stage_one_reader.enemy_data[enemy_array_num].bullet_type_,
				 	 stage_one_reader.enemy_data[enemy_array_num].bullet_speed_, stage_one_reader.enemy_data[enemy_array_num].move_speed_,
				 	 stage_one_reader.enemy_data[enemy_array_num].enemy_move_controller_, stage_one_reader.enemy_data[enemy_array_num].enemy_shot_controller_);
					stage_one_reader.enemy_data[enemy_array_num].GoNext(ref enemy_array_num);
				}
				break;

				case (int)StateInStage.MiddleBoss:
				break;
			}
			
		}
	}
}
