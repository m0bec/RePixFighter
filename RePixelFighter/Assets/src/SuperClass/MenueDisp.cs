using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueDisp : MonoBehaviour {
	public StopGameTime stop_game_time = StopGameTime.Instance;
	// Use this for initialization
	void Start () {

	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Q)){
			if(!stop_game_time.StopFlag){
				stop_game_time.StopFlag = true;
			}else{
				stop_game_time.StopFlag = false;
			}
		}
	}
}
