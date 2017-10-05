using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueDisp : MonoBehaviour {
	bool stop_game_flag;
	public bool StopGameFlag{
		get{  return stop_game_flag;  }
		set{  stop_game_flag = value;  }
	}

	// Use this for initialization
	void Start () {
		stop_game_flag = false;
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Q)){
			if(stop_game_flag){
				stop_game_flag = false;
			}else{
				stop_game_flag = true;
			}
		}
	}
}
