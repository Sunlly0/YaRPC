# coding = utf-8


from core.YaClient.YaClient import YaClient, rpc


client = YaClient()


@rpc(client, float)
def AddProcess(a, b):
    pass


@rpc(client, str)
def MinusProcess(s):
    pass


@rpc(client, str)
def ProcessNotExist(s):
    pass


@rpc(client, str)
def UpperCaseProcess(s):
    pass