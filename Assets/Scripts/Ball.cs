using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float speed = 30.0f;

    
    [SerializeField] private int leftGoals = 0;
    [SerializeField] private int rightGoals = 0;

    [SerializeField] private string leftCount;
    [SerializeField] private string rightCount;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        leftCount = leftGoals.ToString();

        rightCount = rightGoals.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D colision){

        if(colision.gameObject.name == "LeftBracket"){

            int x = 1;

            int y = yDirection(transform.position, colision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

        if(colision.gameObject.name == "RightBracket"){

            int x = -1;

            int y = yDirection(transform.position, colision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }

    }

    private int yDirection(Vector2 ballPos, Vector2 bracketPos){

        if(ballPos.y > bracketPos.y){

            return 1;
        
        }else if(ballPos.y < bracketPos.y){
        
            return -1;
        
        }else{
        
            return 0;
        
        }
    }

    private void resetBallPos(string direction){
        
        transform.position = Vector2.zero;
    }    
}
