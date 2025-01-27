using UI;
using UnityEngine;

public class SerchItem : MonoBehaviour
{
    private Camera _mainCamera;
    private MainPlayViewModel _mainPlayViewModel;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
        _mainPlayViewModel = new MainPlayViewModel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(_mainCamera.ScreenToWorldPoint(Input.mousePosition)  + ":" + _mainPlayViewModel.GetSelectedItem());
        }
    }
}
