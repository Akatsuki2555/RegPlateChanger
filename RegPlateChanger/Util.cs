using UnityEngine;

namespace RegPlateChanger
{
    public static class Util
    {
        private static Transform C(this Transform t, int i)
        {
            return t.GetChild(i);
        }

        public static GameObject C(this GameObject go , int i)
        {
            return go.transform.C(i).gameObject;
        }
    }
}