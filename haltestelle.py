import codecs
import json

import requests
import logging

URL = 'http://app.vrr.de/msapp/XML_DM_REQUEST'

stop_parameter = {
	'name_dm': '7.637305:51.951101:WGS84[DD.DDDDD]',
	'type_dm': 'coord',
	'coordOutputFormatTail': '5',
	'outputFormat': 'JSON',
	'coordOutputFormat': 'WGS84[DD.DDDDD]',
}

display_parameter = {
	'changeSpeed': 'normal',
	'name_dm': '7.637305:51.951101:WGS84[DD.DDDDD]',
	'type_dm': 'coord',
	'useRealtime': '1',
	'coordListOutputFormat': 'STRING',
	'canChangeMOT': '0',
	'sessionID': '0',
	'itOptionsActive': '1',
	'coordOutputFormatTail': '5',
	'mode': 'direct',
	'useAllStops': '1',
	'imparedOptionsActive': '1',
	'maxTimeLoop': '1',
	'includeCompleteStopSeq': '1',
	'useProxFootSearch': '1',
	'stateless': '1',
	'outputFormat': 'JSON',
	'excludedMeans': 'checkbox',
	'mergeDep': '1',
	'lineRestriction': '400',
	'depType': 'stopEvents',
	# 'ptOptionsActive': '1',
	'trlTMOTvalue100': '15',
	'coordOutputFormat': 'WGS84[DD.DDDDD]',
	'locationServerActive': '1',
}


def get_closest_stop(params):
	# Get nearby stops
	r = requests.post(URL, params)
	res = r.json()

	# Identify closest stop to current location
	stops = res['dm']['itdOdvAssignedStops']
	closest_stop = min(stops, key=lambda stp: stp['distance'])
	stop_id = closest_stop['stopID']

	logging.info("Selected closest stop {} with ID {}".format(closest_stop['name'], stop_id))

	return stop_id


def get_display_params(params, closest_stop_id):
	params.update({"name_dm": closest_stop_id, "type_dm": "any"})

	r = requests.post(URL, params)
	r = r.text.encode(r.encoding).decode('utf-8')
	r = json.loads(r)

	departures = r['departureList']

	infos = []
	for line in departures:
		if line['stopID'] != closest_stop_id:
			del line
			continue

		try:
			try:
				displayed = {
					"countdown": line['countdown'],
				}
			except KeyError as e:
				displayed = {
					"day": line['realDateTime']['day'],
					"hour": line['realDateTime']['hour'],
					"minute": line['realDateTime']['minute']
				}

			serving_line = line['servingLine']

			# displayed.update({
			#     "delay": serving_line['delay'],
			#     "time": int(displayed['countdown']) #+ int(serving_line['delay'])
			# })

			operator = line['operator']['code']
			if operator != '01':
				# Handle private bus company
				pass
			else:
				displayed.update({
					"platform": line['platform'],
					"destination": serving_line['direction'],
					"line": serving_line['number'],
					"direction": serving_line['liErgRiProj']['direction']
				})

			infos.append(displayed)
		except KeyError as e:
			logging.warning('Date {} could not be parsed'.format(line['stopName']))

	return infos


if __name__ == '__main__':
	logging.basicConfig(level=logging.INFO)
	logging.info("Querying location {}".format(stop_parameter['name_dm']))

	# closest_stop = get_closest_stop(stop_parameter)
	closest_stop = '24043421'
	infos = get_display_params(display_parameter, closest_stop)

	# import pprint
	# pprint.pprint(infos)

	with open('api_response.json', 'w') as fp:
		json.dump(infos, fp)
