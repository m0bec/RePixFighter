using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOneScroll : BaseScrollMap {

	const float STAGE_ONE_SCROLL_SPEED = 10.0f;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		base.ScrollSpeed = STAGE_ONE_SCROLL_SPEED;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}
}
