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
            // アイテムのポジション
            var itemPosition = viewModel.ViewModel.GetSelectedItem().Position;
            
            // ポインターのスクリーンポジション
            var pointerPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            if ((itemPosition.x + 5 > pointerPosition.x && itemPosition.x - 5 < pointerPosition.x) && (itemPosition.y + 5 > pointerPosition.y && itemPosition.y - 5 < pointerPosition.y ))
            {
                Debug.Log($"itemPosition: {itemPosition} , pointerPosition: {pointerPosition}");
            }
        }
    }
}
