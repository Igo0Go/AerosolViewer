using System;
using System.Collections.Generic;

public class AerosolCluster
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

    public event Action<List<AerosolParticle>> ParticlesChanged;

    public void SetNewParticlesForCluster(List<AerosolParticle> particles)
    {
        Particles = particles;

        foreach (var particle in Particles)
        {
            particle.Selected += (p) => OnSelectNewParticle(p);
        }
    }

    private void OnSelectNewParticle(AerosolParticle particle)
    {
        foreach (var p in Particles)
        {
            if(particle != p)
            {
                p.DeselectParticle();
            }
        }
    }
}
