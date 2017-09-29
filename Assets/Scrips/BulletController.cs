using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public int damage;

    EnemyBehavior enemy;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent(typeof(EnemyBehavior)) as EnemyBehavior;
            enemy.TakeDamage(damage);

            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}
