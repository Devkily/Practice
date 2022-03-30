using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFB : MonoBehaviour
{
    [SerializeField] private BirdFB _bird;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        transform.position = new Vector3(_bird.transform.position.x - _xOffset, transform.position.y,transform.position.z);
    }
}
