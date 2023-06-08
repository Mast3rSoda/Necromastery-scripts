using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraRotationNearWall : MonoBehaviour
{
    private Transform _playerTransform;

    [Inject]
    public void Init(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        if (Physics.Raycast(_playerTransform.position, Vector3.back, out RaycastHit hit, 2.5f))
            transform.rotation = Quaternion.Euler(Mathf.Lerp(60f, 90f, 1 - ((hit.distance - 0.5f) / 2f)), 0f, 0f);
    }
}
