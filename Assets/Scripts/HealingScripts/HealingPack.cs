using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPack : MonoBehaviour
{       
    public PlayerLogic playerLogic;
    public GameObject[] players;
    public GameObject[] enemies;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        ScaleToTarget(new Vector3(0.2f, 0.2f, 0.2f), lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
        transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        int i = 0;
        if (other.gameObject == players[0])
        {
            Debug.Log("test");
            i = players[0].GetComponent<PlayerLogic>().HP + 50;
            if (i > 100)
            {
                i = 100;
            }
            players[0].GetComponent<PlayerLogic>().HP = i;
            Destroy(gameObject);
        }
        else if (other.gameObject == enemies[0])
        {
            Debug.Log("testb");
            i = enemies[0].GetComponent<PlayerLogic>().HP + 50;
            if (i > 100)
            {
                i = 100;
            }
            enemies[0].GetComponent<PlayerLogic>().HP = i;
            Destroy(gameObject);
        }
    }

    public void ScaleToTarget(Vector3 targetScale, float duration)
    {
        StartCoroutine(ScaleToTargetCoroutine(targetScale, duration));
    }

    private IEnumerator ScaleToTargetCoroutine(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            //smoother step algorithm
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        yield return null;
    }
}
