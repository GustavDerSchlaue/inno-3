using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinfieldUIView : MonoBehaviour
{

    // Update is called once per frame
    public Transform camera;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called after each regular Update => otherwise weird behaiviour
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
