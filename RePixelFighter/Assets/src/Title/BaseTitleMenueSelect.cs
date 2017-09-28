using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTitleMenueSelect : MonoBehaviour {
	TitleSelectMenueSys title_select_menue_system;

	public Color select_color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
	public Color not_select_color = new Color(96f / 255f, 88f / 255f, 88f / 255f);

	// Use this for initialization
	protected virtual void Start () {
		title_select_menue_system = GameObject.Find("TitleSelectMenueSys").GetComponent<TitleSelectMenueSys>();
	}

	// Update is called once per frame
	protected virtual void Update () {
		if(state_num == title_select_menue_system.MenueState){
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
}
