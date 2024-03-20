using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] new private MeshRenderer renderer;
    
    private Material wantedMaterial;
    private string wantedName;

    private void Start()
    {
        wantedMaterial = renderer.material;
        Debug.Log(wantedMaterial.ToString());
        wantedName = wantedMaterial.ToString().Split(' ')[0];
        Debug.Log(wantedName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Debug.Log(other.GetComponent<MeshRenderer>().material.ToString().Split(' ')[0]);

            if (other.GetComponent<MeshRenderer>().material.ToString().Split(' ')[0] == wantedName)
                Debug.Log("Correct");
            else
            {
                Destroy(other.gameObject);
                Debug.Log("wrong");
            }
        }
    }
}
