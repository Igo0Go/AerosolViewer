using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Center : MonoBehaviour
{
    [SerializeField]
    private LoaderPanel _loaderPanel;

    public event Action StartLoadNewFile;

    public void Init(AerosolClusterViewModel viewModel)
    {
        _loaderPanel.LoadFileClick += viewModel.LoadFile;
        viewModel.FileLoadFinalled += _loaderPanel.OnLoadFinaled;
    }
}
