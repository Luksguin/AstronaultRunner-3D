using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        CITY,
        FARM,
        FLOREST
    }

    public List<ArtSetup> artSetup;

    public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetup.ForEach(i => i.artType = artType);
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
