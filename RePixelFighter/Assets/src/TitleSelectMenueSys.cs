using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelectMenueSys : MonoBehaviour {
	public enum TitleMenueStateName{
		start, config, record, info, exit
	}
	// Use this for initialization
	void Start () {
		menue_state = (int)TitleMenueStateName.start;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeMenueState();
	}

	int menue_state;
	public int MenueState{
		get{  return menue_state;  }
	}
	void ChangeMenueState(){
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			menue_state++;
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			menue_state--;
		}
		if(menue_state > (int)TitleMenueStateName.exit){
			menue_state = (int)TitleMenueStateName.start;
		}else if(menue_state < (int)TitleMenueStateName.start){
			menue_state = (int)TitleMenueStateName.exit;
		}
	}
}
