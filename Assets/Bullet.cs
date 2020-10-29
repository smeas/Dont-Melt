using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Vector2 velocity;
    [SerializeField] private float destroyAfterXSeconds = 10;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfterXSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * ((Vector3)velocity * Time.deltaTime);
    }

    public void Fire(Vector2 velocity)
    {
        this.velocity = velocity;
    }

}
