using System.Net.Mime;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float ForwardSpeed;
    public Touch touch;
    public float speedModifier;
    public GameObject startingText;
    public Animator player_animation;
    public Obstacle Control;
    private float startTime;
    public bool finnished = false;
    public bool GoForward;
    public Camera Camera;
    public GameObject Player;
    public GameObject FinishLine;
    public TextMeshProUGUI TimerTextPro;
    

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;
    
    void Start()
    {
        
        speedModifier = 0.01f;
        ForwardSpeed = 3;
        player_animation= gameObject.GetComponent<Animator>();
        Control = GetComponent<Obstacle>();
        GoForward= false;
        FinishLine.SetActive(false);
        Camera.transform.DOMoveY(Player.transform.position.y+1.75f,2);
        Camera.transform.DOMoveZ(Player.transform.position.z-2.5f,2);
        
        
    }

    void Update()
    {   
            if (finnished)
            return;  
            float t = Time.time - startTime;
            string minutes = ((int) t /60) . ToString();
            string seconds = (t % 60).ToString("f2");
            TimerTextPro.text = minutes + ":" + seconds;

            if(GoForward)
            {
                transform.Translate(0,0,ForwardSpeed*Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {   
                _lastFrameFingerPositionX = Input.mousePosition.x;
                GoForward = true;
                Destroy(startingText);
                player_animation.SetBool("Go",true);
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }
           
        if (Input.touchCount>0)
        {   
            
            touch = Input.GetTouch(0);
            GoForward = true;
            Destroy(startingText);
            player_animation.SetBool("Go",true);

            if (touch.phase == TouchPhase.Moved && GoForward== true)
            {
                
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x,-4f,4f) + touch.deltaPosition.x * speedModifier/7,
                    transform.position.y,
                    transform.position.z
                );
            }
        }
    }

    void OnTriggerEnter(Collider other) 
        {
        
            if(other.gameObject.tag=="EndLine")
            {
                player_animation.SetBool("Go",false);
                player_animation.SetBool("Painting",true);
            }

            if(other.gameObject.tag=="WallVisibility")

            {
                FinishLine.SetActive(true);
                Camera.transform.DOMoveY(Player.transform.position.y+1.147f,2f);
                Camera.transform.DOMoveZ(Player.transform.position.z+0.5f,2f);
            }
        

        }

        public void Finnish()
        {   
            TimerTextPro.color = Color.yellow;
            Invoke("GameFinish",3f);
            finnished = true;
            GoForward = false;

        }

            public void GameFinish()

            {
                Destroy(TimerTextPro);        
            }
}