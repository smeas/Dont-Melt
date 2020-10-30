using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCritter : MonoBehaviour
{

    [SerializeField] private GameObject LeftObject;
    [SerializeField] private GameObject RightObject;
    [SerializeField] private Vector2 walkingSpeed = new Vector2(1, 0);
    

    // Update is called once per frame
    void Update()
    {

        transform.position += (Vector3) walkingSpeed;

    }
}
