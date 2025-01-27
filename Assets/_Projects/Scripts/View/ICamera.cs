using UnityEngine;

public interface ICamera
{
    /// <summary>
    /// 移動をさせる関数
    /// </summary>
    void MoveCamera(Vector2 amount);
}