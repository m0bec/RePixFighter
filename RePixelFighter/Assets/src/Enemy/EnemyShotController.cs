using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotController : MonoBehaviour {
	GameObject enemy_bullet_controller;
	void Start(){
		enemy_bullet_controller = GameObject.Find("EnemyBulletController");
	}

	GameObject str_bullet;
	const float STRAIGHT_SHOT_SPEEd = 3.0f;
	
	public void Shot(Vector3 pos_, int shot_num_, GameObject bullet_, int bullet_num_, float bullet_speed_, ref float timer_){
		switch(shot_num_){
			case (int)EnemyShotNum.single_shot:
				if(timer_ > 2.0f){
					timer_ = 0;
					str_bullet = Instantiate(bullet_, pos_, Quaternion.identity);
					str_bullet.GetComponent<BaseEnemyBullet>().BulletType = bullet_num_;
					str_bullet.GetComponent<BaseEnemyBullet>().BulletSpeed = bullet_speed_;
					str_bullet.GetComponent<BaseEnemyBullet>().enemy_bullet_controller = enemy_bullet_controller;
				}else{
					timer_ += Time.deltaTime;
				}
				break;
		}
	}
}
