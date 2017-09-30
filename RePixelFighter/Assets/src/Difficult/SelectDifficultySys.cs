using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficultySys : MonoBehaviour {
	public enum TitleDifficultyStateName{
		normal, hard, hell
	}
	// Use this for initialization
	void Start () {
		menue_state = (int)SelectDifficultySys.TitleDifficultyStateName.normal;
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
		if(menue_state > (int)SelectDifficultySys.TitleDifficultyStateName.hell){
			menue_state = (int)SelectDifficultySys.TitleDifficultyStateName.normal;
		}else if(menue_state < (int)SelectDifficultySys.TitleDifficultyStateName.normal){
			menue_state = (int)SelectDifficultySys.TitleDifficultyStateName.hell;
		}
	}
}
