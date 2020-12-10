# coding: utf-8

import json

from core.Errors import Error


class ResponseParser:
    @staticmethod
    def parse_response(js):
        response = json.loads(js)
        if not response["Success"]:
            raise Error(response["Info"])
        else:
            return response["Result"]