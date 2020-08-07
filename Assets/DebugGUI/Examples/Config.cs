using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config : MonoBehaviour {

	// Use this for initialization
	public  Dropdown dropdownMenu;
	public static int selected_index = 0 ;
	public static bool enable = false;
	public static int playback_speed = 1;
	// public static string joint_angles_file_name = "session4_joint angles";
	public static string joint_angles_file_name = "walking2";

	public static bool ran = false;
	static string X = "FlexExt";
	static string Y = "AbdAdd";
	static string Z = "IntExt";

	public static string Hip_RT_X = "Right_Hip_"+X;
	public static string Hip_RT_Z = "Right_Hip_"+Z;
	public static string Hip_RT_Y = "Right_Hip_"+Y;
	public static string Hip_LT_X = "Left_Hip_"+X;
	public static string Hip_LT_Z = "Left_Hip_"+Z;
	public static string Hip_LT_Y = "Left_Hip_"+Y;
	public static string Knee_RT_X = "Right_Knee"+X;
	public static string Knee_RT_Z = "Right_Knee"+Z;
	public static string Knee_RT_Y = "Right_Knee"+Y;
	public static string Knee_LT_X = "Left_Knee"+X;
	public static string Knee_LT_Z = "Left_Knee"+Z;
	public static string Knee_LT_Y = "Left_Knee"+Y;
	void Start () {
		// dropdownMenu = GetComponent<Dropdown>();
	}
	
	// Update is called once per frame
	void Update () {
		 selected_index = this.dropdownMenu.value;
	}
}
