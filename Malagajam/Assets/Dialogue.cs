using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string name;

    [TextArea(0, 10)]
    public string[] sentances;
}
