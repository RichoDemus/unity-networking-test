using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.Sockets;

public class StartupScript : MonoBehaviour {

	private WWW www;
	private bool printed = false;
	private StreamWriter clientStreamWriter;
	private StreamReader streamReader;

	private System.Threading.Thread m_Thread = null;

	// Use this for initialization
	void Start () {
		TcpClient tcpClient = new TcpClient();
        tcpClient.Connect("localhost", 1337);
        var networkStream = tcpClient.GetStream();

        clientStreamWriter = new  StreamWriter(networkStream);
        streamReader = new StreamReader(networkStream);

		 m_Thread = new System.Threading.Thread(Run);
		 m_Thread.Start();

        if(true)
        	return;



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

	private void Run() {
	while(true){
		Debug.Log(streamReader.ReadLine());
	}

	}

	// Update is called once per frame
	void Update () {
		clientStreamWriter.WriteLine("Hello There!");
		//var msg = await streamReader.ReadLineAsync();

		//Debug.Log(msg);
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
