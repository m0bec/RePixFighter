﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRecord : BaseTitleMenueSelect {

	// Use this for initialization
	protected override void Start () {
		base.Start();
		base.StateNum = (int)TitleSelectMenueSys.TitleMenueStateName.record;
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
			
		}
	}
}
