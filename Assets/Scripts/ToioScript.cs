using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using toio;
using UnityEngine.UI;
using TMPro;

public class ToioScript : MonoBehaviour
{

    public ConnectType connectType;
    private CubeManager cm;

    //UDP Variables
    public TMP_InputField udpDestAddr; public TMP_InputField udpDestPort; public TextMeshProUGUI udpPlaceholder; private UdpClient udpClient;
    //private int remotePort;

    //All Cubes Stored Here
    public Cube cube1, cube2, cube3, cube4, cube5;

    //Connection Icons
    public GameObject connection1, connection2, connection3, connection4, connection5;

    //Color Indicators
    public Image color1, color2, color3, color4, color5;

    //Toio MAC Addresses
    public TextMeshProUGUI ToioADDR1, ToioADDR2, ToioADDR3, ToioADDR4, ToioADDR5;

    //Toio Positions
    public TextMeshProUGUI pos1, pos2, pos3, pos4, pos5, bat1, bat2, bat3, bat4, bat5;

    //Toio Initiate Connection Buttons
    public GameObject Button1, Button2, Button3, Button4, Button5;

    // Start is called before the first frame update
    void Start()
    {
        cm = new CubeManager(connectType);
        udpClient = new UdpClient();
        //remotePort = 8889;
    }

    // Update is called once per frame
    void Update()
    {
        //Update Texts
        string message = "";
        if(cube1 != null) {
            string position = "x" + ((int) cube1.pos.x).ToString() + " y" + ((int) cube1.pos.y).ToString() + " r" + cube1.angle.ToString();
            string batt = cube1.battery.ToString() + "%";
            pos1.text = position;
            bat1.text = batt;
            string btn = cube1.isPressed.ToString();
            message += "Cube 1: " + position + " Battery: " + batt + " Button: " + btn + "; ";
        }

        if(cube2 != null) {
            string position = "x" + ((int) cube2.pos.x).ToString() + " y" + ((int) cube2.pos.y).ToString() + " r" + cube2.angle.ToString();
            string batt = cube2.battery.ToString() + "%";
            pos2.text = position;
            bat2.text = batt;
            string btn = cube2.isPressed.ToString();
            message += "Cube 2: " + position + " Battery: " + batt + " Button: " + btn + "; ";
        }

        if(cube3 != null) {
            string position = "x" + ((int) cube3.pos.x).ToString() + " y" + ((int) cube3.pos.y).ToString() + " r" + cube3.angle.ToString();
            string batt = cube3.battery.ToString() + "%";
            pos3.text = position;
            bat3.text = batt;
            string btn = cube3.isPressed.ToString();
            message += "Cube 3: " + position + " Battery: " + batt + " Button: " + btn + "; ";
        }

        if(cube4 != null) {
            string position = "x" + ((int) cube4.pos.x).ToString() + " y" + ((int) cube4.pos.y).ToString() + " r" + cube4.angle.ToString();
            string batt = cube4.battery.ToString() + "%";
            pos4.text = position; 
            bat4.text = batt;
            string btn = cube4.isPressed.ToString();
            message += "Cube 4: " + position + " Battery: " + batt + " Button: " + btn + "; ";
        }

        if(cube5 != null) {
            string position = "x" + ((int) cube5.pos.x).ToString() + " y" + ((int) cube5.pos.y).ToString() + " r" + cube5.angle.ToString();
            string batt = cube5.battery.ToString() + "%";
            pos5.text = position;
            bat5.text = batt;
            string btn = cube5.isPressed.ToString();
            message += "Cube 5: " + position + " Battery: " + batt + " Button: " + btn + "; ";
        }

        //Early return
        if(message == "") return;

        //Button?
        //cube1.angle.;

        //Send UDP Locations
        if(udpDestAddr.text != "" && udpDestPort.text != ""){
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.Send(data, data.Length, udpDestAddr.text, int.Parse(udpDestPort.text));
        }
    }

    void OnDisable()
    {
        udpClient.Close();
    }

    async public void connect1(){
        cube1 = await cm.SingleConnect();
        if(cube1.isConnected){
            connection1.SetActive(false);
            Button1.SetActive(false);
            ToioADDR1.text = cube1.addr;
        }
    }

    async public void connect2(){
        cube2 = await cm.SingleConnect();
        if(cube2.isConnected){
            connection2.SetActive(false);
            Button2.SetActive(false);
            ToioADDR2.text = cube2.addr;
        }
    }

    async public void connect3(){
        cube3 = await cm.SingleConnect();
        if(cube3.isConnected){
            connection3.SetActive(false);
            Button3.SetActive(false);
            ToioADDR3.text = cube3.addr;
        }
    }

    async public void connect4(){
        cube4 = await cm.SingleConnect();
        if(cube4.isConnected){
            connection4.SetActive(false);
            Button4.SetActive(false);
            ToioADDR4.text = cube4.addr;
        }
    }

    async public void connect5(){
        cube5 = await cm.SingleConnect();
        if(cube5.isConnected){
            connection5.SetActive(false);
            Button5.SetActive(false);
            ToioADDR5.text = cube5.addr;
        }
    }

    public void color(int num, int r, int g, int b, int dur){
        switch(num){
            case 1: if (cube1 != null) cube1.TurnLedOn(r, g, b, dur); color1.color = new Color(r/255f, g/255f, b/255f); break;
            case 2: if (cube2 != null) cube2.TurnLedOn(r, g, b, dur); color2.color = new Color(r/255f, g/255f, b/255f); break;
            case 3: if (cube3 != null) cube3.TurnLedOn(r, g, b, dur); color3.color = new Color(r/255f, g/255f, b/255f); break;
            case 4: if (cube4 != null) cube4.TurnLedOn(r, g, b, dur); color4.color = new Color(r/255f, g/255f, b/255f); break;
            case 5: if (cube5 != null) cube5.TurnLedOn(r, g, b, dur); color5.color = new Color(r/255f, g/255f, b/255f); break;
        }
    }

    public void motor(int num, int left, int right, int dur){
        switch(num){
            case 1: if (cube1 != null) cube1.Move(left, right, dur); break;
            case 2: if (cube2 != null) cube2.Move(left, right, dur); break;
            case 3: if (cube3 != null) cube3.Move(left, right, dur); break;
            case 4: if (cube4 != null) cube4.Move(left, right, dur); break;
            case 5: if (cube5 != null) cube5.Move(left, right, dur); break;
        }
    }

    public void moveType0(int num, int x, int y, int speed){ //Without angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
        }
    }

    public void moveType0(int num, int x, int y, int speed, int finalAngle){ //With angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RotatingMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
        }
    }

    public void moveType1(int num, int x, int y, int speed){ //Without angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
        }
    }

    public void moveType1(int num, int x, int y, int speed, int finalAngle){ //With angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundForwardMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
        }
    }

    public void moveType2(int num, int x, int y, int speed){ //Without angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle:0, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.NotRotate); break;
        }
    }

    public void moveType2(int num, int x, int y, int speed, int finalAngle){ //With angle
        switch(num){
            case 1: if (cube1 != null) cube1.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 2: if (cube2 != null) cube2.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 3: if (cube3 != null) cube3.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 4: if (cube4 != null) cube4.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
            case 5: if (cube5 != null) cube5.TargetMove(x, y, targetAngle: finalAngle, targetMoveType: Cube.TargetMoveType.RoundBeforeMove, maxSpd: speed, targetRotationType: Cube.TargetRotationType.Original); break;
        }
    }

}
