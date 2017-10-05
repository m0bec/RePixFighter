using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour {
	Vector3 pos;
	public Vector3 EnemyBulletMove(Vector3 pos_, int bullet_num_, float speed_){
		pos = pos_;
		switch(bullet_num_){
			case (int)EnemyBulletName.straight_front:
				pos.y -= speed_;
				break;
		}

		return pos;
	}
}
