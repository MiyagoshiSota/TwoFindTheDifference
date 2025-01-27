using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UIElements.Button;

namespace UI{   
    public class MainPlayView : MonoBehaviour
    {
        private VisualElement _root;
        private VisualElement _itemsWrapper;
        private Button _itemsUpButton;
        private ScrollView _scrollView;
        private MainPlayViewModel _viewModel;

        private void Start()
        {
            // ViewModelの初期化
            _viewModel = new MainPlayViewModel();

            // UI要素の取得
            _root = GetComponent<UIDocument>().rootVisualElement;
            _itemsWrapper = _root.Q<VisualElement>("ItemsWrapper");
            _itemsUpButton = _root.Q<Button>("ItemsUpButton");
            _scrollView = _root.Q<ScrollView>();
            
            // アイテムの取得
            BindItems();

            _itemsUpButton.clicked += ToggleItemsWrapper;
        }

        private void BindItems()
        {
            _scrollView.contentContainer.Clear();
            var items = _viewModel.Items;

            for (var i = 0; i < items.Count; i++)
            {
                var item = new Label(items[i].ItemName);
                var index = i;

                // 選択可能にする
                item.AddManipulator(new Clickable(() => { _viewModel.SelectItem(index); }));
                
                // 
                if (items[i].IsSelected) {item.AddToClassList("itemSelected");}
                else { item.RemoveFromClassList("itemSelected"); }

                _scrollView.contentContainer.Add(item);
            }
        }

        /// <summary>
        /// ItemsWrapperの上下とそのアニメーション
        /// </summary>
        private void ToggleItemsWrapper()
        {
            if (_itemsWrapper.ClassListContains("ItemsDown"))
            {
                _itemsWrapper.RemoveFromClassList("ItemsDown");
                _itemsWrapper.AddToClassList("ItemsUp");
            }
            else
            {
                _itemsWrapper.RemoveFromClassList("ItemsUp");
                _itemsWrapper.AddToClassList("ItemsDown");
            }
        }
    }
}