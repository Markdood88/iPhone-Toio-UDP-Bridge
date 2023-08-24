using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;

public class UDPReceiver : MonoBehaviour
{
    public ToioScript toioManager;
    public TextMeshProUGUI udpMsg;
    private UdpClient udpClient;
    private IPEndPoint endPoint;
    // Start is called before the first frame update
    private void Start()
    {
        udpClient = new UdpClient(22222); // Replace 22222 with your desired port number
        endPoint = new IPEndPoint(IPAddress.Any, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (udpClient.Available > 0)
        {
            byte[] receivedBytes = udpClient.Receive(ref endPoint);
            string receivedString = Encoding.ASCII.GetString(receivedBytes);
            udpMsg.text = receivedString;

            // Do something with the received string here
            // Debug.Log("Received: " + receivedString);
            string[] split_msg = receivedString.Split(' ');
            int length = int.Parse(split_msg[1]);
            
            switch(split_msg[0]){
                case "color": //color 2 1 255 255 255 2 255 255 255 1
                    for (int j = 0; j < length; j++){
                        toioManager.color(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]), int.Parse(split_msg[4*length + 2]));
                    }  
                    break;

                case "motor": //motor 2 1 50 -50 2 10 10 1
                    for (int j = 0; j < length; j++){
                        toioManager.motor(int.Parse(split_msg[3*j+2]), int.Parse(split_msg[3*j+3]), int.Parse(split_msg[3*j+4]), int.Parse(split_msg[3*length + 2]));
                    }
                    break;

                case "move00": //move00 1 1 200 400 50
                    for (int j = 0; j < length; j++){
                        toioManager.moveType0(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
                    }
                    break;

                case "move01": //move01 1 1 200 400 50 360
                    for (int j = 0; j < length; j++){
                        toioManager.moveType0(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
                    }
                    break;

                case "move10": //move10 1 1 200 400 50
                    for (int j = 0; j < length; j++){
                        toioManager.moveType1(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
                    }
                    break;

                case "move11": //move11 1 1 200 400 50 360
                    for (int j = 0; j < length; j++){
                        toioManager.moveType1(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
                    }
                    break;

                case "move20": //move20 1 1 200 400 50
                    for (int j = 0; j < length; j++){
                        toioManager.moveType2(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
                    }
                    break;

                case "move21": //move21 1 1 200 400 50 360
                    for (int j = 0; j < length; j++){
                        toioManager.moveType2(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
                    }
                    break;
            }

            // if(split_msg[0] == "color"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.color(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]), int.Parse(split_msg[4*length + 2]));
            //     }
            // }

            // else if(split_msg[0] == "motor"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.motor(int.Parse(split_msg[3*j+2]), int.Parse(split_msg[3*j+3]), int.Parse(split_msg[3*j+4]), int.Parse(split_msg[3*length + 2]));
            //     }
            // }
            
            // else if(split_msg[0] == "move00"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType0(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
            //     }
            // }

            // else if(split_msg[0] == "move01"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType0(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
            //     }
            // }

            // else if(split_msg[0] == "move10"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType1(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
            //     }
            // }

            // else if(split_msg[0] == "move11"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType1(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
            //     }
            // }

            // else if(split_msg[0] == "move20"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType2(int.Parse(split_msg[4*j+2]), int.Parse(split_msg[4*j+3]), int.Parse(split_msg[4*j+4]), int.Parse(split_msg[4*j+5]));
            //     }
            // }

            // else if(split_msg[0] == "move21"){
            //     int length = int.Parse(split_msg[1]);
            //     for (int j = 0; j < length; j++){
            //         toioManager.moveType2(int.Parse(split_msg[5*j+2]), int.Parse(split_msg[5*j+3]), int.Parse(split_msg[5*j+4]), int.Parse(split_msg[5*j+5]), int.Parse(split_msg[5*j+6]));
            //     }
            // }

        }
    }

    private void OnApplicationQuit()
    {
        udpClient.Close();
    }
}
