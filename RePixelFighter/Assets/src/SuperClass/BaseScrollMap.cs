using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScrollMap : MonoBehaviour {

	public float this_plane_height;
	Vector3 plane_start_pos;
	GameObject another_plane;
	public DataKeeper data_keeper = DataKeeper.Instance;
	// Use this for initialization
	protected virtual void Start () {
		plane_start_pos = this.gameObject.transform.position;
		this_plane_height = this.GetComponent<Renderer>().bounds.size.y;
		if(!data_keeper.ScrollPlaneCreateFin){
			another_plane = Instantiate(this.gameObject,
				new Vector3(plane_start_pos.x, plane_start_pos.y - this_plane_height, plane_start_pos.z),
				this.transform.rotation);
			data_keeper.ScrollPlaneCreateFin = true;
		}
	}
	
	
	// Update is called once per frame
	protected virtual void Update () {
		Scroll();
		ReMove();
	}

	float scroll_speed;
	protected float ScrollSpeed{
		get{  return scroll_speed;  }
		set{  scroll_speed = value;  }
	}

	Vector3 str_pos;
	void Scroll(){
		str_pos = this.gameObject.transform.position;
		str_pos.y -= scroll_speed;
		this.gameObject.transform.position = str_pos;
	}

	const float DISP_HEIGHT = 480;
	void ReMove(){
		if(this.gameObject.transform.position.y < -(DISP_HEIGHT + this_plane_height)){
			str_pos = this.gameObject.transform.position;
			str_pos.y += 2 * this_plane_height;
			this.gameObject.transform.position = str_pos;
		}
	}
}
