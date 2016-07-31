using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class CheckpointC : MonoBehaviour {
    float setTime = 0.0f;
    double lapTime = 0;
    double bestTime = 0;
    public Text writeScore;

    // Use this for initialization
    void Start () {
        setTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        setTime += Time.deltaTime;
        lapTime = Mathf.Round(setTime);
        writeScore.text = "Time: " + lapTime + "\n Best Time: " + bestTime;
    }

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
