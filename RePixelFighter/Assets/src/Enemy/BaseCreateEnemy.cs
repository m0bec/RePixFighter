﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCreateEnemy : MonoBehaviour {
	
	GameObject str_obj;
	public GameObject et_fighter_bg;
	protected void CreateETFighterBG(Vector3 create_pos_, float hp_, int score_, int move_type_, int shot_type_, int bullet_type_, float bullet_speed_, float move_speed_,
	GameObject enemy_move_controller_, GameObject enemy_shot_controller_){
		str_obj = Instantiate(et_fighter_bg, create_pos_, Quaternion.identity);
		str_obj.GetComponent<ETFighterBG>().SetStatus(hp_, score_, move_type_, shot_type_, bullet_type_, bullet_speed_, move_speed_,
	 	enemy_move_controller_, enemy_shot_controller_);
	}
}