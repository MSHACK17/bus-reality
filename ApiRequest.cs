using RestSharp;
using RestSharp.Authenticators;

class StopParameter {
	public string nameDm = "7.637305:51.951101:WGS84[DD.DDDDD]";
	public string typeDm = "coord";
	public string coordOutputFormatTail = "5";
	public string outputFormat = "JSON";
	public string coordOutputFormat = "WGS84[DD.DDDDD]";
}

class DisplayParameter {
	public string changeSpeed = "normal";
    public string nameDm = "7.637305:51.951101:WGS84[DD.DDDDD]";
	public string typeDm = "coord";
	public string useRealtime = "1"
	public string coordListOutputFormat = "STRING";
	public string canChangeMOT = "0";
	public string sessionID = "0";
	public string itOptionsActive = "1";
    public string coordOutputFormatTail = "5";
    public string mode = "direct";
    public string useAllStops = "1";
    public string imparedOptionsActive = "1";
    public string maxTimeLoop = "1";
    public string includeCompleteStopSeq = "1";
    public string useProxFootSearch = "1";
    public string stateless = "1";
    public string outputFormat = "JSON";
    public string excludedMeans = "checkbox";
    public string mergeDep = "1";
    public string lineRestriction = "400";
    public string depType = "stopEvents";
    //public string ptOptionsActive = "1";
    public string trlTMOTvalue100 = "15";
    public string coordOutputFormat = "WGS84[DD.DDDDD]";
    public string locationServerActive = "1";
}

class EfaApi {

	public string getClosestStop() {
		using (var webClient = new System.Net.WebClient()) {

			webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
    		string HtmlResult = wc.UploadString(URI, myParameters);

    		// Define parameters
    		var request_param = new System.Collections.Specialized.NameValueCollection();
		    reqparm.Add("name_dm", stopParameter.nameDm);
		    reqparm.Add("type_dm", stopParameter.typeDm);
		    reqparm.Add("coordOutputFormatTail", stopParameter.coordOutputFormatTail);
		    reqparm.Add("outputFormat", stopParameter.outputFormat);
		    reqparm.Add("coordOutputFormat", stopParameter.coordOutputFormat);

		    // Request
		    byte[] responsebytes = webClient.UploadValues("http://app.vrr.de/msapp/XML_DM_REQUEST", "POST", request_param);
		    string responsebody = Encoding.UTF8.GetString(responsebytes);

		    JObject json = JObject.Parse(responsebody);

		    Console.WriteLine(responsebody);

		    // var stop_id = 

		    // Define the second parameters
    		var request_param_2 = new System.Collections.Specialized.NameValueCollection();
		    reqparm.Add("name_dm", stop_id);
		    reqparm.Add("type_dm", "any");
		    reqparm.Add("coordOutputFormatTail", stopParameter.coordOutputFormatTail);
		    reqparm.Add("outputFormat", stopParameter.outputFormat);
		    reqparm.Add("coordOutputFormat", stopParameter.coordOutputFormat);
		    reqparm.Add("changeSpeed",normal ;
		    reqparm.Add("nameDm",7.637305:51.951101:WGS84[DD.DDDDD];
			reqparm.Add("typeDm",coord;
			reqparm.Add("useRealtime",1
			reqparm.Add("coordListOutputFormat",STRING;
			reqparm.Add("canChangeMOT",0;
			reqparm.Add("sessionID",0;
			reqparm.Add("itOptionsActive",1;
		    reqparm.Add("coordOutputFormatTail",5;
		    reqparm.Add("mode",direct;
		    reqparm.Add("useAllStops",1;
		    reqparm.Add("imparedOptionsActive",1;
		    reqparm.Add("maxTimeLoop",1;
		    reqparm.Add("includeCompleteStopSeq",1;
		    reqparm.Add("useProxFootSearch",1;
		    reqparm.Add("stateless",1;
		    reqparm.Add("outputFormat",JSON;
		    reqparm.Add("excludedMeans",checkbox;
		    reqparm.Add("mergeDep",1;
		    reqparm.Add("lineRestriction",400;
		    reqparm.Add("depType",stopEvents;
		    //reqparm.Add("ptOptionsActive",1;
		    reqparm.Add("trlTMOTvalue100",15;
		    reqparm.Add("coordOutputFormat",WGS84[DD.DDDDD];
		    reqparm.Add("locationServerActive",1;
		    
		    //Second request
		    webClient.UploadValues("http://app.vrr.de/msapp/XML_DM_REQUEST", "POST", request_param_2);



			var json = webClient.DownloadString("http://app.vrr.de/msapp/XML_DM_REQUEST");

			Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(json);

			var stops = json["dm"][|"itdOdvAssignedStops"]

			client.Execute(request);
		}
	}

}

var client = new RestClient("http://example.com");

var request = new RestRequest("resource/{id}", Method.POST);

request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

// execute the request and automatically deserialize result
// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
RestResponse<Person> response = client.Execute<Person>(request);
