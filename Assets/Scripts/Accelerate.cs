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
	Transform Hip_RT ;
	Transform Hip_LT;
	Transform Knee_RT;
	Transform Knee_LT;

	void Awake() {
        angleTextLeftHip = GameObject.Find("AngleTextLeftHip").GetComponent<Text>();
        angleTextLeftKnee = GameObject.Find("AngleTextLeftKnee").GetComponent<Text>();
        angleTextRightHip = GameObject.Find("AngleTextRightHip").GetComponent<Text>();
        angleTextRightKnee = GameObject.Find("AngleTextRightKnee").GetComponent<Text>();
	}

	void Start () {
		// data = CSV_Reader.Read ("Joint angles1");
		data = CSV_Reader.Read (Config.joint_angles_file_name);

		Hip_RT = transform.GetChild(1).GetChild(1);
		Hip_LT = transform.GetChild(1).GetChild(0);
		Knee_RT = transform.GetChild(1).GetChild(1).GetChild(0);
		Knee_LT = transform.GetChild(1).GetChild(0).GetChild(0);
	}
	
	float findIncrease(string name){
		return (float)data[i][name]-(float)data[i-1][name];
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
						
						// Hip_RT_X_increase = findIncrease(Hip_RT_X);
						// if ((Hip_RT.rotation.eulerAngles.x + Hip_RT_X_increase).IsWithin(-10,10)){
						// 	Hip_RT.Rotate(Hip_RT_X_increase,0,0);
						// }

						// Hip_RT_Y_increase = findIncrease(Hip_RT_X);
						// if ((Hip_RT.rotation.eulerAngles.y + Hip_RT_Y_increase).IsWithin(-2,2)){
						// 	Hip_RT.Rotate(0,Hip_RT_Y_increase,0);
						// }
						// // print((float)data[i][Hip_RT_Z]+" "+(float)data[i-1][Hip_RT_Z]);
						// print(Hip_RT.rotation.eulerAngles.x+" "+Hip_RT.rotation.eulerAngles.y+" "+Hip_RT.rotation.eulerAngles.z);
						
						// Hip_RT_Z_increase = findIncrease(Hip_RT_X);
						// // (177,182)
						// if((Hip_RT.rotation.eulerAngles.z + Hip_RT_Z_increase).IsWithin(90,264)){
						// 	Hip_RT.Rotate(0,0,Hip_RT_Z_increase);
						// }
						// // transform.GetChild(1).GetChild(1).eulerAngles = transform.GetChild(1).GetChild(1).eulerAngles + new Vector3(5,0,0);



						Hip_LT_X_increase = findIncrease(Hip_LT_X);
						if((Hip_LT.rotation.eulerAngles.x + Hip_LT_X_increase).IsWithin(0,90) || (Hip_LT.rotation.eulerAngles.x + Hip_LT_X_increase).IsWithin(360,450)){
							Hip_LT.Rotate(Hip_LT_X_increase,0,0);
						}
						print(Hip_LT.rotation.eulerAngles.x+" "+Hip_LT_X_increase);
						//  print(Hip_LT.gameObject.GetComponent<Transform>().rotation.eulerAngles.x);
						// Hip_LT_Y_increase = findIncrease(Hip_LT_Y);
						// if((Hip_LT.rotation.eulerAngles.y + Hip_LT_Y_increase).IsWithin(-23,33)){
						// 	Hip_LT.Rotate(0,Hip_LT_Y_increase,0);
						// }
						// Hip_LT_Z_increase = findIncrease(Hip_LT_Z);
						// if((Hip_LT.rotation.eulerAngles.z + Hip_LT_Z_increase).IsWithin(90,270)){
						// 	Hip_LT.Rotate(0,0,Hip_LT_Z_increase);
						// }						



						// Knee_RT_X_increase = findIncrease(Knee_RT_X);
						// if(Knee_RT.rotation.eulerAngles.x + Knee_RT_X_increase <=180){
						// 	Knee_RT.Rotate(Knee_RT_X_increase,0,0);
						// }
						// Knee_RT_Y_increase = findIncrease(Knee_RT_Y);
						// if(Knee_RT.rotation.eulerAngles.y + Knee_RT_Y_increase <=180){
						// 	Knee_RT.Rotate(0,Knee_RT_Y_increase,0);
						// }						
						// Knee_RT_Z_increase = findIncrease(Knee_RT_Z);
						// if(Knee_RT.rotation.eulerAngles.z + Knee_RT_Z_increase <=180){
						// 	Knee_RT.Rotate(0,0,Knee_RT_Z_increase);
						// }						




						// Knee_LT_X_increase = findIncrease(Knee_LT_X);
						// if(Knee_LT.rotation.eulerAngles.x + Knee_LT_X_increase <=180){
						// 	Knee_LT.Rotate(Knee_LT_X_increase,0,0);
						// }
						// Knee_LT_Y_increase = findIncrease(Knee_LT_Y);
						// if(Knee_LT.rotation.eulerAngles.y + Knee_LT_Y_increase <=180){
						// 	Knee_LT.Rotate(0,Knee_LT_Y_increase,0);
						// }						
						// Knee_LT_Z_increase = findIncrease(Knee_LT_Z);
						// if(Knee_LT.rotation.eulerAngles.z + Knee_LT_Z_increase <=180){
						// 	Knee_LT.Rotate(0,0,Knee_LT_Z_increase);
						// }						
					
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
