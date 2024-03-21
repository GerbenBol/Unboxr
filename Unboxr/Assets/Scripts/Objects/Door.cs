using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDestructable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private new GameObject light;
    [SerializeField] private Material material;

    private void Start()
    {
        // Voeg deur toe aan level manager
        LevelManager.AddDoor(gameObject);
    }

    public void Interact(GameObject boxHolder = null)
    {
        // Disable lock
        if (LevelManager.LevelCompleted)
        {
            rb.freezeRotation = false;
            rb.AddRelativeForce(new(500, 0, 0));
        }
    }

    public void TurnOnLight()
    {
        // Doe licht aan voor extra clarity
        light.GetComponent<MeshRenderer>().material = material;
    }
}
