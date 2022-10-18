using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifepoints;
    public Color color = new Color(0f,1f,0f,10f);
    Light lt;
    void Start()
    {
        lifepoints = 100f;
        lt = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {

        color = new Color((0f+((100f-lifepoints)*0.01f)), (1f-((100f-lifepoints)*0.01f)), 0f, 1f);
        lt.GetComponent<Light>().color = color; ;
    }
}
