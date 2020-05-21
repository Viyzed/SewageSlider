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

    void Start() {

        //Load Highscore
        DataManagement.dataManagement.LoadData();

    }

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
        
        UnityEngine.Debug.Log("Highscore: " + DataManagement.dataManagement.highScore);
        DataManagement.dataManagement.highScore = score;
        DataManagement.dataManagement.SaveData();
        UnityEngine.Debug.Log("New Highscore: " + DataManagement.dataManagement.highScore);
        
    }

}
