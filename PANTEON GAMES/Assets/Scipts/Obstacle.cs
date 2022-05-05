using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{   
    public Rigidbody rb;
    [SerializeField] int BackAddForce;

    public PlayerController Control;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Control = GetComponent<PlayerController>();
        
    }

    void Update()
    {

    }

         void OnTriggerEnter(Collider collision )
        {
            if(collision.gameObject.tag=="Obstacle")
            {

               gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back*BackAddForce,ForceMode.Impulse);
               Control.player_animation.SetBool("Fall",true);
               Control.GoForward = false;
               Control.speedModifier = 0;
               Control.ForwardSpeed = 0;

                if (Control.touch.phase == TouchPhase.Moved) //Debug.Log("Basılı");
                {
 
                    Invoke("Restart2",2.5f);

                }
                
                if (Control.touch.phase != TouchPhase.Moved) //Debug.Log("Basılı Değil");
                {

                    Invoke("Restart",1.9f);
                    
                    
                }
            }
        }

             public void Restart()

            {   
                Control.player_animation.SetBool("Fall",false);
                Control.player_animation.SetBool("Go",false);
                Control.speedModifier = 0.01f;
                Control.ForwardSpeed = 4;
                transform.position = new Vector3(0f, 0f, -36f);
            }
            public void Restart2()

            {   
                Control.player_animation.SetBool("Fall",false);
                Control.player_animation.SetBool("Go",true);
                Control.speedModifier = 0.01f;
                Control.ForwardSpeed = 3;
                transform.position = new Vector3(0f, 0f, -36f);
            }
            
}
                    
                            
                    