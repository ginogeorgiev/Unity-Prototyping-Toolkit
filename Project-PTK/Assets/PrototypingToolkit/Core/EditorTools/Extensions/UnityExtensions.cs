using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace PrototypingToolkit.Core.Extensions
{
    public static class UnityExtensions
    {
        public static Vector2 SetX(this Vector2 vector, float x)
        {
            return new Vector2(x, vector.y);
        }
        
        public static Vector2 AddX(this Vector2 vector, float x)
        {
            return new Vector2(vector.x + x, vector.y);
        }
        
        public static Vector2 SetY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, y);
        }
        
        public static Vector2 AddY(this Vector2 vector, float y)
        {
            return new Vector2(vector.x, vector.y + y);
        }
        
        public static Vector2 GetClosestVector2From(this Vector2 vector, Vector2[] otherVectors)
        {
            if (otherVectors.Length == 0) throw new Exception("The list of other vectors is empty");
            var minDistance = Vector2.Distance(vector, otherVectors[0]);
            var minVector = otherVectors[0];
            for (var i = otherVectors.Length - 1; i > 0; i--)
            {
                var newDistance = Vector2.Distance(vector, otherVectors[i]);
                if (newDistance < minDistance)
                {
                    minDistance = newDistance;
                    minVector = otherVectors[i];
                }
            }
            return minVector;
        }
        
        // -------------------------------------------------------

        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector3 ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, 0, vector.y);
        }
        
        // -------------------------------------------------------

        public static Vector3 SetX(this Vector3 vector, float x)
        {
            return new Vector3(x, vector.y, vector.z);
        }
        
        public static Vector3 AddX(this Vector3 vector, float x)
        {
            return new Vector3(vector.x + x, vector.y, vector.z);
        }
        
        public static Vector3 SetY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }
        
        public static Vector3 AddY(this Vector3 vector, float y)
        {
            return new Vector3(vector.x, vector.y + y, vector.z);
        }
        
        public static Vector3 SetZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, z);
        }
        
        public static Vector3 AddZ(this Vector3 vector, float z)
        {
            return new Vector3(vector.x, vector.y, vector.z + z);
        }
        
        // -------------------------------------------------------
        
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            var component = gameObject.GetComponent<T>();
            if (component == null) gameObject.AddComponent<T>();
            return component;
        }
        
        public static bool HasComponent<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            return gameObject.GetComponent<T>() != null;
        }
        
        // -------------------------------------------------------
        
        public static T GetRandomItem<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
        
        public static void Shuffle<T>(this IList<T> list)
        {
            for (var i = list.Count - 1; i > 1; i--)
            {
                var j = Random.Range(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]);
            }
        }
        
        // -------------------------------------------------------
        
        public static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        public static void ResetTransformation(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        
        // -------------------------------------------------------
        
        public static void ChangeDirection(this Rigidbody rb, Vector3 direction)
        {
            rb.velocity = direction.normalized * rb.velocity.magnitude;
        }
        
        public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
        {
            rb.velocity = rb.velocity.normalized * magnitude;
        }
    }
}
