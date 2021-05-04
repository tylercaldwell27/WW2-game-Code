using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Vector3 shootDir;
    public float speed = 10;
    public float damage;
    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
    }
    // Start is called before the first frame update
    private void Start()
    {
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.position += shootDir * speed * Time.deltaTime;
        Destroy(gameObject, 2);
    }
}
