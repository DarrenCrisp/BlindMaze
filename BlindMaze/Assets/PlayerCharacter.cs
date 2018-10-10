using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour {
    public float gameTime = 90f;
    public float speed = 5f;
    public float bounceTime = 0.25f;
    public float currentSpeed;
    private bool bouncing = false;
    private bool timeupPlayed=false;
    private float timer = 0f;
    private float gameTimeRemaining=0;
    private AudioSource hitWall;
    public AudioClip timeUp;
    public AudioClip[] oooohf;
    private AudioClip temp;

    public Image timeGuage;
    //public AudioSource [] doop;

    private CharacterController PC;


    void Start() {
        PC = GetComponent<CharacterController>();
        hitWall = GetComponent<AudioSource>();
        currentSpeed = speed;
    }


    void Update() {
        if (!bouncing)
        {
            PC.Move(transform.TransformDirection(Vector3.forward) * currentSpeed * Time.deltaTime);
        }
        if (bouncing)
        {
            timer += Time.deltaTime;
            PC.Move(transform.TransformDirection(Vector3.back) * currentSpeed * Time.deltaTime);
            if (timer >= bounceTime)
            {
                bouncing = false;
                timer = 0f;
            }
        }
        gameTimeRemaining += Time.deltaTime;
      //  print(gameTimeRemaining);
        if (gameTimeRemaining >= gameTime / 3)
        {
            currentSpeed = speed * (1 + (gameTimeRemaining / gameTime));
        }
        if(gameTimeRemaining <= gameTime)
        {
          //  timeGuage.transform.localScale = //(gameTimeRemaining / gameTime, 0, 0);
        }
       
        if(gameTimeRemaining >= gameTime)
        {
            print("Game Over");
            if (timeupPlayed == false)
            {
                hitWall.clip = timeUp;
                hitWall.loop = true;
                hitWall.Play();
                timeupPlayed = true;
            }
        }
    }

    public void RotateRight () {
        PC.gameObject.transform.Rotate(0,90,0);
        }
    public void RotateLEFT()
    {
        PC.gameObject.transform.Rotate(0, -90, 0);
    }

    public void Bounceback()
    {
        bouncing = true;
        int num = Random.Range(0, oooohf.Length);
        temp = oooohf[num];
        hitWall.clip = temp;
        hitWall.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Bounceback();
    }
    

 
}
