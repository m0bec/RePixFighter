using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankUpper : MonoBehaviour {
	public DataKeeper data_keeper = DataKeeper.Instance;

	void Update () {
		LookAtPlayer();
	}

	const float ROTATE_SPEED = 0.1f;
	Vector3 subtraction_pos;
	float angle;
	Quaternion goal_rotation;
	Quaternion str_angle;
	void LookAtPlayer(){
		subtraction_pos = data_keeper.PlayerPos - this.transform.position;
		angle = Mathf.Atan2(subtraction_pos.y, subtraction_pos.x) * Mathf.Rad2Deg;
		goal_rotation.eulerAngles = new Vector3(0, 0, angle - 90.0f);
		this.transform.rotation = goal_rotation;
	}
}
