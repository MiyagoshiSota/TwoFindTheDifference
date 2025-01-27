using UnityEditor;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace UI
{
    public class ItemModel
    {
        public string ItemName { get; set; }
        public bool IsSelected { get; set; }
        public Vector2 Position { get; set; }
        public ItemView ItemView { get; set; }
    }
}