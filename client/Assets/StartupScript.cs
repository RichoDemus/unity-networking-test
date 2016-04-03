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
	//Start a simple nginx backend with docker run -p nginx:latest
	Debug.Log("Start");
	    var url = "http://localhost:32769/";

		var form = new WWWForm();
//		form.AddField("Username", USERNAME);
//		form.AddField("Password", PASSWORD);




		www = new WWW(url);
		//yield return www;





		/*if(www.error)
		{
             print("There was an error posting the high score: " + www.error);
             state = LoginState.loginFailed;
         }
         else
         {
             print(www.text);
             if(www.text[0] == "&lt;")
             {
                 state = LoginState.timedOut;
             }
             else
             {
                 state = LoginState.loginSuccess;
             }
         }*/



/*		Debug.Log("Hello World!");
		NetworkTransport.Init();

		ConnectionConfig config = new ConnectionConfig();


		//int myReiliableChannelId  = config.AddChannel(QosType.Reliable);
		int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);

		HostTopology topology = new HostTopology(config, 10);

		int hostId2 = NetworkTransport.AddWebsocketHost(topology, 8887, null);
		int hostId = NetworkTransport.AddHost(topology, 8888);

		byte error;
		int connectionId = NetworkTransport.Connect(hostId, "172.17.0.2", 5005, 0, out error);

		//NetworkTransport.Send(hostId, connectionId, myReiliableChannelId, buffer, bufferLength,  out error);

  byte[] buffer = new byte[1024];
  Stream stream = new MemoryStream(buffer);
  BinaryFormatter formatter = new BinaryFormatter();
  formatter.Serialize(stream, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");

  int bufferSize = 1024;

  NetworkTransport.Send(hostId, connectionId, myUnreliableChannelId, buffer, bufferSize, out error);*/



	}

	// Update is called once per frame
	void Update () {
		if(www.isDone && !printed)
		{
			Debug.Log(www.text);
			printed = true;
		}
	}
}
