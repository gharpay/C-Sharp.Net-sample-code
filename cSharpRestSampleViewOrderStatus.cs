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
	        request.Method = "GET";
	        request.ContentType = "application/xml";
	        // Add authentication to request 
	        request.Headers.Add("username:xxxx");
	        request.Headers.Add("password:xxxx");
	
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
