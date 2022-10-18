using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOnWinField : MonoBehaviour
{
    private int timeToWin = 10;
    public float playerTimer = 0;
    public float enemyTimer = 0;
    public GameObject winScreen;
    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTimer += Time.deltaTime;

            if(playerTimer > timeToWin)
            {
                winScreen.gameObject.SetActive(true);
            }
        }

        else if (other.CompareTag("Enemy"))
        {
            enemyTimer += Time.deltaTime;

            if (enemyTimer > timeToWin)
            {
                loseScreen.gameObject.SetActive(true);
            }
        }

    }
}
