import requests
from pprint import pprint
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
    'includeCompleteStopSeq': '1',
    'useAllStops': '1',
    'imparedOptionsActive': '1',
    'maxTimeLoop': '2',
    'useProxFootSearch': '1',
    'stateless': '1',
    'outputFormat': 'JSON',
    'excludedMeans': 'checkbox',
    'mergeDep': '1',
    'lineRestriction': '400',
    'depType': 'stopEvents',
    'ptOptionsActive': '1',
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
    logging.info("Closest stop for ")
    stop_id = closest_stop['stopID']

    logging.info("Selected closest stop {} with ID {}".format('nameWO', stop_id))

    return stop_id


def get_display_params(params, closest_stop_id):
    params.update({"name_dm": closest_stop_id, "type_dm": "any"})
    r = requests.post(URL, params).json()

    departures = r['departureList']

    display = []
    for line in departures:
        try:
            display.append(line['realDateTime'])
            # del display['year']
            # del display['month']

            serving_line = line['servingLine']
            display[-1].update(
                {"destination": serving_line['direction'],
                 "line": serving_line['number'],
                 "direction": serving_line['liErgRiProj']['direction'],
                 "countdown": line['countdown']
                 })
        except KeyError as e:
            logging.warning('Date {} could not be parsed'.format(line['stopName']))

    return display


if __name__ == '__main__':
    logging.basicConfig(level=logging.INFO)
    logging.info("Querying location {}".format(stop_parameter['name_dm']))

    closest_stop = get_closest_stop(stop_parameter)
    display = get_display_params(display_parameter, closest_stop)

    for value in display:
        if value['direction'] == 'R':
            pprint(value)
