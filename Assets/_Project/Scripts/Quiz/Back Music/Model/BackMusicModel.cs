using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicModel 
{
    public readonly float NormalValue;
    public readonly float MutedValue;

    public BackMusicModel(float normalValue, float mutedValue)
    {
        NormalValue = normalValue;
        MutedValue = mutedValue;
    }
}
