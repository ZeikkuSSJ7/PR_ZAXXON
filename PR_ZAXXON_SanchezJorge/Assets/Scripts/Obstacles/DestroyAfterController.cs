using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f); // used for cross containers
    }
}
