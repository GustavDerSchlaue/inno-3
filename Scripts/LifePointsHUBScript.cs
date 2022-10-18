using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointsHUBScript : MonoBehaviour
{
    public GameObject[] players;
    public PlayerLogic _player;
    public PlayerLogic _opponent;
    public Text playerLifeHUD;
    public Text oponentLifeHUD; 

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player != gameObject)
            {
                _opponent = player.GetComponent<PlayerLogic>();
                break;
            }
            if (player == gameObject)
            {
                _player = player.GetComponent<PlayerLogic>();
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
            playerLifeHUD.text = _player.HP.ToString();
            oponentLifeHUD.text = _opponent.HP.ToString();
    }
}
