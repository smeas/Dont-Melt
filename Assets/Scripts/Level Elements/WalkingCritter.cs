using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Daniel
public class WalkingCritter : MonoBehaviour
{

    [SerializeField] private GameObject LeftObject;
    [SerializeField] private GameObject RightObject;
    [SerializeField] private Vector2 walkingSpeed = new Vector2(1, 0);
    [SerializeField] private bool flipSpriteToggle = true;
    private SpriteRenderer sprite;

    private Vector3 leftPoint;
    private Vector3 rightPoint;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.flipX = flipSpriteToggle;

        leftPoint = LeftObject.transform.position;
        rightPoint = RightObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.x < leftPoint.x) || (transform.position.x > rightPoint.x))
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
