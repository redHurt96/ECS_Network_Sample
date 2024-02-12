using UnityEngine;

namespace _Project.Logic.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ToUnity(this System.Numerics.Vector3 origin) =>
            new(origin.X, origin.Y, origin.Z);

        public static System.Numerics.Vector3 ToSystem(this Vector3 origin) =>
            new(origin.x, origin.y, origin.z);
    }
}
