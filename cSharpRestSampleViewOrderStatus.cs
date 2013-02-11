using System;
using System.Net;
using System.Text;
using System.IO;

namespace soapTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			sendRequest();
		}
		
		public static void sendRequest() {
			Uri address = new Uri("http://services.gharpay.in/rest/GharpayService/viewOrderStatus?orderID=GW-XXX-XXXXXX-XXX");
	        // Create the web request  
	        WebRequest request = WebRequest.Create(address) as WebRequest;
	        // Set type to POST  
	        request.Method = "POST";
	        request.ContentType = "application/xml";
	        // Add authentication to request 
	        request.Headers.Add("username:xxxx");
	        request.Headers.Add("password:xxxx");
	
	
	        // Create the data we want to send  
	        string data = @"<?xml version='1.0' encoding='UTF-8' standalone='yes'?><transaction><customerDetails><address>Santosh Kumar 50 D E-4 Noida</address><contactNo>9717012345</contactNo><firstName>test</firstName><lastName>sanosh</lastName><email>arpit@gharpay.in</email></customerDetails><orderDetails><pincode>400057</pincode><clientOrderID>610</clientOrderID><deliveryDate>18-01-2012</deliveryDate><orderAmount>1699</orderAmount><productDetails><productID>2683</productID><productQuantity>1</productQuantity><unitCost>1699</unitCost></productDetails></orderDetails><additionalInformation><parameters><name>InvoiceURL</name><value></value></parameters></additionalInformation></transaction>";        
	
	        // Create a byte array of the data we want to send  
	        //byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
	        byte[] byteData = Encoding.UTF8.GetBytes(data);
	        // Set the content length in the request headers  
	        request.ContentLength = byteData.Length;
	
	        // Write data  
	        Stream postStream = request.GetRequestStream();
	        {
	            postStream.Write(byteData, 0, byteData.Length);
	        }
	
	        // Get response  
	        try {
	        	HttpWebResponse response = (HttpWebResponse)request.GetResponse();
	        	Stream dataStream = response.GetResponseStream();
	                  
            	StreamReader reader = new StreamReader (dataStream);           
            	string responseFromServer = reader.ReadToEnd (); 
				Console.WriteLine(responseFromServer);
            	//Response.Write(responseFromServer);            
            	reader.Close ();
            	dataStream.Close ();
			}
			catch(Exception e) {
				Console.WriteLine(e.ToString());
			}
		}
	}
}
