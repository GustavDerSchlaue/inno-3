using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingControllerScript : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public int maxnumberofpacks = 2;
    private float lasttimespawned;
    public float cooldown;

    public GameObject healingpack;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] healingspacksnumber = GameObject.FindGameObjectsWithTag("HealingPack");
        //Debug.Log("number: " + healingspacksnumber.Length);
        if (healingspacksnumber.Length < maxnumberofpacks && lasttimespawned + cooldown < Time.time)
        {
            lasttimespawned = Time.time;
             SpawnHealingPack();
        }
    }

    public void SpawnHealingPack()
    {
        while (true)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
            Collider[] hitcollider = Physics.OverlapSphere(pos, 0f);
            if (hitcollider.Length <= 0)
            {
                Instantiate(healingpack, pos, Quaternion.identity);
                break;
            }
            else
            {
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(center, size);
    }
}
