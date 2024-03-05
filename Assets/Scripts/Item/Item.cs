using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected string _name;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public abstract void Use();


}
