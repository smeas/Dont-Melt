using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCritter : MonoBehaviour
{

    [SerializeField] private GameObject LeftObject;
    [SerializeField] private GameObject RightObject;
    [SerializeField] private Vector2 walkingSpeed = new Vector2(1, 0);
    [SerializeField] private bool flipSpriteToggle = true;
    private SpriteRenderer sprite;


    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.flipX = flipSpriteToggle;
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.x < LeftObject.transform.position.x) || (transform.position.x > RightObject.transform.position.x))
        {
            walkingSpeed *= -1;
            FlipSprite();
        }

        transform.position += (Vector3) walkingSpeed * Time.deltaTime;
    }

    void FlipSprite()
    {
        flipSpriteToggle = !flipSpriteToggle;
        sprite.flipX = flipSpriteToggle;
    }

}
