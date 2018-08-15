﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

using TechTweaking.Bluetooth;

public class BasicDemo : MonoBehaviour {

	private  BluetoothDevice device;
	public Text statusText;

    public int time = 1500; //slow = 1500; normal = 1000; fast = 500

    //private AndroidJavaClass zowiClass = new AndroidJavaClass("com.unity3d.player.ZowiLib_");

    // Use this for initialization
    void Awake () {
		
		BluetoothAdapter.enableBluetooth();//Force Enabling Bluetooth


        device = new BluetoothDevice();
        if (BluetoothAdapter.isBluetoothEnabled())
        {
            connect();
        }
        else
        {
            BluetoothAdapter.enableBluetooth(); //you can by this force enabling Bluetooth without asking the user
            statusText.text = "Status : Please enable your Bluetooth";

            //BluetoothAdapter.OnBluetoothStateChanged += HandleOnBluetoothStateChanged;
            BluetoothAdapter.listenToBluetoothState(); // if you want to listen to the following two events  OnBluetoothOFF or OnBluetoothON

            BluetoothAdapter.askEnableBluetooth();//Ask user to enable Bluetooth
        }

        /*
		 * We need to identify the device either by its MAC Adress or Name (NOT BOTH! it will use only one of them to identefy your device).
		 *
		 *---------- MacAdress property
		 * Using the MAC adress is the best choice because the device doesn't have to be paired/bonded!
		 * 
		 * ----------Name property
		 * Identefy a device by its name using the Property 'BluetoothDevice.Name' require the remote device to be paired
		 * but you can try to alter the parameter 'allowDiscovery' of the Connect(int attempts, int time, bool allowDiscovery) method. 
		 * allowDiscovery will start a heavy discovery process (if the remote device weren't paired). This will take time 12 to 25 seconds.
		 * So it's better to use the 'BluetoothDevice.MacAdress' property. It doesn't need previuos pairing/bonding.
		 */


        //device.Name = "Zowi"; //"HC-06";
		//device.MacAddress = "XX:XX:XX:XX:XX:XX";

		/*
		 *  Note: The library will fill the properties device.Name and device.MacAdress with the right data after succesfully connecting.
		 * 
		 *  Moreover, any BluetoothDevice instance returned by a method or event of this library will have both properties (Name & MacAdress) filled with the right data
		 */


		//You might need th following:
		//this.device.UUID = UUID; //This is not required for HC-05/06 devices and many other electronic bluetooth modules.
		/*
		 * Quoting docs: A uuid is a Universally Unique Identifier (UUID) standardized 128-bit format for a string ID used to uniquely identify information. 
		 * It's used to uniquely identify your application's Bluetooth service.
		 * Check out getUUIDs(), if you don't know what UUID to use.
		 */
	}
	
	public void connect() {
		statusText.text = "Status : Searching...";

        device.Name = "Zowi"; //"HC-06";
		//device.MacAddress = "XX:XX:XX:XX:XX:XX";

		/*
		 * Notice that there're more than one connect() method, check out the docs to read about them.
		 * a simple device.connect() is equivalent to connect(3, 1000, false) which will make 3 connection attempts
		 * before failing completly, each attempt will cost at least 1 second = 1000 ms.
		 * -----------
		 * To alter that  check out the following methods in the docs :
		 * connect (int attempts, int time, bool allowDiscovery) 
		 * normal_connect (bool isBrutal, bool isSecure)
		 */
		device.connect();
	}

	public void disconnect() {
		device.close();
	}


    //Default position; call to end the current animation
    public void home()
    {

        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.MOVE_STOP_OPTION +
                        ZowiProtocol.FINAL);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }


    //Base Contols
    public void walk(int dir)//float steps, int time, int dir)
    {
        char direction; // = ZowiProtocol.MOVE_STOP_OPTION; ;

        if (dir == -1)
        {
            direction = ZowiProtocol.MOVE_WALK_BACKWARD_OPTION;
        }
        else
        {
            direction = ZowiProtocol.MOVE_WALK_FORWARD_OPTION;
        }

        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        direction +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.FINAL, time);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));
    }

    public void turn(int dir)//float steps, int time, int dir) 
    {
        char direction; //= ZowiProtocol.MOVE_STOP_OPTION;

        if (dir == -1)
        {
            direction = ZowiProtocol.MOVE_TURN_LEFT_OPTION;
        }
        else
        {
            direction = ZowiProtocol.MOVE_TURN_RIGHT_OPTION;
        }

        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        direction +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.FINAL, time);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }


    //Animations
    public void updown()// float steps, int time, int h) 
    {
        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.MOVE_UPDOWN_OPTION +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.SEPARATOR +
                        25 +
                        ZowiProtocol.FINAL, time, 25); //, h);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }

    public void moonwalker(int dir)//float steps, int time, int h, int dir) 
    {
        char direction; // = ZowiProtocol.MOVE_STOP_OPTION;

        if (dir == -1)
        {
            direction = ZowiProtocol.MOVE_MOONWALKER_LEFT_OPTION;
        }
        else
        {
            direction = ZowiProtocol.MOVE_MOONWALKER_RIGHT_OPTION;
        }

        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        direction +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.SEPARATOR +
                        26 +
                        ZowiProtocol.FINAL, time, 26); //, h);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }

    public void swing()//float steps, int time, int h) 
    {
        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.MOVE_SWING_OPTION +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.SEPARATOR +
                        25 +
                        ZowiProtocol.FINAL, time, 25);//, h);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }

    public void crusaito(int dir)//float steps, int time, int h, int dir) 
    {
        String direction; //.MOVE_CRUSAITO_RIGHT_OPTION;

        if (dir == -1)
        {
            direction = ZowiProtocol.MOVE_CRUSAITO_LEFT_OPTION;
        }
        else
        {
            direction = ZowiProtocol.MOVE_CRUSAITO_RIGHT_OPTION;
        }

        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        direction +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.SEPARATOR +
                        25 +
                        ZowiProtocol.FINAL, time, 25);//, h);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }

    public void jump()//float steps, int time) 
    {
        String command = String.Format(
                "" + ZowiProtocol.MOVE_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.MOVE_JUMP_OPTION +
                        ZowiProtocol.SEPARATOR +
                        time +
                        ZowiProtocol.FINAL, time);

        device.send(System.Text.Encoding.UTF8.GetBytes(command));
    }



//############### Reading Data  #####################
/* Please note that this way of reading is only used in this demo. All other demos use Coroutines(Unity offers many tutorials on Coroutines).
 * Just to make things simple
 */
void Update() {
		if (device.IsReading) {

			byte [] msg = device.read();

            statusText.text = "Status : Connected";

   //         if (msg != null ) {

   //             /* Send and read in this library use bytes. So you have to choose your own encoding.
			//	 * The reason is that different Systems (Android, Arduino for example) use different encoding.
			//	 */
   //             string content = System.Text.Encoding.UTF8.GetString(msg); //System.Text.ASCIIEncoding.ASCII.GetString (msg);


   //             statusText.text = "Status : " + content;

			//} 
		}
	}
}