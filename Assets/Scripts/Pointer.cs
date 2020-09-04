using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public GameObject _ObjToTrack;

    // Update is called once per frame
    void Update()
    {
        if (_ObjToTrack) {
            transform.LookAt(_ObjToTrack.transform,new Vector3(0,0,0));
        } else {
            Destroy(this.gameObject);
        }
    }
}
