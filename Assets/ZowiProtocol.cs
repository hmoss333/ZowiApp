using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZowiProtocol : MonoBehaviour {
    public static char SEPARATOR = ' ';
    public static string FINAL = "\n\r";

    public static char MOVE_COMMAND = 'M';
    public static char MOVE_STOP_OPTION = '0';
    public static char MOVE_WALK_FORWARD_OPTION = '1';
    public static char MOVE_WALK_BACKWARD_OPTION = '2';
    public static char MOVE_TURN_LEFT_OPTION = '3';
    public static char MOVE_TURN_RIGHT_OPTION = '4';
    public static char MOVE_UPDOWN_OPTION = '5';
    public static char MOVE_MOONWALKER_LEFT_OPTION = '6';
    public static char MOVE_MOONWALKER_RIGHT_OPTION = '7';
    public static char MOVE_SWING_OPTION = '8';
    public static string MOVE_CRUSAITO_LEFT_OPTION = "9";
    public static string MOVE_CRUSAITO_RIGHT_OPTION = "10";
    public static string MOVE_JUMP_OPTION = "11";

    public static char ACK_COMMAND = 'A';
    public static char FINAL_ACK_COMMAND = 'F';

    public static char BATTERY_COMMAND = 'B';
    public static char PROGRAMID_COMMAND = 'I';
}
