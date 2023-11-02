using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFinder : MonoBehaviour
{
    public string tagName;
    public string targetName;
    public bool stilSearching;
    private GameObject target;

    private void Update()
    {
        if (stilSearching)
        {
            FindTag();
        }
    }

    private void FindTag()
    {
        target = GameObject.Find("Generated Level").transform.Find("Tilemaps").transform.Find(targetName).gameObject;

        target.tag = tagName;

        stilSearching = false;
    }
}
