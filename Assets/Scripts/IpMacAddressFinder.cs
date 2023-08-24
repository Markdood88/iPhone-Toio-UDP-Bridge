using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine.UI;
using TMPro;

public class IpMacAddressFinder : MonoBehaviour
{

    public TextMeshProUGUI ipTextMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ipTextMesh.text = "Local IP: \n" + GetLocalIPv4();
    }

    public string GetLocalIPv4()
    {
        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");

        //System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

    }

}
