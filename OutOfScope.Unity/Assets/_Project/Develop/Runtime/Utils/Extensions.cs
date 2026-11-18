using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Utils
{
    public static class Extensions
    {
        #region ListExt

        public static T GetRandomItem<T>(this IList<T> list) => list[Random.Range(0, list.Count)];

        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }

        public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;

        public static T First<T>(this List<T> list) => list[0];

        public static T Last<T>(this List<T> list) => list[^1];

        public static void Off(this List<GameObject> list)
        {
            foreach (GameObject obj in list)
                obj.SetActive(false);
        }

        public static void On(this List<GameObject> list)
        {
            foreach (GameObject obj in list)
                obj.SetActive(true);
        }

        public static int GetEqualsCount<T>(this List<T> list, T obj)
        {
            int index = 0;

            foreach (var item in list)
                if (item.Equals(obj))
                    index++;

            if (index > 0)
                return index;
             
            return -1;
        }

        public static void All<T>(this List<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
        }

        #endregion

        #region UIExt

        public static void RefreshLayout(this RectTransform transform, bool hard = false)
        {
            if (hard)
                LayoutRebuilder.ForceRebuildLayoutImmediate(transform);
            else
                LayoutRebuilder.MarkLayoutForRebuild(transform);
        }

        public static void SetColorAlpha(this MaskableGraphic targetGraphic, float newAlpha)
        {
            var backColor = targetGraphic.color;
            backColor.a = newAlpha;
            targetGraphic.color = backColor;
        }


        #endregion

        #region VectorExt
        public static Vector3 WithX(this Vector3 value, float x)
        {
            value.x = x;
            return value;
        }

        public static Vector3 WithY(this Vector3 value, float y)
        {
            value.y = y;
            return value;
        }

        public static Vector3 WithZ(this Vector3 value, float z)
        {
            value.z = z;
            return value;
        }

        public static Vector3 AddX(this Vector3 value, float x)
        {
            value.x += x;
            return value;
        }

        public static Vector3 AddY(this Vector3 value, float y)
        {
            value.y += y;
            return value;
        }

        public static Vector3 AddZ(this Vector3 value, float z)
        {
            value.z += z;
            return value;
        }

        public static Vector2 XZ(this Vector3 vector) => new Vector2(vector.x, vector.z);

        public static Vector3 X0Z(this Vector2 vector) => new Vector3(vector.x, 0, vector.y);

        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2
            {
                x = vector3.x,
                y = vector3.z
            };
        }

        public static Vector3 ToVector3(this Vector2 vector2, float y = 0)
        {
            return new Vector3
            {
                x = vector2.x,
                y = y,
                z = vector2.y
            };
        }

        public static Vector3Int FloorToVector3Int(this Vector3 vector)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(vector.x),
                y = Mathf.FloorToInt(vector.x),
                z = Mathf.FloorToInt(vector.x)
            };
        }
        public static Vector3Int FloorToVector3Int(this Vector3 vector, float offset)
        {
            return new Vector3Int
            {
                x = Mathf.FloorToInt(vector.x + offset),
                y = Mathf.FloorToInt(vector.y + offset),
                z = Mathf.FloorToInt(vector.z + offset),
            };
        }


        #endregion

        #region TransformExt

        public static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
                Object.Destroy(transform.GetChild(i).gameObject);
        }

        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static Vector3 ScreenToWorld(this Vector2 mousePosition, Vector3 offset = default)
        {
            Plane groundPlane = new Plane(Vector3.up, offset);
            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            
                groundPlane.Raycast(ray, out float distance);
            
                return ray.GetPoint(distance);
            }
            
            Debug.LogWarning("Main camera not found");
            return Vector3.zero;
        }

        #endregion

        #region Builder

        public static T With<T>(this T self, Action<T> set)
        {
            set.Invoke(self);
            
            return self;
        }

        public static T With<T>(this T self, Action<T> apply, Func<bool> when)
        {
            if (when())
            {
                apply(self);
            }

            return self;
        }

        public static T With<T>(this T self, Action<T> apply, bool when)
        {
            if (when)
            {
                apply(self);
            }

            return self;
        }

        #endregion
    }
}
