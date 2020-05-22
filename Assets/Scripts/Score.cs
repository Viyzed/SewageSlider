using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float timeLeft = 180;
    public int score = 0;
    private int highScore;
    public GameObject timeLeftUi;
    public GameObject scoreUi;
    public GameObject highScoreUi;
    public bool finished = false;

    void Start() {

        //Load Highscore
        DataManagement.dataManagement.LoadData();
        highScore = DataManagement.dataManagement.highScore;

    }

    // Update is called once per frame
    void Update() {

        timeLeft -= Time.deltaTime;
        timeLeftUi.gameObject.GetComponent<Text>().text = "Time: " + (int)timeLeft;
        scoreUi.gameObject.GetComponent<Text>().text = "Score: " + score;
        highScoreUi.gameObject.GetComponent<Text>().text = "High: " + highScore;
        if (timeLeft < 0.1) {
            SceneManager.LoadScene("Demo #1");
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig) {

        if(trig.gameObject.tag == "Finish") {
            if (!finished) {
                finished = true;
                score += (int)timeLeft * 10;
                StoreScore();
            }
        }
        
        if(trig.gameObject.tag == "Coin_Gold") {
            score += 100;
            Destroy(trig.gameObject);
        }
        else if(trig.gameObject.tag == "Coin_Silver") {
            score += 50;
            Destroy(trig.gameObject);
        }


    }

    void StoreScore() {
        
        DataManagement.dataManagement.highScore = score;
        DataManagement.dataManagement.SaveData();
        
    }

}
