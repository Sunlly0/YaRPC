# coding = utf-8

import json


class RequestBuilder:
    @staticmethod
    def get_request_json(process_name, *args):
        js = dict(ProcessName = process_name, StringParams = [], DecimalParams = [])
        for v in args:
            if type(v) is float or type(v) is int:
                js["DecimalParams"].append(v)
            elif type(v) is str:
                js["StringParams"].append(v)
        return js

    @staticmethod
    def serialize_json(js):
        return json.dumps(js)

    @staticmethod
    def get_request_bytes(process_name, *args):
        js = RequestBuilder.get_request_json(process_name, *args)
        json_string = RequestBuilder.serialize_json(js)
        return bytes(json_string, encoding="utf-8")
