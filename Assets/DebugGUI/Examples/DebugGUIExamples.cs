using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugGUIExamples : MonoBehaviour
{
    /* * * *
     * 
     *   [DebugGUIGraph]
     *   Renders the variable in a graph on-screen. Attribute based graphs will updates every Update.
     *    Lets you optionally define:
     *        max, min  - The range of displayed values
     *        r, g, b   - The RGB color of the graph (0~1)
     *        group     - The order of the graph on screen. Graphs may be overlapped!
     *        autoScale - If true the graph will readjust min/max to fit the data
     *   
     *   [DebugGUIPrint]
     *    Draws the current variable continuously on-screen as 
     *    $"{GameObject name} {variable name}: {value}"
     *   
     *   For more control, these features can be accessed manually.
     *    DebugGUI.SetGraphProperties(key, ...) - Set the properties of the graph with the provided key
     *    DebugGUI.Graph(key, value)            - Push a value to the graph
     *    DebugGUI.LogPersistent(key, value)    - Print a persistent log entry on screen
     *    DebugGUI.Log(value)                   - Print a temporary log entry on screen
     *    
     *   See DebugGUI.cs for more info
     * 
     * * * */

    int menuIndex = 0;
    List<Dictionary<string,object>> data;
    List<Dictionary<string,object>> data2;

    public void Run(){

        if (Config.ran ==false){

            
            //get the selected index
            menuIndex = Config.selected_index;
        //  //get all options available within this dropdown menu
        //      List<UnityEngine.UI.Dropdown.OptionData> menuOptions = dropdownMenu.options;
        //  //get the string value of the selected index
        //      string value = menuOptions [menuIndex].text;

            // Set up graph properties using our graph keys
            if (menuIndex == 0){
                DebugGUI.SetGraphProperties("MomentumX", "MomentumX", 0, 200, 0, new Color(1, 1, 1), true);

                DebugGUI.SetGraphProperties("MomentumY", "MomentumY", 0, 200, 1, new Color(0, 1, 0), true);

                DebugGUI.SetGraphProperties("MomentumZ", "MomentumZ", 0, 200, 2, new Color(0, 1, 1), true);

                DebugGUI.SetGraphProperties("Momentum", "Momentum", -1, 1, 3, new Color(1, 1, 0), true);
            }
            
            // DebugGUI.SetGraphProperties("frameRate", "FPS", 0, 200, 2, new Color(1, 0.5f, 1), false);
            
            else if (menuIndex == 1){
                DebugGUI.SetGraphProperties("Knee RT X", "Knee RT X", -1, 1, 0, new Color(1, 0, 1), true);
                DebugGUI.SetGraphProperties("Knee LT X", "Knee LT X", -1, 1, 0, new Color(1, 1, 1), true);

                DebugGUI.SetGraphProperties("Knee RT Y", "Knee RT Y", -1, 1, 1, new Color(0, 1, 1), true);
                DebugGUI.SetGraphProperties("Knee LT Y", "Knee LT Y", -1, 1, 1, new Color(0, 1, 0), true);

                DebugGUI.SetGraphProperties("Knee RT Z", "Knee RT Z", -1, 1, 2, new Color(1, 0, 0), true);
                DebugGUI.SetGraphProperties("Knee LT Z", "Knee LT Z", -1, 1, 2, new Color(0, 1, 1), true);

                DebugGUI.SetGraphProperties("Hip RT X", "Hip RT X", -1, 1, 3, new Color(1, 0, 1), true);
                DebugGUI.SetGraphProperties("Hip LT X", "Hip LT X", -1, 1, 3, new Color(1, 1, 1), true);

                DebugGUI.SetGraphProperties("Hip RT Y", "Hip RT Y", -1, 1, 4, new Color(0, 1, 1), true);
                DebugGUI.SetGraphProperties("Hip LT Y", "Hip LT Y", -1, 1, 4, new Color(0, 1, 0), true);

                DebugGUI.SetGraphProperties("Hip RT Z", "Hip RT Z", -1, 1, 5, new Color(1, 0, 0), true);
                DebugGUI.SetGraphProperties("Hip LT Z", "Hip LT Z", -1, 1, 5, new Color(0, 1, 1), true);
            }

            Config.enable = true;
            Config.ran = true;
        }
        StartCoroutine(MyCoroutine());
    }
    public void Pause(){
        Config.enable = false;
        StartCoroutine(MyCoroutine());
    }
    public void Play(){
        Config.enable = true;
        StartCoroutine(MyCoroutine());
    }
    IEnumerator MyCoroutine(){
        yield return null;
    }

    

    // Disable Field Unused warning
#pragma warning disable 0414

    // Works with regular fields
    // [DebugGUIGraph(min: -1, max: 1, r: 0, g: 1, b: 0, autoScale: true)]
    // float MomentumX;

    // As well as properties
    // [DebugGUIGraph(min: -1, max: 1, r: 0, g: 1, b: 1, autoScale: true)]
    // float CosProperty { get { return Mathf.Cos(Time.time * 6); } }

#if NET_4_6
    // Also works for expression-bodied properties in .Net 4.6+
    // [DebugGUIGraph(min: -1, max: 1, r: 1, g: 0.3f, b: 1)]
    // float SinProperty => Mathf.Sin((Time.time + Mathf.PI / 2) * 6);
#else
    // [DebugGUIGraph(min: -1, max: 1, r: 1, g: 0.5f, b: 1)]
    // float SinProperty { get { return Mathf.Sin((Time.time + Mathf.PI / 2) * 6); } }
#endif

    // User inputs, print and graph in one!
    // [DebugGUIGraph(group: 1, r: 1, g: 0.3f, b: 0.3f)]
    // float MomentumY;
    // [DebugGUIPrint, DebugGUIGraph(group: 1, r: 0, g: 1, b: 0)]
    // float mouseY;

    void Awake()
    {
        // Log (as opposed to LogPersistent) will disappear automatically after some time.
        // DebugGUI.Log("Hello! I will disappear in five seconds!");

          //find your dropdown object
        print("Graph Created");
      


        data = CSV_Reader.Read ("chathu_trial_Session10_Shimmer_5F42_Calibrated_PC");
        data2 = CSV_Reader.Read (Config.joint_angles_file_name);

        // for(var i=0; i < data.Count; i++) {
        //     print ("X_acc " + data[i]["Shimmer_5F42_Accel_WR_X_CAL"] + " " +
        //            "Y_acc " + data[i]["Shimmer_5F42_Accel_WR_X_CAL"] + " " +
        //            "Z_acc " + data[i]["Shimmer_5F42_Accel_WR_X_CAL"]);

		// }
    }
    
    int n = 0 ;
    int i = 0 ;
    int i2 = 0;
    int mass = 80;

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

    void Update()
    {
        if(Config.enable == true){
                // Update the fields our attributes are graphing
            // SinField = Mathf.Sin(Time.time * 6);
            float frequency = 1 / Time.deltaTime;
            float accelerationX = (float) data[i]["Shimmer_5F42_Accel_WR_X_CAL"];
            float accelerationY = (float) data[i]["Shimmer_5F42_Accel_WR_Y_CAL"];
            float accelerationZ = (float) data[i]["Shimmer_5F42_Accel_WR_Z_CAL"];
            float acceleration = Mathf.Sqrt(Mathf.Pow(accelerationX, 2.0f)+Mathf.Pow(accelerationY, 2.0f)+Mathf.Pow(accelerationZ, 2.0f));
            if (n%Config.playback_speed==0){
                // MomentumY = Random.Range(0.0f, 300.0f);

                if(menuIndex == 0){
                    DebugGUI.Graph("MomentumX",mass*accelerationX*frequency);

                    DebugGUI.Graph("MomentumY",mass*accelerationY*frequency);

                    DebugGUI.Graph("MomentumZ",mass*accelerationZ*frequency);

                    DebugGUI.Graph("Momentum", mass*acceleration*frequency);

                    if(i<data.Count){
                        i++;
                    }
                }
                else if(menuIndex == 1){
                    DebugGUI.Graph("Hip RT X", (float)data2[i2][Hip_RT_X]);
                    DebugGUI.Graph("Hip RT Y", (float)data2[i2][Hip_RT_Y]);
                    DebugGUI.Graph("Hip RT Z", (float)data2[i2][Hip_RT_Z]);

                    DebugGUI.Graph("Hip LT X", (float)data2[i2][Hip_LT_X]);
                    DebugGUI.Graph("Hip LT Y", (float)data2[i2][Hip_LT_Y]);
                    DebugGUI.Graph("Hip LT Z", (float)data2[i2][Hip_LT_Z]);

                    DebugGUI.Graph("Knee RT X", (float)data2[i2][Knee_RT_X]);
                    DebugGUI.Graph("Knee RT Y", (float)data2[i2][Knee_RT_Y]);
                    DebugGUI.Graph("Knee RT Z", (float)data2[i2][Knee_RT_Z]);

                    DebugGUI.Graph("Knee LT X", (float)data2[i2][Knee_LT_X]);
                    DebugGUI.Graph("Knee LT Y", (float)data2[i2][Knee_LT_Y]);
                    DebugGUI.Graph("Knee LT Z", (float)data2[i2][Knee_LT_Z]);

                    if(i2<data2.Count){
                        i2++;
                    }
                }
            }

            // mouseX = Input.mousePosition.x / Screen.width;
            // mouseY = Input.mousePosition.y / Screen.height;

            // // Manual logging
            // if (Input.GetMouseButtonDown(0))
            // {
            //     DebugGUI.Log(string.Format(
            //         "Mouse clicked! ({0}, {1})",
            //         mouseX.ToString("F3")
            //         // mouseY.ToString("F3")
            //     ));
            // }

            // Manual persistent logging
            // DebugGUI.LogPersistent("smoothFrameRate", "SmoothFPS: " + (1 / Time.deltaTime).ToString("F3"));
            // // DebugGUI.LogPersistent("frameRate", "FPS: " + (1 / Time.smoothDeltaTime).ToString("F3"));

            // if (Time.smoothDeltaTime != 0)
            //     DebugGUI.Graph("smoothFrameRate", 1 / Time.smoothDeltaTime);
            // if (Time.deltaTime != 0)
            //     DebugGUI.Graph("frameRate", 1 / Time.deltaTime);
            n++;

        }
        
    }


    void OnDestroy()
    {
        // Clean up our logs and graphs when this object is destroyed
        DebugGUI.RemoveGraph("frameRate");
        DebugGUI.RemoveGraph("Momentum");

        DebugGUI.RemovePersistent("frameRate");
    }
}
