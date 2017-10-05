using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFighterPropella : MonoBehaviour {
	const float ROLL_SPEED = 10.0f;
	public StopGameTime stop_game_time = StopGameTime.Instance;
	// Update is called once per frame
	void Update () {
		if(!stop_game_time.StopFlag){
			this.transform.Rotate(new Vector3(0.0f, ROLL_SPEED, 0.0f));
		}
	}
}
