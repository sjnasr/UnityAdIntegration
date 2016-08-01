using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class CheckpointC : MonoBehaviour {
	//initialized all the variables to 0.
    float setTime = 0.0f;
    double lapTime = 0;
    double bestTime = 0;
    public Text writeScore;

    // Use this for initialization start time
    void Start () {
        setTime = 0.0f;
    }
	
	// When the player reach the checkpoint for the first time, it will be update the best time
	void Update () {
        setTime += Time.deltaTime;
        lapTime = Mathf.Round(setTime); //rounds the seconds to a whole number otherwise it will show milleseconds
        writeScore.text = "Time: " + lapTime + "\n Best Time: " + bestTime;
    }

	//Everytime the user hit the checkpoint, laptime will be check to see if it is over 5 seconds, and if the laptime is 
	//less than best time then it will update best time then ShowAd() is triggered whenever the user reach the checkpoint
    void OnTriggerEnter(Collider other ){
        if (lapTime > 5){
            Debug.Log("" + lapTime);

            if (lapTime < bestTime || bestTime == 0){
                bestTime = lapTime;
				ShowAd ();
            }
        }
        setTime = 0.0f;
    }

    public void ShowAd(){
        if (Advertisement.IsReady()){
            Advertisement.Show();
        }
    }

}
