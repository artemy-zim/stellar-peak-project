using System;
using UnityEngine;

public interface IDestroyable
{
    public event Action Damaged;

    public void Hit(Vector3 hitForce, Vector3 hitPoint);
    public void Destroy();  
}
