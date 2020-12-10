# coding = utf-8


from RPC import *


if __name__ == '__main__':
    result = AddProcess(1, 15.9)
    print(result)

    result = MinusProcess(10.99, 5.23)
    print(result)

    result = UpperCaseProcess("hello world")
    print(result)

    # 使用不存在的过程
    # result = ProcessNotExist("hello")
    # print(result)

    client.close()
