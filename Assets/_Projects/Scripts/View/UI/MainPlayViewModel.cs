using System.Collections.Generic;
using System.ComponentModel;

namespace UI
{
    public class MainPlayViewModel : INotifyPropertyChanged
    {
        private List<ItemModel> _items;
        private int _nowSelect;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MainPlayViewModel()
        {
            _items = new List<ItemModel>
            {
                new ItemModel { ItemName = "Item 1", IsSelected = false },
                new ItemModel { ItemName = "Item 2", IsSelected = false },
                new ItemModel { ItemName = "Item 3", IsSelected = false }
            };
            _nowSelect = -1;
        }

        public List<ItemModel> Items => _items;

        public void SelectItem(int index)
        {
            _nowSelect = index;

            // 全アイテムの選択状態を更新
            for (var i = 0; i < _items.Count; i++)
            {
                _items[i].IsSelected = (i == index);
            }
        }

        public ItemModel GetSelectedItem()
        {
            return _items[_nowSelect];
        }
    }

}