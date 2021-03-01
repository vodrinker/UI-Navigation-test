using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulController : MonoBehaviour
{
    public static SoulController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<SoulItem> Souls;
}
