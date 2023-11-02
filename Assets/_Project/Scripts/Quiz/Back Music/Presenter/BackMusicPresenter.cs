using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackMusicPresenter : IInitializable
{
    private readonly BackMusicModel model;
    private readonly BackMusicView view;

    public BackMusicPresenter(BackMusicModel model, BackMusicView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize()
    {
        SetNormalVolume();
    }

    public void MuteVolume()
    {
        view.SetVolume(model.MutedValue);
    }

    public void SetNormalVolume()
    {
        view.SetVolume(model.NormalValue);
    }
}
