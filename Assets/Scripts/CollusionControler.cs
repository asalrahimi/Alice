using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusionControler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Magic")) {
        Destroy(gameObject);
    }
    }
}
