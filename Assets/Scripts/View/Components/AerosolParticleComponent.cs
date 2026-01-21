using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]
public class AerosolParticleComponent : MonoBehaviour
{
    public event Action Selected;

    private MeshRenderer m_Renderer;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    public void Init(AerosolParticle data)
    {
        transform.localPosition = data.GetTransformPosition();
        transform.localScale = Vector3.one * data.radius;
        Selected += data.SelectParticle;
        data.SelectedChanged += OnSelectedChanged;
        Deselect();
    }

    private void OnSelectedChanged(bool value)
    {
        if(value)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }
    private void Select()
    {
        m_Renderer.material.color = Color.red;
    }
    private void Deselect()
    {
        m_Renderer.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        Selected?.Invoke();
    }
    private void OnDestroy()
    {
        Selected = null;
    }
}
