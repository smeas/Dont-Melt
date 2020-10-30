using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniel
public class Cannon : MonoBehaviour
{

    [SerializeField] private Vector2 velocity = new Vector2(-4, 0);
    [SerializeField] private float bulletsPerSecond = 2;
    [SerializeField] private Bullet bullet;
    private float accumlatedTime;
    private bool closeToCannon;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        accumlatedTime += Time.deltaTime;

        if ((accumlatedTime > bulletsPerSecond) && closeToCannon)
        {
            Fire();
            accumlatedTime = 0;
        }
    }

    public void Fire()
    {
        Bullet newBullet;

        newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.transform.localScale = transform.localScale;
        newBullet.Fire(velocity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeToCannon = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        closeToCannon = false;
    }

}
