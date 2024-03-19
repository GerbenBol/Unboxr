using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] new private MeshRenderer renderer;
    
    private Material wantedMaterial;

    private void Start()
    {
        wantedMaterial = renderer.material;
        Debug.Log(wantedMaterial.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Debug.Log(other.GetComponent<MeshRenderer>().material.ToString());

            if (other.GetComponent<MeshRenderer>().material == wantedMaterial)
                Debug.Log("Correct");
            else
            {
                Destroy(other.gameObject);
                Debug.Log("wrong");
            }
        }
    }
}
