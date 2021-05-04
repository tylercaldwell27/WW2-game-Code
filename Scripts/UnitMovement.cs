using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Animator animator;
    Camera myCam;
    NavMeshAgent myAgent;
    public LayerMask ground;

    bool ismoving;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //animator.SetInteger("Speed", Mathf.FloorToInt(myAgent.velocity.x));
        Attack unit = this.gameObject.GetComponent<Attack>();
        if(unit.inRange == true && Mathf.FloorToInt(myAgent.velocity.x) == -1) 
        {
            animator.SetInteger("Speed", 0);
        }
        else if(Mathf.FloorToInt(myAgent.velocity.x) != 0 || Mathf.FloorToInt(myAgent.velocity.z) != 0)
        {
            animator.SetInteger("Speed", 1);
        }
        else
        {
            animator.SetInteger("Speed", 0);
        }

            Debug.Log(myAgent.velocity);
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
                
                animator.SetBool("isMoving", true);
            }
            
           
     
                animator.SetBool("isMoving", false);
            
        }
    }

   

}
