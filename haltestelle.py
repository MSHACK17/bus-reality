import requests

URL = 'http://app.vrr.de/msapp/XML_DM_REQUEST?'

parameter = {
'changeSpeed':'normal',
'name_dm': '7.637305:51.951101:WGS84[DD.DDDDD]',
'type_dm': 'coord',
'useRealtime': '1',
'coordListOutputFormat':'STRING',
'canChangeMOT' :'0',
'sessionID':'0',
'itOptionsActive':'1',
'coordOutputFormatTail':'5',
'mode':'direct',
'includeCompleteStopSeq':'1',
'useAllStops':'1',
'imparedOptionsActive':'1',
'maxTimeLoop':'2',
'useProxFootSearch':'1',
'stateless':'1',
'outputFormat':'JSON',
'excludedMeans':'checkbox',
'mergeDep':'1',
'lineRestriction':'400',
'depType':'stopEvents',
'ptOptionsActive':'1',
'useRealtime':'1',
'trlTMOTvalue100':'15',
'coordOutputFormat':'WGS84[DD.DDDDD]',
'locationServerActive':'1',
}

r = requests.post(URL, parameter)
