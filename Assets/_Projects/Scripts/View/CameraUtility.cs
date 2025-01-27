using UnityEngine;

namespace DefaultNamespace
{
    public static class CameraUtility
    {
        public static void LimitMovementRange(Transform transform,float minX,float maxX,float minY,float maxY)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minX, maxX),
                Mathf.Clamp(transform.position.y, minY, maxY),
                transform.position.z
            );
        }
    }
}