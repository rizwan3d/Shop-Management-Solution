using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Shop_Management_Solution.lib.util
{
    class NetworkUtil
    {
        public static String generatePostCall(String URL, String data)
        {
            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create( URL );
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public static string getIPAddresses()
        {


            StringBuilder sb = new StringBuilder();
            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)      
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {

                if (network.OperationalStatus == OperationalStatus.Up)
                {
                    if (network.NetworkInterfaceType == NetworkInterfaceType.Tunnel) continue;
                    //GatewayIPAddressInformationCollection GATE = network.GetIPProperties().GatewayAddresses; 
                    // Read the IP configuration for each network    

                    IPInterfaceProperties properties = network.GetIPProperties();
                    //discard those who do not have a real gateaway  
                    if (properties.GatewayAddresses.Count > 0)
                    {
                        bool good = false;
                        foreach (GatewayIPAddressInformation gInfo in properties.GatewayAddresses)
                        {
                            //not a true gateaway (VmWare Lan) 
                            if (!gInfo.Address.ToString().Equals("0.0.0.0"))
                            {
                                //sb.AppendLine(" GATEAWAY " + gInfo.Address.ToString());
                                good = true;
                                break;
                            }
                        }
                        if (!good)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                    // Each network interface may have multiple IP addresses        
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // We're only interested in IPv4 addresses for now        
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork) continue;

                        // Ignore loopback addresses (e.g., 127.0.0.1)     
                        if (IPAddress.IsLoopback(address.Address)) continue;

                        if (!address.IsDnsEligible) continue;
                        if (address.IsTransient) continue;
                        sb.AppendLine(address.Address.ToString());
                        //sb.AppendLine(address.Address.ToString() + " (" + network.Name + ") nType:" + network.NetworkInterfaceType.ToString());
                    }
                }
            }
            return sb.ToString();
            //Console.WriteLine(sb.ToString());
        }

        public static String getMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }

        public static bool isNetworkAvailable()
        {
            //long minimumSpeed
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                {
                    continue;
                }
                    

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                //if (ni.Speed < minimumSpeed)
                    //continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    continue;
                }
                    

                return true;
            }
            return false;
        }


    }
}
