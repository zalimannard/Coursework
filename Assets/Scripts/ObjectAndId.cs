using System;
using UnityEngine;

[Serializable]
public class ObjectAndId
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private GameObject _gameObject;

    public int GetId()
    {
        return _id;
    }

    public GameObject GetGameObject()
    {
        return _gameObject;
    }
}
