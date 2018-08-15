using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.IO.Ports;



public class SerialConnectionTest : MonoBehaviour {

 //   SerialPort stream = new SerialPort("COM4", 9600);
    
	//// Use this for initialization
	//void Start () {
 //       stream.ReadTimeout = 50;
 //       stream.Open();

 //       WriteToArduino("PING");

 //       StartCoroutine(AsynchronousReadFromArduino((string s) => Debug.Log(s), () => Debug.LogError("Error!"), 1000));
 //   }
	
	//// Update is called once per frame
	//void Update () {
		
	//}

 //   public void WriteToArduino(string message)
 //   {
 //       stream.WriteLine(message);
 //       stream.BaseStream.Flush();
 //   }

 //   public string ReadFromArduino(int timeout = 0)
 //   {
 //       stream.ReadTimeout = timeout;
 //       try
 //       {
 //           return stream.ReadLine();
 //       }
 //       catch (TimeoutException e)
 //       {
 //           return null;
 //       }
 //   }

 //   public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
 //   {
 //       DateTime initialTime = DateTime.Now;
 //       DateTime nowTime;
 //       TimeSpan diff = default(TimeSpan);

 //       string dataString = null;

 //       do
 //       {
 //           try
 //           {
 //               dataString = stream.ReadLine();
 //           }
 //           catch (TimeoutException)
 //           {
 //               dataString = null;
 //           }

 //           if (dataString != null)
 //           {
 //               callback(dataString);
 //               yield break; // Terminates the Coroutine
 //           }
 //           else
 //               yield return null; // Wait for next frame

 //           nowTime = DateTime.Now;
 //           diff = nowTime - initialTime;

 //       } while (diff.Milliseconds < timeout);

 //       if (fail != null)
 //           fail();
 //       yield return null;
 //   }
}
