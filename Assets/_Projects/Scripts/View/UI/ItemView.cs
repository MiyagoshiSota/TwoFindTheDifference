using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class ItemView : VisualElement
    {
        private VisualElement img;
        private Label name;
    
        private string ItemName => name.text;
        
        public new class UxmlFactory : UxmlFactory<ItemView, UxmlTraits> { }
    
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlStringAttributeDescription _itemName = new() { name="item-name",defaultValue= "null" };
            private UxmlAssetAttributeDescription<Sprite> _itemImg = new() { name = "img"};

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var item = ve as ItemView;
                item.name.text = _itemName.GetValueFromBag(bag, cc);
                item.img.style.backgroundImage = new StyleBackground(_itemImg.GetValueFromBag(bag, cc));
            }
        }

        public ItemView()
        {
            var treeAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_Projects/UI/UIDocuments/Item.uxml");
            var container = treeAsset.Instantiate();
            hierarchy.Add(container);
        
            img = container.Q<VisualElement>("img");
            name = container.Q<Label>("name");
        }
    }
}