using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    private static bool isGrowing = false;
    private Vector3 growIncrease = new(.5f, .5f, .5f);
    private readonly float maxHeight = 14.35f;
    private readonly float waitTimer = .05f;
    private float timer = .0f;

    private void Update()
    {
        if (isGrowing && timer > waitTimer && transform.localScale.y < maxHeight)
        {
            transform.localScale += growIncrease;
            timer = .0f;
        }
        else timer += Time.deltaTime;
    }

    public static void Grow()
    {
        isGrowing = true;
    }
}
