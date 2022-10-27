using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject[] players;
    [SerializeField] private Transform pfBullet;
    [SerializeField] private GameObject Enemy;
    public PlayerLogic PlayerLogic;
    public GameObject thisplayer;
    public Transform shootFrom;
    public float bulletspeed;

    /*
    [SerializeField] float fireRate = 2f;
    public AIStateMachine aiScript;
    private float nextAIShootTime;
    */
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player != gameObject)
            {
                Enemy = player;
                break;
            }
        }
        PlayerLogic = gameObject.GetComponent<PlayerLogic>();
        //aiScript = FindObjectOfType<AIStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && PlayerLogic.Bullets > 0 && PlayerLogic.isHuman == true) //serialize this
        {
            PlayerLogic.Bullets--;
            Shoot();
        }
        /*
        if (aiScript.startAttack && PlayerLogic.Bullets > 0 && PlayerLogic.isHuman == false) //serialize this
        {
            if (Time.time > nextAIShootTime)
            {
                nextAIShootTime = Time.time + fireRate;
                PlayerLogic.Bullets--;
                Shoot();
            }
        }
        */
    }
    public void Shoot()
    {
        Vector3 dir = new Vector3(1f, 0f, 0f);
        var bullet = Instantiate(pfBullet, shootFrom.position, shootFrom.rotation);
        bullet.GetComponent<Rigidbody>().velocity = shootFrom.forward * bulletspeed;
        bullet.GetComponent<BulletLogic>().SetUp(Enemy, gameObject);

    }
}