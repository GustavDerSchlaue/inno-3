using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] players;
    public GameObject humanplayer;
    public PlayerLogic playerLogic;
    private Vector3 offsetvector;
    void Start()
    {
        offsetvector = new Vector3(0, 20, -15);
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            playerLogic = player.GetComponent<PlayerLogic>();
            if (playerLogic.isHuman == true)
            {
                humanplayer = player;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = humanplayer.transform.position + offsetvector;
    }

    internal object ScreenPointToRay(Vector3 mousePosition)
    {
        throw new NotImplementedException();
    }
}
