﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {
	public const float DAMAGE = 1.0f;
	const float MOVE_SPEED = 10.0f;

	float width, height;
	// Use this for initialization
	void Start () {
		width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
		height = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
	}
	
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	Vector3 next_pos;
	void Move(){
		next_pos = this.transform.position;
		next_pos.y += MOVE_SPEED;
		if(next_pos.y > GameDispRange.UP_LIIMT + height){
			Destroy(this.gameObject);
		}else if(next_pos.y < GameDispRange.DOWN_LIMIT - height){
			Destroy(this.gameObject);
		}
		this.transform.position = next_pos;
	}
}