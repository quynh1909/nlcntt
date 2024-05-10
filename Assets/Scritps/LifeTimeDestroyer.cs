using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTimeDestroyer : MonoBehaviour
{
    public float liveTime = 2f;
    void Start()
    {
        Destroy(this.gameObject, liveTime);
    }


}
