using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commonvariables : MonoBehaviour {

	// Use this for initialization
	public  Dropdown dropdownMenu;
	public static int selected_inde = 0 ;
	public static bool enableee = false;

	public static bool ran = false;
	void Start () {
		// dropdownMenu = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		 selected_inde = this.dropdownMenu.value;
	}
}
