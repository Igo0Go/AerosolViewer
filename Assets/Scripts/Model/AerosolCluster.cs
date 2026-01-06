using System;
using System.Collections.Generic;
using UnityEngine;

public class AerosolCluster : MonoBehaviour
{
    public List<AerosolParticle> Particles
    {
        get
        {
            return _particles;
        }
        private set
        {
            _particles = value;
            ParticlesChanged?.Invoke(_particles);
        }
    }
    private List<AerosolParticle> _particles;

    public event Action<AerosolParticle> NewParticleSelected;
    public event Action<List<AerosolParticle>> ParticlesChanged;

    public void SetNewParticlesForCluster(List<AerosolParticle> particles)
    {
        Particles = particles;
        foreach (var particle in Particles)
        {
            particle.Selected += (p) => NewParticleSelected?.Invoke(p);
        }
    }
}
