using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] public GameObject player;
    [SerializeField] public float horizontalSpeed = 3.0F;
    PlayerLogic playerscript;
    public float speed = 12f;

    //public float turnSmoothTime = 0.1f;
    //float turnSmoothVelocity;
    void Start()
    {
        playerscript = player.GetComponent<PlayerLogic>();
    }
    void Update()
    {
        float angle = horizontalSpeed * Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (playerscript.isHuman == true)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            transform.Rotate(0, angle, 0);


            if (direction.magnitude >= 0.1f)
            {
                float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                controller.Move(direction * speed * Time.deltaTime);
            }
        }
        if (this.transform.position.y != 3)
            this.transform.position = new Vector3(this.transform.position.x,3, this.transform.position.z);
    }
}
