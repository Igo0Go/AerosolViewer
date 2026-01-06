using System.Collections.Generic;
using UnityEngine;

public class AerosolClusterComponent : MonoBehaviour
{
    [SerializeField] private GameObject particlePrefab;

    public void Init()
    {
        ClearOldCluster();
    }

    public void UpdateCluster(List<AerosolParticle> particles)
    {
        ClearOldCluster();

        foreach (AerosolParticle particle in particles)
        {
            AerosolParticleComponent particleComponent = Instantiate(particlePrefab, transform).
                GetComponent<AerosolParticleComponent>();
            particleComponent.Init(particle);
        }
    }

    private void ClearOldCluster()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
