using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    private Vector3 direction;
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

    public void Setup(Vector3 dir, GameObject enemy, GameObject _player)
    {
        transform.eulerAngles = dir;
        this.target = enemy;
        this.bounces = this.maxbounce;
        dire = dir;
        player = _player;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(player.transform.forward * .0002f*speed);//weird
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