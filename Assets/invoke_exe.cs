using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class invoke_exe : MonoBehaviour {

	// Use this for initialization
	List<Dictionary<string,object>> data;
	int num_points;
	List<float> momentumX = new List<float>();
	List<float> momentumY = new List<float>();
	List<float> momentumZ = new List<float>();
	List<float> momentum = new List<float>();

	void Start () {
		data = CSV_Reader.Read ("chathu_trial_Session10_Shimmer_5F42_Calibrated_PC");
		num_points = data.Count;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int mass = 80;
	
	public void SaveGraph(){

		float frequency;
		float accelerationX;
		float accelerationY;
		float accelerationZ;
		float acceleration;
		StreamWriter writer1 = new StreamWriter(@"f:\unity-testing1.csv");
		StreamWriter writer2 = new StreamWriter(@"f:\unity-testing2.csv");
		StreamWriter writer3 = new StreamWriter(@"f:\unity-testing3.csv");
		StreamWriter writer4 = new StreamWriter(@"f:\unity-testing4.csv");

		for(int i=0;i<num_points;i++){
			
			// if(i != (num_points-1)){
			// 	frequency = 1000 / ((float) data[i+1]["Shimmer_5F42_TimestampSync_Unix_CAL"]-(float) data[i]["Shimmer_5F42_TimestampSync_Unix_CAL"]);
			// 	print("hi"+((float) data[i]["Shimmer_5F42_TimestampSync_Unix_CAL"]-(float) data[i-1]["Shimmer_5F42_TimestampSync_Unix_CAL"]).ToString());
			// 	// print("hi"+data[i]["Shimmer_5F42_TimestampSync_Unix_CAL"]);

			// }else{
			// 	frequency = 1000 / ((float) data[i]["Shimmer_5F42_TimestampSync_Unix_CAL"]-(float) data[i-1]["Shimmer_5F42_TimestampSync_Unix_CAL"]);
			// 	print("crip"+((float) data[i]["Shimmer_5F42_TimestampSync_Unix_CAL"]-(float) data[i-1]["Shimmer_5F42_TimestampSync_Unix_CAL"]).ToString());
			// 	// print("crip"+data[i-1]["Shimmer_5F42_TimestampSync_Unix_CAL"]);
			// }
			// print("================================================");
			frequency = 1/0.019f;
			accelerationX = (float) data[i]["Shimmer_5F42_Accel_WR_X_CAL"];
			accelerationY = (float) data[i]["Shimmer_5F42_Accel_WR_Y_CAL"];
			accelerationZ = (float) data[i]["Shimmer_5F42_Accel_WR_Z_CAL"];
			acceleration = Mathf.Sqrt(Mathf.Pow(accelerationX, 2.0f)+Mathf.Pow(accelerationY, 2.0f)+Mathf.Pow(accelerationZ, 2.0f));
		
			// momentumX.Add(mass*accelerationX*frequency);
			// print((mass*accelerationX*frequency).ToString());
			writer1.Write((mass*accelerationX*frequency).ToString()+",");
			writer2.Write((mass*accelerationY*frequency).ToString()+",");
			writer3.Write((mass*accelerationZ*frequency).ToString()+",");
			writer4.Write((mass*acceleration*frequency).ToString()+",");

			// momentumY.Add(mass*accelerationY*frequency);

			// momentumZ.Add(mass*accelerationZ*frequency);

			// momentum.Add(mass*acceleration*frequency);
		}
		string path1 = "f:\\unity-testing1.csv MomentumX";
		Process process1 = new Process();
		process1.StartInfo.FileName = @"C:\Users\T.Aathman\PycharmProjects\SL-Cricket-Graph\dist\main\main.exe";
		process1.StartInfo.Arguments = path1;
		process1.Start();

		string path2 = "f:\\unity-testing2.csv MomentumY";
		Process process2 = new Process();
		process2.StartInfo.FileName = @"C:\Users\T.Aathman\PycharmProjects\SL-Cricket-Graph\dist\main\main.exe";
		process2.StartInfo.Arguments = path2;
		process2.Start();
		
		string path3 = "f:\\unity-testing3.csv MomentumZ";
		Process process3 = new Process();
		process3.StartInfo.FileName = @"C:\Users\T.Aathman\PycharmProjects\SL-Cricket-Graph\dist\main\main.exe";
		process3.StartInfo.Arguments = path3;
		process3.Start();
		
		string path4 = "f:\\unity-testing4.csv TotalMomentum";
		Process process4 = new Process();
		process4.StartInfo.FileName = @"C:\Users\T.Aathman\PycharmProjects\SL-Cricket-Graph\dist\main\main.exe";
		process4.StartInfo.Arguments = path4;
		process4.Start();
		
		// string path3 = @"f:\unity-testing3.csv";
		// Process process3 = new Process();
		// process3.StartInfo.FileName = @"C:\Users\T.Aathman\Anaconda3\python.exe C:/Users/T.Aathman/PycharmProjects/SL-Cricket-Graph/main.py";
		// process3.StartInfo.Arguments = path3+" MomentumZ";
		// process3.Start();
	
	}
}
