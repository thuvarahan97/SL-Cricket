using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerate : MonoBehaviour {

	// Use this for initialization
	List<Dictionary<string,object>> data;

    public bool paused = false;

	private Text angleTextLeftHip;
	private Text angleTextLeftKnee;
	private Text angleTextRightHip;
	private Text angleTextRightKnee;

	void Awake() {
        angleTextLeftHip = GameObject.Find("AngleTextLeftHip").GetComponent<Text>();
        angleTextLeftKnee = GameObject.Find("AngleTextLeftKnee").GetComponent<Text>();
        angleTextRightHip = GameObject.Find("AngleTextRightHip").GetComponent<Text>();
        angleTextRightKnee = GameObject.Find("AngleTextRightKnee").GetComponent<Text>();
	}

	void Start () {
		// data = CSV_Reader.Read ("Joint angles1");
		data = CSV_Reader.Read (Commonvariables.joint_angles_file_name);

	}
	
	int n = 0;
	int i = 0;
	
	string Hip_RT_X = "Right_Hip_FlexExt";
	string Hip_RT_Y = "Right_Hip_AbdAdd";
	string Hip_RT_Z = "Right_Hip_IntExt";
	string Hip_LT_X = "Left_Hip_FlexExt";
	string Hip_LT_Y = "Left_Hip_AbdAdd";
	string Hip_LT_Z = "Left_Hip_IntExt";
	string Knee_RT_X = "Right_KneeFlexExt";
	string Knee_RT_Y = "Right_KneeAbdAdd";
	string Knee_RT_Z = "Right_KneeIntExt";
	string Knee_LT_X = "Left_KneeFlexExt";
	string Knee_LT_Y = "Left_KneeAbdAdd";
	string Knee_LT_Z = "Left_KneeFlexExt";

	// Update is called once per frame
	void Update () {

		if(Commonvariables.enable == true){
			if (!paused && i<data.Count) {

				if (n%Commonvariables.playback_speed==0){

					if(i>0) {

						transform.GetChild(1).GetChild(1).Rotate((float)data[i][Hip_RT_X]-(float)data[i-1][Hip_RT_X],0,0);
						// transform.GetChild(1).GetChild(1).Rotate(0,(float)data[i][Hip_RT_Y]-(float)data[i-1][Hip_RT_Y],0);
						// transform.GetChild(1).GetChild(1).Rotate(0,0,(float)data[i][Hip_RT_Z]-(float)data[i-1][Hip_RT_Z]);
						
						transform.GetChild(1).GetChild(0).Rotate((float)data[i][Hip_LT_X]-(float)data[i-1][Hip_LT_X],0,0);
						// transform.GetChild(1).GetChild(0).Rotate(0,(float)data[i][Hip_LT_Y]-(float)data[i-1][Hip_LT_Y],0);
						// transform.GetChild(1).GetChild(0).Rotate(0,0,(float)data[i][Hip_LT_Z]-(float)data[i-1][Hip_LT_Z]);

						transform.GetChild(1).GetChild(1).GetChild(0).Rotate((float)data[i][Knee_RT_X]-(float)data[i-1][Knee_RT_X],0,0);
						// transform.GetChild(1).GetChild(1).GetChild(0).Rotate(0,(float)data[i][Knee_RT_Y]-(float)data[i-1][Knee_RT_Y],0);
						// transform.GetChild(1).GetChild(1).GetChild(0).Rotate(0,0,(float)data[i][Knee_RT_Z]-(float)data[i-1][Knee_RT_Z]);

						transform.GetChild(1).GetChild(0).GetChild(0).Rotate((float)data[i][Knee_LT_X]-(float)data[i-1][Knee_LT_X],0,0);
						// transform.GetChild(1).GetChild(0).GetChild(0).Rotate(0,(float)data[i][Knee_LT_Y]-(float)data[i-1][Knee_LT_Y],0);
						// transform.GetChild(1).GetChild(0).GetChild(0).Rotate(0,0,(float)data[i][Knee_LT_Z]-(float)data[i-1][Knee_LT_Z]);
					
						// Showing angles of joints
						angleTextLeftHip.text = 
						"Left Hip Joint Angles: \n" +
						"X: " + data[i][Hip_LT_X] + ", \n" + 
						"Y: " + data[i][Hip_LT_Y] + ", \n" + 
						"Z: " + data[i][Hip_LT_Z];

						angleTextLeftKnee.text = 
						"Left Knee Joint Angles: \n" +
						"X: " + data[i][Knee_LT_X] + ", \n" + 
						"Y: " + data[i][Knee_LT_Y] + ", \n" + 
						"Z: " + data[i][Knee_LT_Z];

						angleTextRightHip.text = 
						"Right Hip Joint Angles: \n" +
						"X: " + data[i][Hip_RT_X] + ", \n" + 
						"Y: " + data[i][Hip_RT_Y] + ", \n" + 
						"Z: " + data[i][Hip_RT_Z];

						angleTextRightKnee.text = 
						"Right Knee Joint Angles: \n" +
						"X: " + data[i][Knee_RT_X] + ", \n" + 
						"Y: " + data[i][Knee_RT_Y] + ", \n" + 
						"Z: " + data[i][Knee_RT_Z];

					}			
					
					if(i<data.Count){
						i++;
					}

				}

			n++;

			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				this.Pause();
			}
		}
	}
	
	void Pause() {
		paused = !paused;
	}	
}
