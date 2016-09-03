using UnityEngine;
using System.Collections;

public class SafeArea : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IShot>() != null) Destroy(other.gameObject);
    }
}
