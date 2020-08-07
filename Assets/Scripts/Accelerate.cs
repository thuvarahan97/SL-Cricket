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
		data = CSV_Reader.Read (Config.joint_angles_file_name);

	}
	
	int n = 0;
	int i = 0;
	
 	string Hip_RT_X = Config.Hip_RT_X;
	string Hip_RT_Y = Config.Hip_RT_Y;
	string Hip_RT_Z = Config.Hip_RT_Z;
	string Hip_LT_X = Config.Hip_LT_X;
	string Hip_LT_Y = Config.Hip_LT_Y;
	string Hip_LT_Z = Config.Hip_LT_Z;
	string Knee_RT_X = Config.Knee_RT_X;
	string Knee_RT_Y = Config.Knee_RT_Y;
	string Knee_RT_Z = Config.Knee_RT_Z;
	string Knee_LT_X = Config.Knee_LT_X;
	string Knee_LT_Y = Config.Knee_LT_Y;
    string Knee_LT_Z = Config.Knee_LT_Z;

	float Hip_RT_X_increase = 0f;
	float Hip_RT_Y_increase = 0f;
	float Hip_RT_Z_increase = 0f;
	float Hip_LT_X_increase = 0f;
	float Hip_LT_Y_increase = 0f;
	float Hip_LT_Z_increase = 0f;
	float Knee_RT_X_increase = 0f;
	float Knee_RT_Y_increase = 0f;
	float Knee_RT_Z_increase = 0f;
	float Knee_LT_X_increase = 0f;
	float Knee_LT_Y_increase = 0f;
    float Knee_LT_Z_increase = 0f;


	// Update is called once per frame
	void Update () {

		if(Config.enable == true){
			if (!paused && i<data.Count) {

				if (n%Config.playback_speed==0){

					if(i>0) {

						transform.GetChild(1).GetChild(1).Rotate((float)data[i][Hip_RT_X]-(float)data[i-1][Hip_RT_X],0,0);
						transform.GetChild(1).GetChild(1).Rotate(0,(float)data[i][Hip_RT_Y]-(float)data[i-1][Hip_RT_Y],0);
						transform.GetChild(1).GetChild(1).Rotate(0,0,(float)data[i][Hip_RT_Z]-(float)data[i-1][Hip_RT_Z]);
						
						transform.GetChild(1).GetChild(0).Rotate((float)data[i][Hip_LT_X]-(float)data[i-1][Hip_LT_X],0,0);
						transform.GetChild(1).GetChild(0).Rotate(0,(float)data[i][Hip_LT_Y]-(float)data[i-1][Hip_LT_Y],0);
						transform.GetChild(1).GetChild(0).Rotate(0,0,(float)data[i][Hip_LT_Z]-(float)data[i-1][Hip_LT_Z]);

						transform.GetChild(1).GetChild(1).GetChild(0).Rotate((float)data[i][Knee_RT_X]-(float)data[i-1][Knee_RT_X],0,0);
						transform.GetChild(1).GetChild(1).GetChild(0).Rotate(0,(float)data[i][Knee_RT_Y]-(float)data[i-1][Knee_RT_Y],0);
						transform.GetChild(1).GetChild(1).GetChild(0).Rotate(0,0,(float)data[i][Knee_RT_Z]-(float)data[i-1][Knee_RT_Z]);

						transform.GetChild(1).GetChild(0).GetChild(0).Rotate((float)data[i][Knee_LT_X]-(float)data[i-1][Knee_LT_X],0,0);
						transform.GetChild(1).GetChild(0).GetChild(0).Rotate(0,(float)data[i][Knee_LT_Y]-(float)data[i-1][Knee_LT_Y],0);
						transform.GetChild(1).GetChild(0).GetChild(0).Rotate(0,0,(float)data[i][Knee_LT_Z]-(float)data[i-1][Knee_LT_Z]);
					
						// Showing angles of joints
						// angleTextLeftHip.text = 
						// "Left Hip Joint Angles: \n" +
						// "X: " + data[i][Hip_LT_X] + ", \n" + 
						// "Y: " + data[i][Hip_LT_Y] + ", \n" + 
						// "Z: " + data[i][Hip_LT_Z];

						// angleTextLeftKnee.text = 
						// "Left Knee Joint Angles: \n" +
						// "X: " + data[i][Knee_LT_X] + ", \n" + 
						// "Y: " + data[i][Knee_LT_Y] + ", \n" + 
						// "Z: " + data[i][Knee_LT_Z];

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
