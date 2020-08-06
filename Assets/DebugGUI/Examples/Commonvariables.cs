using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commonvariables : MonoBehaviour {

	// Use this for initialization
	public  Dropdown dropdownMenu;
	public static int selected_index = 0 ;
	public static bool enable = false;
	public static int playback_speed = 1;
	public static string joint_angles_file_name = "walking data";

	public static bool ran = false;
	void Start () {
		// dropdownMenu = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		 selected_index = this.dropdownMenu.value;
	}
}
