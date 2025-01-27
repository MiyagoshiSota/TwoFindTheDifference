using UI;
using UnityEngine;

public class SerchItem : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private MainPlayView viewModel;
    private ItemView _itemView;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(_mainCamera.ScreenToWorldPoint(Input.mousePosition)  + ":" + viewModel.ViewModel.GetSelectedItem());
        }
    }
}
