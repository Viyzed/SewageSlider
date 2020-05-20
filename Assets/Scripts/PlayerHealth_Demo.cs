using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth_Demo : MonoBehaviour {

    // Update is called once per frame
    void Update() {

        if(gameObject.transform.position.y < -20) {
            Death();
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig) {

        if (trig.gameObject.tag == "Spike") {
            Death();
        }

    }

    void OnCollisionEnter2D(Collision2D trig) {

        if (trig.gameObject.tag == "Grate" && trig.gameObject.GetComponent<GrateBehaviour>().lowering) {
            Death();
        }

    }

    void Death() {
        Destroy(gameObject);
        SceneManager.LoadScene("Demo #1");
    }

}
