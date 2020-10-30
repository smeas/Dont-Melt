using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCloud : MonoBehaviour
{

    [SerializeField] private float weightsPerSecond = 2;
    [SerializeField] private GameObject weight;
    private float accumlatedTime;
    private bool closeToCloud;
    

    // Update is called once per frame
    void Update()
    {
        accumlatedTime += Time.deltaTime;

        if ((accumlatedTime > weightsPerSecond) && closeToCloud)
        {
            Fire();
            accumlatedTime = 0;
        }
    }

    public void Fire()
    {
        GameObject newWeight;

        newWeight = Instantiate(weight, transform.position, transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeToCloud = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeToCloud = false;
    }

}
