using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIndicator : MonoBehaviour
{
    public Image BulletIndicator;
    public PlayerLogic _player;
    int _count = 0;
    float fill = 1f;
    // Start is called before the first frame update
    void Start()
    {
        BulletIndicator.fillAmount = 1;
        _count = _player.maxbullets;
        fill /= _count;

    }

    // Update is called once per frame
    void Update()
    {
        
        BulletIndicator.fillAmount =fill*_player.Bullets;
    }
}
