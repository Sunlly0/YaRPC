# coding = utf-8

import socket


class ClientSocket:
    def __init__(self, ip: str, port: int, time_out):
        self.ip = ip
        self.port = port
        self.client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.client_socket.settimeout(time_out)

    def connect(self):
        try:
            self.client_socket.connect((self.ip, self.port))
        except socket.timeout:
            raise TimeoutError("Ya-RPC服务端超时")

    def close(self):
        self.client_socket.shutdown(socket.SHUT_RDWR)
