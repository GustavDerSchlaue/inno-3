using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    private int bounces;
    private GameObject target;
    private Rigidbody rb;
    private GameObject player;
    Vector3 lastvelocity;

    [SerializeField]
    int maxbounce;
    [SerializeField]
    float speed;
    Vector3 dire = new Vector3();
    int slowframes = 0;

    public void SetUp( GameObject enemy, GameObject _player)
    {
        this.target = enemy;
        this.bounces = this.maxbounce;
        player = _player;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        lastvelocity = rb.velocity;
        if (lastvelocity.magnitude<40)
            ++slowframes;
        if(slowframes>4)
            Destroy(gameObject);
    }


    //Regocnizes what the bullet did hit and starts appropiate response
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject == target)
        {
            target.GetComponent<PlayerLogic>().Damage();
            Destroy(gameObject);
            return;
        }
        if (bounces == 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            bounces--;
            Bounce(collision.contacts[0].normal);
        }
    }

    //Bounces bullets of walls
    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastvelocity.magnitude;
        var direction = Vector3.Reflect(lastvelocity.normalized, collisionNormal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
    }
}