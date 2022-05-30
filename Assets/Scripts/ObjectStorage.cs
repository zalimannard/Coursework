using System;
using UnityEngine;

[Serializable]
public class ObjectStorage
{
    [SerializeField] private GameObject _ground;
    [SerializeField] private GameObject _dirt;
    [SerializeField] private GameObject _grass;
    [SerializeField] private ObjectAndId[] _objectAndIds;

    public GameObject GetGameObject(int id)
    {
        foreach (ObjectAndId objectAndId in _objectAndIds)
        {
            if (objectAndId.GetId().Equals(id))
            {
                return objectAndId.GetGameObject();
            }
        }

        return null;
    }

    public GameObject GetGround()
    {
        return _ground;
    }

    public GameObject GetDirt()
    {
        return _dirt;
    }

    public GameObject GetGrass()
    {
        return _grass;
    }
}
