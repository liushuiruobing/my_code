import requests
import re
import os

def getStation():
    url = 'https://kyfw.12306.cn/otn/resources/js/framework/station_name.js?station_version=1.9063'
    response = requests.get(url, verify = True)   #发送网络请求并验证
    stations = re.findall(u'([\u4e00-\u9fa5]+)\|([A-Z]+)', response.text)  # 获取需要的车站名称  "[\u4e00-\u9fa5]+)\|([A-Z]+"的意思是返回信息中的中文以及大写字母
    stations = dict(stations)   # 把信息转换成字典形式
    stations = str(stations)   #把信息从字典形式转换成字符串类型，目的是为写入文件做准备
    write(stations)   #写入文件，实现下载站名

def write(stations):
    file = open('station.txt', 'w', encoding='utf-8_sig')   #写入模式打开文件
    file.write(stations)
    file.close()

def read():
    file = open('station.txt', 'r', encoding='utf-8_sig')
    data = file.readline()
    file.close
    return data
def isStations():
    isStations = os.path.exists('station.txt')  #判断文件是否存在
    return isStations



