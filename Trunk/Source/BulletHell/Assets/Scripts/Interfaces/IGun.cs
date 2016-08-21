using UnityEngine;
using System.Collections;

public interface IGun {

    float Force { get; set; }

    GameObject Prefab { get; set; }
}
