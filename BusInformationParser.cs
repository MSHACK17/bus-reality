
class BusInformation {
	public string countdown; // Time until bus arrives
	public string line; // Bus no
	public string destination;
	public string platform; // A, B, C etc.
	public string direction; // 'H' for hin, 'R' for rueck
}

class BusInformationParser {
	public List<BusInformation> LoadJson() {
    	using (StreamReader r = new StreamReader("api_response.json")) {
        	string json = r.ReadToEnd();
        	List<BusInformation> information = JsonConvert.DeserializeObject<List<BusInformation>>(json);

        	return information;
    	}
	}
}