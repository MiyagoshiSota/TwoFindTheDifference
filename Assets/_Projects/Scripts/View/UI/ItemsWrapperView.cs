using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class ItemsWrapperView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<ItemsWrapperView, UxmlTraits> { }
        public static UQueryBuilder<ItemView> ItemsQuery;

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlAssetAttributeDescription<ItemsScriptableObject> _itemsList = new() {name = "items"};
            
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                if (_itemsList.TryGetValueFromBag(bag,cc,out ItemsScriptableObject item))
                {
                    foreach (var itemInf in item.itemsList)
                    {
                        // Itemを動的に生成
                        var itemVisualElement = new ItemView();
        
                        // Itemのプロパティに値を設定
                        itemVisualElement.Q<Label>("name").text = itemInf.itemName;
                        itemVisualElement.Q<Label>("position").text = itemInf.itemPosition.ToString();
                        itemVisualElement.Q<VisualElement>("img").style.backgroundImage =  new StyleBackground(itemInf.itemSprite);
                        itemVisualElement.AddToClassList("item");
                            
                        // 親要素に追加
                        var scrollView = ve.Q<ScrollView>("ScrollView");
                        scrollView.contentContainer.Add(itemVisualElement);
                    }
                }
            }
        }
        
        public ItemsWrapperView()
        {
            var treeAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/_Projects/UI/UIDocuments/ItemsContainer.uxml");
            var container = treeAsset.Instantiate();
            hierarchy.Add(container);
            
            var scrollView = container.Q<ScrollView>();
            ItemsQuery = scrollView.Query<ItemView>();
        }
    }
}