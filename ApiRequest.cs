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

	private var client;

	public EfaApi() {
		client = new RestClient("http://app.vrr.de/msapp/XML_DM_REQUEST");
	}

	public string getClosestStop() {
		var request = new RestRequest("", Method.POST);
		request.AddParameter("name_dm", stopParameter.nameDm);
		request.AddParameter("type_dm", stopParameter.typeDm);
		request.AddParameter("coordOutputFormatTail", stopParameter.coordOutputFormatTail);
		request.AddParameter("outputFormat", stopParameter.outputFormat);
		request.AddParameter("coordOutputFormat", stopParameter.coordOutputFormat);

		client.Execute(request);
	}

}

var client = new RestClient("http://example.com");

var request = new RestRequest("resource/{id}", Method.POST);

request.AddUrlSegment("id", "123"); // replaces matching token in request.Resource

// execute the request and automatically deserialize result
// return content type is sniffed but can be explicitly set via RestClient.AddHandler();
RestResponse<Person> response = client.Execute<Person>(request);
