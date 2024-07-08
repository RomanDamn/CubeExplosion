using System;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;

    private RaycastHit hit;

    private int _leftMouseButtonNumber = 0;

    public event Action<RaycastHit> ObjectClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(_leftMouseButtonNumber))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                ObjectClicked?.Invoke(hit);
            }
        }
    }
}
