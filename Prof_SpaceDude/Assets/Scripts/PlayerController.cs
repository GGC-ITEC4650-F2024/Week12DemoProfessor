using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.acceleration);
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        float h = Input.acceleration.x;
        //QUIZ: fill this in so atro moves up down when you tilt phone.
        float v = 0;
        myBod.velocity = 5 * (new Vector2(h, v));

        Touch[] fingers = Input.touches;
        print(fingers.Length);

        if(fingers.Length > 0) {
            Touch t = fingers[0];
            if(t.phase == TouchPhase.Began) {
                print("Touchdown:" + t.position);
            }
            else if(t.phase == TouchPhase.Moved) {
                print("Dragging" + t.position);
            }
            else if (t.phase == TouchPhase.Ended) {
                print("Lift Off" + t.position); 
            }
        }





    }
}
