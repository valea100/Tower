using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyUtilities
{
    public static class MyUtils {

        public const int sortingOrderDefault = 5000;
        // Create Text in the World
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
        {
            if (color == null) color = Color.white;
                return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
            {
                GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
                Transform transform = gameObject.transform;
                transform.SetParent(parent, false);
                transform.localPosition = localPosition;
                TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                textMesh.anchor = textAnchor;
                textMesh.alignment = textAlignment;
                textMesh.text = text;
                textMesh.fontSize = fontSize;
                textMesh.color = color;
                textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
                return textMesh;
            }



        //mouse pozice
        public static Vector3 GetMousePosition()
            {
                Vector3 vector = GetMousePositionWithZ(Input.mousePosition, Camera.main);
                vector.z = 0f;
                return vector;
            }
        public static Vector3 GetMousePositionWithZ()
            {
                return GetMousePositionWithZ(Input.mousePosition, Camera.main);
            }
        public static Vector3 GetMousePositionWithZ(Camera worldCamera)
            {
                return GetMousePositionWithZ(Input.mousePosition, worldCamera);
            }
        public static Vector3 GetMousePositionWithZ(Vector3 screenPosition, Camera worldCamera)
            {
                Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
                return worldPosition;
            }

    }


}
