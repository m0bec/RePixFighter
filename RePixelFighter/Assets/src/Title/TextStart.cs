using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextStart : BaseTitleMenueSelect {

	GameObject load_graph;
	// Use this for initialization
	protected override void Start () {
		base.Start();
		base.StateNum = (int)TitleSelectMenueSys.TitleMenueStateName.start;
		load_graph = GameObject.Find("LoadDisp");
		load_graph.SetActive(false);
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
			load_graph.SetActive(true);
			StartCoroutine(AsynLoad());
		}
	}

	AsyncOperation async;
	private IEnumerator AsynLoad(){
    	async = SceneManager.LoadSceneAsync("SelectDifficult");

		while(!async.isDone){
			yield return null;
		}
	}
}
