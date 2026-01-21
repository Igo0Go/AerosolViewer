using System;
using UnityEngine;

public class AerosolParticle
{
    public event Action<bool> SelectedChanged;
    public event Action<AerosolParticle> Selected;

    public float X;
    public float Y;
    public float Z;
    public float radius;

    public float Ns;
    public float Nt;
    public float a;

    private bool selectedValue = false;

    public Vector3 GetTransformPosition()
    {
        return new Vector3(X, Z, Y);
    }

    public void SelectParticle()
    {
        selectedValue = true;
        SelectedChanged?.Invoke(selectedValue);
        Selected?.Invoke(this);
    }
    public void DeselectParticle()
    {
        selectedValue = false;
        SelectedChanged?.Invoke(selectedValue);
    }
}
