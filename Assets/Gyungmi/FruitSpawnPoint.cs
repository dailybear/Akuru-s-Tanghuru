using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } set { isPlaceable = value; } }
}
