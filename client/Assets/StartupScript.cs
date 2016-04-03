using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class StartupScript : MonoBehaviour {

	private WWW www;
	private bool printed = false;

	// Use this for initialization
	void Start () {
		//Start the java backend and access HelloWorldResource
		Debug.Log("Start");
	    //var url = "http://localhost:8080/hello-world";
	    //var url = "https://richodemus.com/index.html";
	    var url = "http://localhost:8080/api/hello-world?name=richo";

		var form = new WWWForm();
		form.AddField("key", "val");

		//www = new WWW(url, form);
		www = new WWW(url);

	}

	// Update is called once per frame
	void Update () {
		if(www != null && www.isDone && !printed)
		{
			if (!string.IsNullOrEmpty(www.error))
				Debug.Log("Error: " + www.error);
			else
				Debug.Log("Received data: " + www.text);
			printed = true;
		}
	}
}
