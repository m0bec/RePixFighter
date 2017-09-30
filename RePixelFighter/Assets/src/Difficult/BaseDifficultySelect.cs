using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseDifficultySelect : MonoBehaviour {
	SelectDifficultySys select_diffiulty_sys;

	public Color select_color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
	public Color not_select_color = new Color(96f / 255f, 88f / 255f, 88f / 255f);

	// Use this for initialization
	protected virtual void Start () {
		select_diffiulty_sys = GameObject.Find("SelectDifficultySys").GetComponent<SelectDifficultySys>();
	}

	// Update is called once per frame
	protected virtual void Update () {
		if(state_num == select_diffiulty_sys.MenueState){
			this.GetComponent<Text>().color = select_color;
			select_this = true;
		}else{
			this.GetComponent<Text>().color = not_select_color;
			select_this = false;
		}
	}

	int state_num;
	protected int StateNum{
		set{  state_num = value;  }
		get{  return state_num;  }
	}

	bool select_this = false;
	protected bool SelectThis{
		get{  return select_this;  }
	}

	public DataKeeper data_keeper = DataKeeper.Instance;
	protected void Setdifficulty(){
		data_keeper.Difficulty = state_num;
	}
}
