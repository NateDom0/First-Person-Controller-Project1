using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    //Referenced lecture and code on Event Mechanism 

    //Private variables
	//------------------------------------------------
	//Internal reference to all listeners for notifications
	private Dictionary<string, List<Component>> Listeners = new Dictionary<string, List<Component>>();


    //Methods
	//------------------------------------------------
	//Function to add a listener for an notification to the listeners list
	public void AddListener(Component Sender, string NotificationName)
	{
		//Add listener to dictionary
		if(!Listeners.ContainsKey(NotificationName))
			Listeners.Add (NotificationName, new List<Component>());
		
		//Add object to listener list for this notification
		Listeners[NotificationName].Add(Sender);
	}

    //------------------------------------------------
	//Function to post a notification to a listener
	public void PostNotification(Component Sender, string NotificationName)
	{
		//If no key in dictionary exists, then exit
		if(!Listeners.ContainsKey(NotificationName))
			return;
		
		//Else post notification to all matching listeners
		foreach(Component Listener in Listeners[NotificationName])
			Listener.SendMessage(NotificationName, Sender, SendMessageOptions.DontRequireReceiver);
	}
}
