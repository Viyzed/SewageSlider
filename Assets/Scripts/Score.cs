using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float timeLeft = 180;
    public int score = 0;
    public GameObject timeLeftUi;
    public GameObject scoreUi;
    public bool finished = false;

    // Update is called once per frame
    void Update() {

        timeLeft -= Time.deltaTime;
        timeLeftUi.gameObject.GetComponent<Text>().text = "Time: " + (int)timeLeft;
        scoreUi.gameObject.GetComponent<Text>().text = "Score: " + score;
        if(timeLeft < 0.1) {
            SceneManager.LoadScene("Demo #1");
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig) {
        if(trig.gameObject.tag == "Finish") {
            TallyScore();
            finished = true;
        }
        
        if(trig.gameObject.tag == "Coin") {
            score += 100;
            Destroy(trig.gameObject);
        }

    }

    void TallyScore() {
        if (!finished) {
            score += (int)timeLeft * 10;
        }
        else {
            UnityEngine.Debug.Log("Highscore: " + DataManagement.dataManagement.highScore);
            DataManagement.dataManagement.highScore = score;
            DataManagement.dataManagement.SaveData();
            UnityEngine.Debug.Log("New Highscore: " + DataManagement.dataManagement.highScore);
        }
    }

}
