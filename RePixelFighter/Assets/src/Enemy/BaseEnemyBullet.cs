using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyBullet : MonoBehaviour {
	float width, height;
	// Use this for initialization
	void Start () {
		width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	public StopGameTime stop_game_time = StopGameTime.Instance;
	public GameObject enemy_bullet_controller;
	Vector3 pos;
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			Move();
		}
	}

	void Move(){
		pos = this.gameObject.transform.position;
		pos = enemy_bullet_controller.GetComponent<EnemyBulletController>().EnemyBulletMove(pos, bullet_type, bullet_speed);
		if(pos.y > GameDispRange.UP_LIIMT + height + GameDispRange.MARGIN){
			Destroy(this.gameObject);
		}else if(pos.y < GameDispRange.DOWN_LIMIT - height - GameDispRange.MARGIN){
			Destroy(this.gameObject);
		}
		if(pos.x > GameDispRange.RIGHT_LIMIT + width + GameDispRange.MARGIN){
			Destroy(this.gameObject);
		}else if(pos.x < GameDispRange.LEFT_LIMIT - width - GameDispRange.MARGIN){
			Destroy(this.gameObject);
		}
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
