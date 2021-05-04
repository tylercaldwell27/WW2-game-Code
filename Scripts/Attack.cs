using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool inRange;
    float speed = 30;
    float rounds = 1;
    Vector3 direction;
    Vector3 Destantion;
    GameObject target;

    [SerializeField]
    Transform bullet;
    Transform newTarget;
     Rigidbody rb;

    public Transform gun;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

 



        if (inRange == true)
        {
            
                Shoot();
            
        }

        
    }
    //checking if the player is in attack range
    void OnTriggerStay(Collider other)
    {
        if (gun.tag == ("Allies"))
        {
            if (other.gameObject.tag == "Enemy")
            {
                //Debug.Log("attacking");
                inRange = true;

                target = other.gameObject;
                Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(targetPos);
                if (target == null)
                {
                    Debug.Log("not target here");
                }

            }
            else if (other.gameObject.tag == "dead")
            {
                inRange = false;
                rounds = 0;
            }
        }
        else if(gun.tag == ("Axis"))
        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("attacking");
                inRange = true;

                target = other.gameObject;
                Vector3 targetPos = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                transform.LookAt(targetPos);
                if (target == null)
                {
                    Debug.Log("not target here");
                }

            }
            else if (other.gameObject.tag == "dead")
            {
                inRange = false;
                rounds = 0;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log("attacking");
            inRange = false;
            

        }

    }


    void Shoot()
    {
        
        
        if (rounds == 1)
        {
            if (target == null)
            {
                newTarget = null;
            }
            else
            {
                newTarget = target.transform;
                Transform bulletTransform = Instantiate(bullet, gun.position, Quaternion.identity);
                Vector3 shootDir = (newTarget.position - gun.position).normalized;
                bulletTransform.GetComponent<bullet>().Setup(shootDir);
                Debug.Log(gun.tag);

                rounds += 200;
            }
              
        }
        else
        {
            rounds -= 1;
           
        }
    }
}
