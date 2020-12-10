# coding = utf-8

import time
import socket

from settings import IP, PORT, MAX_RETRY, RETRY_TIME_OUT
from core.ClientSocket import ClientSocket
from core.RequestBuilder import RequestBuilder
from core.ResponseParser import ResponseParser


class YaClient:
    def __init__(self):
        print("__init__: YaClient")
        self.socket = ClientSocket(IP, PORT, RETRY_TIME_OUT)
        self.socket.connect()

    def close(self):
        self.socket.close()

    def _call(self, request_bytes):
        self.socket.client_socket.send(request_bytes)
        result = self.socket.client_socket.recv(1024)
        return result

    def call(self, request_bytes):
        retry = 1
        while retry < MAX_RETRY:
            print(f"----第{retry}次尝试----")
            try:
                result = self._call(request_bytes)
                return result
            except socket.timeout:
                retry += 1
        raise TimeoutError("Ya-RPC服务端在方法调用时超时")


def rpc(client: YaClient, _type):
    def outter(func):
        def inner(*args):
            process_name = func.__name__
            request_arg = RequestBuilder.get_request_bytes(process_name, *args)
            result = client.call(request_arg)
            return _type(ResponseParser.parse_response(result))
        return inner
    return outter
