using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Multi", menuName = "Create New Multi")]
public class MultiButton : BaseScriptable
{
    [SerializeField] float multi;

    public float GetMulti()
    {
        return multi;
    }
}
