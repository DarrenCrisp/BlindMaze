using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCharacter : MonoBehaviour {
    public float gameTime = 90f;
    public float speed = 5f;
    public float bounceTime = 0.25f;
    public float currentSpeed;
    private bool bouncing = false;
    private bool perfect = true;
    private bool timeupPlayed=false;
    private float timer = 0f;
    private float gameTimeRemaining=0;
    private float startScore = 100000;
    private bool isFinished = false;
    private AudioSource hitWall;
    public AudioClip timeUp;
    public AudioClip[] oooohf;
    private AudioClip temp;
    public AudioSource bGM;
    public AudioClip victory;
    public AudioClip loss;
    public Image timeGuage;
    public Text score;
    public GameObject resetButtons;
    //public AudioSource [] doop;

    private CharacterController PC;


    void Start() {
        PC = GetComponent<CharacterController>();
        hitWall = GetComponent<AudioSource>();
        currentSpeed = speed;
    }
    public void FinalScore()//works out final score and ends game
    {
        resetButtons.SetActive(true);
        bGM.clip = victory;
        bGM.Play();
        isFinished = true;
        if (perfect)
        {
            startScore += 20000;
        }
    }

    void Update() {
        if (!isFinished)//stops score depreciating after finishing
        {
            startScore -= 1000 * Time.deltaTime;
            gameTimeRemaining += Time.deltaTime;
        }

        score.text = (startScore).ToString();
        if (!bouncing)
        {
            if (!isFinished)
            {
                PC.Move(transform.TransformDirection(Vector3.forward) * currentSpeed * Time.deltaTime);
            }
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
      //  print(gameTimeRemaining);
        if (gameTimeRemaining >= gameTime / 3)
        {
            currentSpeed = speed * (1 + (gameTimeRemaining / gameTime));
        }
        if(gameTimeRemaining <= gameTime)
        {
            timeGuage.transform.localScale = new Vector3(gameTimeRemaining / gameTime, 1, 1);
        }
       
        if(gameTimeRemaining >= gameTime)
        {
            print("Game Over");
            if (timeupPlayed == false)
            {
                resetButtons.SetActive(true);
                isFinished = true;
                bGM.clip = loss;
                bGM.Play();
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

    public void ResetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Bounceback()
    {
        bouncing = true;
        perfect = false;
        startScore -= 13231;
        int num = Random.Range(0, oooohf.Length);
        temp = oooohf[num];
        hitWall.clip = temp;
        hitWall.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Bounceback();
    }
    
    public float RemainingGT()
    {
        return gameTimeRemaining;
    }
 
}
