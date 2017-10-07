using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHandScript : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    void OnGUI() {
        Vector3 p = new Vector3();
        Camera camera = Camera.main;
        Event e = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = e.mousePosition.x;
        mousePos.y = camera.pixelHeight - e.mousePosition.y;

        p = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));
 
        
        float posX = Mathf.SmoothDamp(transform.position.x, p.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, p.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, camera.nearClipPlane);

        GUILayout.BeginArea(new Rect(20, 20, 250, 150));
        GUILayout.Label("Screen pixels: " + camera.pixelWidth + ":" + camera.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + p.ToString("F3"));
        GUILayout.Label("Hand position: " + transform.position);
        GUILayout.EndArea();
    }

}
