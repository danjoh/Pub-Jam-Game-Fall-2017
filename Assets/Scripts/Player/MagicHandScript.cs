using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandScript : MonoBehaviour {
	void OnGUI() {
        Vector3 p = new Vector3();
        Camera camera = Camera.main;
        Event e = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = e.mousePosition.x;
        mousePos.y = camera.pixelHeight - e.mousePosition.y;

        p = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));
        transform.position = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 150));
        GUILayout.Label("Screen pixels: " + camera.pixelWidth + ":" + camera.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + p.ToString("F3"));
        GUILayout.Label("Hand position: " + transform.position);
        GUILayout.EndArea();
    }
}
