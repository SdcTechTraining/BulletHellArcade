using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public string KeyItemCode = "Key[Descriptor]";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.Current.gameObject)
        {
            Destroy(gameObject);
            Player.Current.Items.Add(KeyItemCode);
        }
    }

}
