using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitychanTimer : MonoBehaviour {
	private Text myText;
	private int minite;
	private float second;
	private int oldSecond;

	void Start () {
		myText = GetComponentInChildren<Text>();
		myText.text = "00:00";
		minite = 0;
		second = 0.0f;
		oldSecond = 0;
		myText.text = minite.ToString ("00") + ":" + ((int)second).ToString ("00");
	}
	
	void Update () {
		if(Time.timeScale > 0) {
			second += Time.deltaTime;
			if(second >= 60.0f) {
				minite++;
				second = second - 60;
			}
			if((int)second != oldSecond) {
				myText.text = minite.ToString("00") + ":" + ((int)second).ToString("00");
			}
			oldSecond = (int)second;
		}

	}
}
