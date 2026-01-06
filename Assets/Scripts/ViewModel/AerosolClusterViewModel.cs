using System;
using System.Collections.Generic;
using UnityEngine;

public class AerosolClusterViewModel : MonoBehaviour
{
    public event Action<AerosolParticle> NewParticleSelected;
    public event Action<FileAccessResult> FileLoadFinalled;

    private AerosolCluster model;

    public void Init(AerosolClusterComponent aerosolClusterComponent)
    {
        model = new AerosolCluster();
        model.NewParticleSelected += (p) => NewParticleSelected?.Invoke(p);
        model.ParticlesChanged += aerosolClusterComponent.UpdateCluster;
    }

    public void LoadFile()
    {
        FileAccessResult result = FileAccessUtility.GetDataFromFile();
        FileLoadFinalled?.Invoke(result);

        if(result.success)
        {
           model.SetNewParticlesForCluster(ParsingUtility.ParceFromString(result.fileText));
        }
    }
}

public class PartivleViewItem
{
    public AerosolParticle model;
}
