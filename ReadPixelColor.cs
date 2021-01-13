using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ReadPixelColor : MonoBehaviour {
        private Color pixelsColor;
        private Texture2D m_texture;
        private Camera _camera;
        // Use this for initialization
        void Start () {
            _camera = GetComponent<Camera> (); //获取场景中摄像机对象的组件接口 
            m_texture = new Texture2D (Screen.width, Screen.height, TextureFormat.RGB24, false);
        }
        // Update is called once per frame
        void Update () {
            
        }
        void OnGUI () {
            CaptureScreenshot ();
            GUIStyle myStyle = new GUIStyle();
            myStyle.fontSize = 40;
            myStyle.normal.textColor = Color.white;
            GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y, 300, 20), pixelsColor.ToString(),myStyle);
            GUI.Label (new Rect (Input.mousePosition.x, Screen.height - Input.mousePosition.y-40, 300, 20), new Vector3(pixelsColor.r*255,pixelsColor.g*255,pixelsColor.b*255).ToString(),myStyle);
        }
        void CaptureScreenshot () {
            // 读取Rect范围内的像素并存入纹理中
            m_texture.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
            // 实际应用纹理
            m_texture.Apply ();

            Color color = m_texture.GetPixel ((int) Input.mousePosition.x, (int) Input.mousePosition.y);
            pixelsColor = color;
        }


}