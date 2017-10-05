using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public GameObject enemy_bullet_controller;
	Vector3 pos;
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move(){
		pos = this.gameObject.transform.position;
		pos = enemy_bullet_controller.GetComponent<EnemyBulletController>().EnemyBulletMove(pos, bullet_type, bullet_speed);
		this.gameObject.transform.position = pos;
	}

	int bullet_type;
	public int BulletType{
		get{  return bullet_type;  }
		set{  bullet_type = value;  }
	}

	float bullet_speed;
	public float BulletSpeed{
		get{  return bullet_speed;  }
		set{  bullet_speed = value;  }
	}
}
