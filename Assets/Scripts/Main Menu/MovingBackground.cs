using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private const float MAX_X = 15.9f;
    [SerializeField] private const float START_X = -24.9f;
    [SerializeField] private float speed = 0.025f;
    [SerializeField] private int firstIndex;
    [SerializeField] private SpriteRenderer[] spriteRenderers = new SpriteRenderer[4];

    private void Awake()
    {
        firstIndex = spriteRenderers.Length - 1;
    }

    private void Update()
    {
        foreach (SpriteRenderer renderer in spriteRenderers)
            renderer.transform.localPosition = Vector3.MoveTowards(
                renderer.transform.localPosition,
                new Vector3(
                    MAX_X + 1,
                    renderer.transform.localPosition.y,
                    renderer.transform.localPosition.z)
                    , speed * Time.fixedDeltaTime);

        if (spriteRenderers[firstIndex].transform.localPosition.x >= MAX_X)
        {
            spriteRenderers[firstIndex].transform.localPosition = new Vector3(
                START_X,
                spriteRenderers[firstIndex].transform.localPosition.y,
                spriteRenderers[firstIndex].transform.localPosition.z);

            if (firstIndex == 0)
                firstIndex = spriteRenderers.Length - 1;
            else
                firstIndex--;
        }
    }
}
