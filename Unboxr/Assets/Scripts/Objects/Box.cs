using UnityEngine;

public class Box : MonoBehaviour, IInteractable, IDestructable
{
    [SerializeField] private BoxSpawning spawner;
    [SerializeField] private int level;

    public bool Locked = false;

    private Rigidbody rb;
    private MeshRenderer myMesh;
    private string myMatName = string.Empty;
    private bool beingHold = false;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myMesh = GetComponent<MeshRenderer>();
        myMatName = myMesh.material.ToString().Split(' ')[0];
        startPosition = transform.position;
        LevelManager.Levels[level].AddBox(this);
    }

    private void Update()
    {
        // Verander positie van doos als we niet op de juiste plek zijn
        if (beingHold && Vector3.Distance(transform.position, transform.parent.position) > .1f)
        {
            Vector3 moveDir = (transform.parent.position - transform.position);
            rb.AddForce(moveDir * 100);
        }

        if (beingHold && Locked)
            Drop();
    }

    public void Respawn()
    {
        // Respawn doos bij de spawner
        LevelManager.CurrentSpawner.SpawnNewBox(myMesh.material);
    }

    public void Interact(GameObject boxHolder = null)
    {
        // Check of we vastgehouden worden & of we vastzitten aan een button
        if (boxHolder != null && !Locked)
        {
            if (!beingHold)
                Pickup(boxHolder);
            else
                Drop();
        }
    }

    public void Restart()
    {
        // Reset de positie van de doos
        transform.position = startPosition;
    }

    private void Pickup(GameObject boxHolder)
    {
        // Oppakken van de doos
        transform.SetParent(boxHolder.transform);
        transform.localPosition = new(0, 0, transform.localScale.z + 1);
        transform.rotation = Quaternion.identity;
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.drag = 10;
        beingHold = true;

        // Turn on lights
        LevelManager.Levels[level].SearchLights(true, myMatName);
    }

    private void Drop()
    {
        // Laat doos vallen
        transform.parent = null;
        rb.useGravity = true;
        rb.freezeRotation = false;
        rb.drag = 1;
        beingHold = false;

        // Turn off lights
        LevelManager.Levels[level].SearchLights(false, myMatName);
    }
}
