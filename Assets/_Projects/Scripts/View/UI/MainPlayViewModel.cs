using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class MainPlayViewModel : INotifyPropertyChanged
    {
        private List<ItemModel> _items = new List<ItemModel>();
        private int _nowSelect = -1;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MainPlayViewModel()
        {
            var itemsQuery = ItemsWrapperView.ItemsQuery;

            foreach (var item in itemsQuery.ToList())
            {
                var name = item.name;
                
                // positionのキャスト
                var strPosition = item.Q<Label>("position").text;
                var strSplitPosition = strPosition.Substring(1, strPosition.Length-2).Split(",");
                var position = new Vector2(float.Parse(strSplitPosition[0]), float.Parse(strSplitPosition[1]));

                _items.Add(new ItemModel { ItemName = name, IsSelected = false, Position = position, ItemView = item.Q<ItemView>() });
            }
        }

        public List<ItemModel> Items => _items;

        public void SelectItem(int index)
        {
            // 全アイテムの選択状態を更新
            for (var i = 0; i < _items.Count; i++)
            {
                if (i == index)
                {
                    _nowSelect = index;
                    _items[index].ItemView.AddToClassList("itemSelected");
                }
                else
                {
                    _items[i].ItemView.RemoveFromClassList("itemSelected");
                }
            }
            Debug.Log(_nowSelect);
        }
        
        public ItemModel GetSelectedItem()
        {
            return _nowSelect == -1 ? null : _items[_nowSelect];
        }
    }

}