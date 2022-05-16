using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentController : MonoBehaviour
{

    public GameObject Target;
    public GameObject Destroyop;
    NavMeshAgent Agent;
    private Animator OpponentAnimator;


    void Start()
    {
        Agent = this.GetComponent<NavMeshAgent>();
        OpponentAnimator= gameObject.GetComponent<Animator>();
        
    }


    void Update()
    {
            if (Input.touchCount>0||Input.GetMouseButtonDown(0))
            {   

                OpponentAnimator.SetBool("Go2",true);
                Agent.SetDestination(Target.transform.position);
            
            }
            
    }

    void OnTriggerEnter(Collider other )
        {
            if(other.gameObject.tag=="Obstacle")
            {  
                Invoke("boolcontrol",1f);
                Agent.speed=0f;
                Agent.SetDestination(transform.position);
                OpponentAnimator.SetBool("Fall2",true);               
            }
            if(other.gameObject.tag=="OpponentDestroy")
            {  
                Destroy(Destroyop);
            }
        }
    
    void boolcontrol()
    {
        OpponentAnimator.SetBool("Fall2",false);
        OpponentAnimator.SetBool("Go2",true);
        Agent.speed=3.5f;

        Agent.SetDestination(Target.transform.position);
        transform.position = new Vector3(Random.Range(-3.75f,3.75f),0.1f,-35.0f);
    }
 
}

