﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{
	et_fighter_bg, tank_obj
}

public class BaseCreateEnemy : MonoBehaviour {
	GameObject str_obj;

	public void CreateEnemy(Vector3 create_pos_, float hp_, int score_, int move_type_, int shot_type_, int bullet_type_, int bullet_color_,
	 float bullet_speed_, float move_speed_, int enemy_type_, GameObject enemy_move_controller_, GameObject enemy_shot_controller_){
		switch(enemy_type_){
			case (int)EnemyType.et_fighter_bg:
				CreateETFighterBG(create_pos_, hp_, score_, move_type_, shot_type_, bullet_type_, bullet_color_, bullet_speed_, move_speed_,
				  enemy_move_controller_, enemy_shot_controller_);
				break;

			case (int)EnemyType.tank_obj:
				CreateTank(create_pos_, hp_, score_, move_type_, shot_type_, bullet_type_, bullet_color_, bullet_speed_, move_speed_,
				  enemy_move_controller_, enemy_shot_controller_);
				break;
		}
	}
	
	public GameObject et_fighter_bg;
	protected void CreateETFighterBG(Vector3 create_pos_, float hp_, int score_, int move_type_, int shot_type_, int bullet_type_, int bullet_color_,
	 float bullet_speed_, float move_speed_, GameObject enemy_move_controller_, GameObject enemy_shot_controller_){
		str_obj = Instantiate(et_fighter_bg, create_pos_, Quaternion.Euler(30.0f, 0.0f, 0.0f));
		str_obj.GetComponent<ETFighterBG>().SetStatus(hp_, score_, move_type_, shot_type_, bullet_type_, bullet_speed_, move_speed_,
	 	enemy_move_controller_, enemy_shot_controller_);
	}

	public GameObject tank_obj;
	protected void CreateTank(Vector3 create_pos_, float hp_, int score_, int move_type_, int shot_type_, int bullet_type_, int bullet_color_,
	 float bullet_speed_, float move_speed_, GameObject enemy_move_controller_, GameObject enemy_shot_controller_){
		str_obj = Instantiate(tank_obj, create_pos_, Quaternion.Euler(30.0f, 0.0f, 0.0f));
		str_obj.GetComponent<TankUnder>().SetStatus(hp_, score_, move_type_, shot_type_, bullet_type_, bullet_speed_, move_speed_,
	 	enemy_move_controller_, enemy_shot_controller_);
	}
}
