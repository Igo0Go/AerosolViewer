using UnityEngine;

public class InitializationQueue : MonoBehaviour
{
    [SerializeField]
    private AerosolClusterViewModel _clusterViewModel;
    [SerializeField]
    private AerosolClusterComponent _clusterComponent;
    [SerializeField]
    private UI_Center _ui_Center;

    public void Awake()
    {
        _clusterComponent.Init();
        _clusterViewModel.Init(_clusterComponent);
        _ui_Center.Init(_clusterViewModel);
    }
}
