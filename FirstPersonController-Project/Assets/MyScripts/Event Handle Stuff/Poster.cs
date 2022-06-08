using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    public NotificationManager manager = null;
    public Transform obj1 = null;
    public Transform obj2 = null;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(obj1.position, obj2.position);
        if(dist < 5 && manager != null)
            manager.PostNotification(this, "Touch");
        if(Input.GetButtonDown("Fire1") && manager !=null)
            manager.PostNotification(this, "Fire");

    }
}
