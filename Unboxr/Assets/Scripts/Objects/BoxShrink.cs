using UnityEngine;

public class BoxShrink : MonoBehaviour
{
    private static bool isShrinking = false;
    private Vector3 shrinkDecrease = new(-.5f, -.5f, -.5f);
    private readonly int maxHeight = 1;
    private readonly float waitTimer = .05f;
    private float timer = .0f;

    private void Update()
    {
        if (isShrinking && transform.localScale.y > maxHeight)
        {
            if (timer > waitTimer)
            {
                transform.localScale += shrinkDecrease;
                timer = .0f;
            }
            else timer += Time.deltaTime;

            if (transform.localScale.y <= maxHeight)
                isShrinking = false;
        }
    }

    public static void Shrink()
    {
        isShrinking = true;
    }
}
