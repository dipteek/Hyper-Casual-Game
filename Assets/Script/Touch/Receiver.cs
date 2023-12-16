using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    private GameObject _PassedGameObject;
    public GameObject PassedGameObject
    {
        get => _PassedGameObject;
        set
        {
            _PassedGameObject = value;
            Debug.Log ( $"Receiver[{name}] just received \'{_PassedGameObject.name}\'" );
        }
    }
}
