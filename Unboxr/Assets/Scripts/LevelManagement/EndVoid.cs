using UnityEngine;

public class EndVoid : MonoBehaviour
{
    [SerializeField] private GameObject box;

    public void StartVoid()
    {
        // Delete all other boxes
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");

        for (int i = 0; i < boxes.Length; i++)
            Destroy(boxes[i]);

        // Spawn box & make player grow
        box.SetActive(true);
        BoxShrink.Shrink();
    }
}
