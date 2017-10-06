using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneCreateEnemy : BaseCreateEnemy {
	GameObject enemy_move_controller;
	GameObject enemy_shot_controller;
	// Use this for initialization
	void Start () {
		enemy_move_controller = GameObject.Find("EnemyMoveController");
		enemy_shot_controller = GameObject.Find("EnemyShotController");
	}
	const float OBJ_HEIGHT = -30.0f;

	float timer;
	int swich_controller = 0;
	public StopGameTime stop_game_time = StopGameTime.Instance;
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			timer += Time.deltaTime;
			switch(swich_controller){
				case 0:
					if(timer > 3.0f){
						base.CreateETFighterBG(new Vector3(100, 300, OBJ_HEIGHT), 10, 5, (int)EnemyMoveNum.straight_down,
						(int)EnemyShotNum.single_shot, (int)EnemyBulletName.straight_front, 3.0f, 1.0f, enemy_move_controller, enemy_shot_controller);
						swich_controller++;
					}
					break;

				case 1:

			 		break;
		}
		}
	}
}
