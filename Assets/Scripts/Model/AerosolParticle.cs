using System;
using UnityEngine;

public class AerosolParticle
{
    public event Action<AerosolParticle> Selected;

    public float X;
    public float Y;
    public float Z;
    public float radius;

    public float Ns;
    public float Nt;
    public float a;

    public Vector3 GetTransformPosition()
    {
        return new Vector3(X, Z, Y);
    }

    public void SelectParticle()
    {
        Selected?.Invoke(this);
    }
}
