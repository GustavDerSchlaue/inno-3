using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    //Use: healthbar pointing at same direction as camara
    public Transform camera;
    public GameObject canvas;
    public GameObject player;
    public PlayerLogic playerLogic;

    public void Start()
    {
        playerLogic = player.GetComponent<PlayerLogic>();
        if (playerLogic.isHuman == true)
        {
            canvas.SetActive(false);
        }
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called after each regular Update => otherwise weird behaiviour
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
