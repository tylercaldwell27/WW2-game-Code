using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthsystem : MonoBehaviour
{
    // Start is called before the first frame update
   public float health;
    public bool isDead;
    HealthBar bar;
    bullet damageToTake;
    CapsuleCollider collider;
    Transform child;
    void Start()
    {
        health = 100;
        isDead = false;
        collider = GetComponent<CapsuleCollider>();
        if (this.gameObject.tag == "Player")
        {
           child = this.transform.GetChild(2).GetChild(1);
        }
        else
        {
            child = this.transform.GetChild(1).GetChild(1);
        }
        bar = child.gameObject.GetComponent<HealthBar>();
        Debug.Log(bar.currentHealth);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            damageToTake = other.gameObject.GetComponent<bullet>();
            UpdateHealth(damageToTake.damage);
            Destroy(other.gameObject);
            
        }
    }

    void UpdateHealth(float damage)
    {

        health -= damage;
        
        bar.UpdateHealth(health);
        if(health <= 0)
        {
            DestroyUnit();
        }
        Debug.Log(health);
    }

    void DestroyUnit()
    {
       
        if (this.gameObject.tag == "Player")
        {
            
            UnitController Unit = new UnitController();
            Unit.Deselect(this.gameObject);
        }
        isDead = true;
        this.gameObject.tag = "dead";
        //collider.enabled = false;
        //this.gameObject.SetActive(false);
       Destroy(gameObject);
    }
}

