using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePatternArray{
	public int type_{set;get;}
	public float time_{set; get;}
	public Vector3 create_pos_{set; get;}
	public float hp_{set; get;}
	public int score_{set; get;}
	public int move_type_{set; get;}
	public int shot_type_{set; get;}
	public int bullet_type_{set; get;}
	public float bullet_speed_{set; get;}
	public float move_speed_{set; get;}
	public GameObject enemy_move_controller_{set; get;}
	public GameObject enemy_shot_controller_{set; get;}
	public void GoNext(ref int array_num_){
		array_num_++;
	}
}
