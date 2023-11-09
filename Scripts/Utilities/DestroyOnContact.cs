using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public string tagTarget = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagTarget)
        {
            Destroy(this.gameObject);
        }
    }
}
