using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField] private float speed = 30.0f;

    
    [SerializeField] private int leftGoals = 0;
    [SerializeField] private int rightGoals = 0;

    [SerializeField] private Text leftCount;
    [SerializeField] private Text rightCount;

    [SerializeField] private Text score;

    AudioSource audioSource;
    
    [SerializeField] private Text timer;

    private float time = 180;
    [SerializeField] private AudioClip audioGoal, audioBracket, audioBounce;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        leftCount.text= leftGoals.ToString();

        rightCount.text = rightGoals.ToString();

        audioSource = GetComponent<AudioSource>();

        score.enabled = false;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed +2 * Time.deltaTime;

         if(time>=0){

            time -= Time.deltaTime;

            timer.text = formatTime(time);
        } else {

            timer.text = "00:00";

            if(leftGoals > rightGoals){
                
                score.text = "O xogador esquerdo GAÑOU!\nPulsa I para volver ó Inicio\nPulsa P para volver a xogar";

            } else if(rightGoals > leftGoals){

                score.text = "O xogador dereito GAÑOU!\nPulsa I para volver ó Inicio\nPulsa P para volver a xogar";

            } else {

                score.text = "EMPATE!\nPulsa I para volver ó Inicio\nPulsa P para volver a xogar";
            }

            score.enabled = true;

            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D colision){

        if(colision.gameObject.name == "LeftBracket"){

            int x = 1;

            int y = yDirection(transform.position, colision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * speed;

            audioSource.clip = audioBracket;

            audioSource.Play();
        }

        if(colision.gameObject.name == "RightBracket"){

            int x = -1;

            int y = yDirection(transform.position, colision.transform.position);

            Vector2 direction = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direction * speed;

            audioSource.clip = audioBracket;

            audioSource.Play();
        }

        if(colision.gameObject.name == "Top" || colision.gameObject.name == "Bot"){

            audioSource.clip = audioBounce;

            audioSource.Play();
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

    public void resetBallPos(string direction){

        transform.position = Vector2.zero;

        speed = 30;

        /*if(direction == "Left"){

            leftGoals++;

            leftCount.text = leftGoals.ToString();

            GetComponent<Rigidbody2D>().velocity = Vector2.left *speed;

        }else if(direction == "Right"){

            rightGoals++;

            rightCount.text = leftGoals.ToString();

            GetComponent<Rigidbody2D>().velocity = Vector2.right *speed;

        }*/

        if(!CheckWinner()){

            leftGoals++;

            leftCount.text = leftGoals.ToString();

            GetComponent<Rigidbody2D>().velocity = Vector2.left *speed;

        }

        audioSource.clip = audioGoal;

        audioSource.Play();
    }    

    private bool CheckWinner(){
        if(leftGoals == 5){

            score.text = "O xogador esquerdo GAÑOU!\nPulsa I para volver ó Inicio\nPulsa P para volver a xogar";

            score.enabled = true;

            Time.timeScale = 0;

            return true;

        } else if(rightGoals == 5){

            score.text = "O xogador dereito GAÑOU!\nPulsa I para volver ó Inicio\nPulsa P para volver a xogar";

            score.enabled = true;

            Time.timeScale = 0;

            return true;

        } else {
            return false;
        }
    }

    private string formatTime(float time){
        
        string minutes = Mathf.Floor(time / 60).ToString("00");

        string seconds = Mathf.Floor(time % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
