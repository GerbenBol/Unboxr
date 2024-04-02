using UnityEngine;

public class Door : MonoBehaviour, IInteractable, IDestructable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private new GameObject light;
    [SerializeField] private Material material;
    [SerializeField] private int level;

    private IngameUI uiController;

    private void Start()
    {
        // Voeg deur toe aan level manager
        LevelManager.Levels[level].AddDoor(gameObject);

        // Vraag naar UI controller
        uiController = GameObject.Find("UI").GetComponent<IngameUI>();
    }

    public void Interact(GameObject boxHolder = null)
    {
        // Disable lock
        if (LevelManager.Levels[level].Completed)
            rb.AddRelativeForce(new(0, 0, 20000));
        else
            uiController.UpdateLockedEnabled();
    }

    public void TurnOnLight()
    {
        // Doe licht aan voor extra clarity
        light.GetComponent<MeshRenderer>().material = material;
    }
}
