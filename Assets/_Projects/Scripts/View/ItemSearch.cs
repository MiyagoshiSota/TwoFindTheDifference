using DefaultNamespace;
using UI;
using UnityEngine;

public class ItemSearch : MonoBehaviour
{
    private Camera _mainCamera;
    private ItemView _itemView;
    private ItemVisible _itemVisible;
    [SerializeField] private MainPlayView viewModel;
    
    void Start()
    {
        _itemVisible = new ItemVisible();
        _mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 現在選択中のアイテムの取得とnullチェック
            var selectedItem = viewModel.ViewModel.GetSelectedItem();
            if (selectedItem == null) return;
            
            // アイテムのポジション
            var itemPosition = selectedItem.Position;
            
            // ポインターのスクリーンポジション
            var pointerPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            // 正誤判定
            if ((itemPosition.x + 5 > pointerPosition.x && itemPosition.x - 5 < pointerPosition.x) && (itemPosition.y + 5 > pointerPosition.y && itemPosition.y - 5 < pointerPosition.y ))
            {
                _itemVisible.Visible(selectedItem);
            }
        }
    }
}
