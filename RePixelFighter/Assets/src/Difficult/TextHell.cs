using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHell : BaseDifficultySelect {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		base.StateNum = (int)SelectDifficultySys.TitleDifficultyStateName.hell;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
		if(base.SelectThis){
			Action();
		}
	}

	void Action(){
		if(Input.GetKeyDown(KeyCode.Return)){
			base.Setdifficulty();
		}
	}
}
