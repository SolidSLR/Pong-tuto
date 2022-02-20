using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ball){

        if(ball.name == "Ball"){
            if(gameObject.name == "Left"){

                ball.GetComponent<Ball>().resetBallPos("Right");

            }else if(gameObject.name == "Right"){

                ball.GetComponent<Ball>().resetBallPos("Left");

            }
        }

    }
}
