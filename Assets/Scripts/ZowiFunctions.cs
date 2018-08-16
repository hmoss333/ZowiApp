using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

using TechTweaking.Bluetooth;

public class ZowiFunctions : MonoBehaviour {

    public BluetoothDevice device;
    ZowiFunctions zowiFunctions;

    public int time = 1500; //slow = 1500; normal = 1000; fast = 500

    private void Awake()
    {
        device = new BluetoothDevice();
        zowiFunctions = this;
    }

    public void connect()
    {
        //statusText.text = "Status : Searching...";

        zowiFunctions.device.Name = "Zowi"; //"HC-06";
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
        zowiFunctions.device.connect();
    }

    public void disconnect()
    {
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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }


    //############### Movement Commands #################//
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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));
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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

    }

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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));

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

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));
    }



    //############### Gesture Commands #################//

    public void testCommand()
    {
        //String command = String.Format(
        //        "" + ZowiProtocol.GESTURE_COMMAND +
        //                ZowiProtocol.SEPARATOR +
        //                ZowiProtocol.GESTURE_HAPPY +
        //                ZowiProtocol.SEPARATOR +
        //                ZowiProtocol.FINAL);

        //device.send(System.Text.Encoding.UTF8.GetBytes(command));
        testSound();
        jump();
        swing();
        testSound();
    }



    //############### Gesture Commands #################//

    public void testSound()
    {
        String command = String.Format(
                "" + ZowiProtocol.SING_COMMAND +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.SING_OhOoh_2 +
                        ZowiProtocol.SEPARATOR +
                        ZowiProtocol.FINAL);

        zowiFunctions.device.send(System.Text.Encoding.UTF8.GetBytes(command));
    }
}
