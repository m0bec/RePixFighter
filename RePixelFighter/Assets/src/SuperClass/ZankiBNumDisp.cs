using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZankiBNumDisp : MonoBehaviour {
	public DataKeeper data_keeper = DataKeeper.Instance;
	Text write_text;

	// Use this for initialization
	void Start () {
		write_text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		write_text.text = data_keeper.Zanki.ToString();
	}
}
