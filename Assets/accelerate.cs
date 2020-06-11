using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour {

	// Use this for initialization
	     List<Dictionary<string,object>> data;

	void Start () {
		
			// foreach (Transform child in transform)
            //  print("Foreach loop: " + child);
			data = CSV_Reader.Read ("Joint angles");
        // for(var i=0; i < data.Count; i++) {
        //     print ("X_angle " + data[i]["Left_Hip_FlexExt"] + " " +
        //            "Y_angle " + data[i]["Left_Hip_AbdAdd"] + " " +
        //            "Z_angle " + data[i]["Left_Hip_IntExt"]);

		// }
	// 	 foreach (string key in data[0].Keys)
    // {
    //     print(key);
    // }
			
	}
	
	int n = 0;
	int i = 0;
    // int[] array1 = new int[] { 1,1,1,1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 1,1,1,1,1,1,1};
	
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
	string Knee_LT_Z = "Left_KneeIntExt";

	// Update is called once per frame
	void Update () {
		
		// print(Time.deltaTime);
		// if(n%30==0 && n<300 && n>0 && gameObject.name=="joint_HipLT"){
        //     transform.Rotate(3,0, zAngle: 0);
		// }else if(n==300){
		// 	n = -1*n;
        // }else if(n%30==0 && n<0 && n>-300 && gameObject.name=="joint_HipLT"){
		// 	transform.Rotate(-1*3,0, zAngle: 0);
		// }else{
		// 	n++;
		// }
		// print(n);

		if (n%25==0){

			if(i==0){
				if (gameObject.name=="joint_HipRT"){
			// if (i%30==0 && i%10==0 && gameObject.name=="joint_HipRT"){
				transform.Rotate((float)data[i][Hip_RT_X]*1,0, zAngle: 0);
				transform.Rotate(0,(float)data[i][Hip_RT_Y]*1, zAngle: 0);
				transform.Rotate(0,0,(float)data[i][Hip_RT_Z]*1);

				// n++;
				// }else if(n<28 && n>=13 && i%10==0 && gameObject.name=="joint_HipLT"){
				}else if(gameObject.name=="joint_HipLT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Hip_LT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Hip_LT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Hip_LT_Z]*1);

				}else if(gameObject.name=="joint_KneeRT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Knee_RT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Knee_RT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Knee_RT_Z]*1);
		
				}else if(gameObject.name=="joint_KneeLT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Knee_LT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Knee_LT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Knee_LT_Z]*1);
				}
			}else{
				if (gameObject.name=="joint_HipRT"){
			// if (i%30==0 && i%10==0 && gameObject.name=="joint_HipRT"){
				transform.Rotate((float)data[i][Hip_RT_X]-(float)data[i-1][Hip_RT_X]*1,0, zAngle: 0);
				transform.Rotate(0,(float)data[i][Hip_RT_Y]-(float)data[i-1][Hip_RT_Y]*1, zAngle: 0);
				transform.Rotate(0,0,(float)data[i][Hip_RT_Z]-(float)data[i-1][Hip_RT_Z]*1);

				// n++;
				// }else if(n<28 && n>=13 && i%10==0 && gameObject.name=="joint_HipLT"){
				}else if(gameObject.name=="joint_HipLT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Hip_LT_X]-(float)data[i-1][Hip_LT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Hip_LT_Y]-(float)data[i-1][Hip_LT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Hip_LT_Z]-(float)data[i-1][Hip_LT_Z]*1);

				}else if(gameObject.name=="joint_KneeRT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Knee_RT_X]-(float)data[i-1][Knee_RT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Knee_RT_Y]-(float)data[i-1][Knee_RT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Knee_RT_Z]-(float)data[i-1][Knee_RT_Z]*1);
		
				}else if(gameObject.name=="joint_KneeLT"){
					
					// transform.Rotate(array1[n]*3,0, zAngle: 0);
					transform.Rotate((float)data[i][Knee_LT_X]-(float)data[i-1][Knee_LT_X]*1,0, zAngle: 0);
					transform.Rotate(0,(float)data[i][Knee_LT_Y]-(float)data[i-1][Knee_LT_Y]*1, zAngle: 0);
					transform.Rotate(0,0,(float)data[i][Knee_LT_Z]-(float)data[i-1][Knee_LT_Z]*1);
				}
			}
			
			
			if(i<data.Count){
					i++;
				}
			}
			// print(n);
			n++;
	}
}
