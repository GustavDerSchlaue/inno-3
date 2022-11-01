using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayOnWinField : MonoBehaviour
{
    private int timeToWin = 10;
    public float playerTimer = 0;
    public float enemyTimer = 0;
    public GameObject winScreen;
    public GameObject loseScreen;
    public bool playerin = false;
    public bool enemyin = false;
    public Image CapturePIndicator;
    public Image CaptureEIndicator;
    float fill = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        CapturePIndicator.fillAmount = 0;
        CaptureEIndicator.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CapturePIndicator.fillAmount = fill * playerTimer;
        CaptureEIndicator.fillAmount= fill * enemyTimer;
        if(!playerin && !enemyin )
        {
            if(playerTimer>0)
                playerTimer -= Time.deltaTime;
            if (enemyTimer>0)
                enemyTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerin = true;
            if(!enemyin)
            {
                if (enemyTimer > 0)
                    enemyTimer -= Time.deltaTime;
                else
                playerTimer += Time.deltaTime;
            }

            if(playerTimer > timeToWin)
            {
                winScreen.gameObject.SetActive(true);
            }
        }

        else if (other.CompareTag("Enemy"))
        {
            enemyin=true;
            if (!playerin)
            {
                if (playerTimer > 0)
                    enemyTimer -= Time.deltaTime;
                else
                    enemyTimer += Time.deltaTime;
            }
                

            if (enemyTimer > timeToWin)
            {
                loseScreen.gameObject.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
           enemyin=false;
        if(other.CompareTag("Player"))
            playerin=false;
    }
}
