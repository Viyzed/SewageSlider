using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;

public class GrateBehaviour : MonoBehaviour {

    public GameObject player;
    public Score scoreScript;
    public bool lowered;
    public bool lowering;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("Player");
        scoreScript = player.GetComponent<Score>();
        lowered = false;
        lowering = false;
    }

    // Update is called once per frame
    void FixedUpdate() {

        if(scoreScript.score == 600) {
            LowerGrate();
        }

        if(gameObject.GetComponent<Rigidbody2D>().rotation > 90) {
            lowered = true;
            lowering = false;
        }
        
    }

    void LowerGrate() {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if (!lowered) {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(gameObject.GetComponent<Rigidbody2D>().rotation + 50.0f * Time.fixedDeltaTime);
            lowering = true;
           
        }
        else {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            lowering = false;
        }
    }

}
