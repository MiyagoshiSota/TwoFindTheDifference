using UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemVisible
    {
        public void Visible(ItemModel item)
        {
            GameObject.Find(item.ItemName).GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}