# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'MainWindow.ui'
#
# Created by: PyQt5 UI code generator 5.11.2
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtGui, QtWidgets
import sys

class Ui_MainWindow(object):
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(960, 786)
        MainWindow.setMinimumSize(QtCore.QSize(960, 786))
        MainWindow.setMaximumSize(QtCore.QSize(960, 786))
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.label_title_img = QtWidgets.QLabel(self.centralwidget)
        self.label_title_img.setGeometry(QtCore.QRect(0, 0, 960, 141))
        self.label_title_img.setText("")
        self.label_title_img.setObjectName("label_title_img")
        self.widget_query = QtWidgets.QWidget(self.centralwidget)
        self.widget_query.setGeometry(QtCore.QRect(0, 141, 960, 80))
        self.widget_query.setObjectName("widget_query")
        self.label = QtWidgets.QLabel(self.widget_query)
        self.label.setGeometry(QtCore.QRect(30, 30, 54, 12))
        self.label.setObjectName("label")
        self.textEdit_Start = QtWidgets.QTextEdit(self.widget_query)
        self.textEdit_Start.setGeometry(QtCore.QRect(90, 20, 104, 31))
        self.textEdit_Start.setObjectName("textEdit_Start")
        self.label_2 = QtWidgets.QLabel(self.widget_query)
        self.label_2.setGeometry(QtCore.QRect(280, 30, 54, 12))
        self.label_2.setObjectName("label_2")
        self.textEdit_End = QtWidgets.QTextEdit(self.widget_query)
        self.textEdit_End.setGeometry(QtCore.QRect(350, 20, 104, 31))
        self.textEdit_End.setObjectName("textEdit_End")
        self.label_3 = QtWidgets.QLabel(self.widget_query)
        self.label_3.setGeometry(QtCore.QRect(500, 30, 71, 16))
        self.label_3.setObjectName("label_3")
        self.textEdit_Date = QtWidgets.QTextEdit(self.widget_query)
        self.textEdit_Date.setGeometry(QtCore.QRect(590, 20, 104, 31))
        self.textEdit_Date.setObjectName("textEdit_Date")
        self.pushButton_check = QtWidgets.QPushButton(self.widget_query)
        self.pushButton_check.setGeometry(QtCore.QRect(760, 20, 93, 28))
        self.pushButton_check.setObjectName("pushButton_check")
        self.widget = QtWidgets.QWidget(self.centralwidget)
        self.widget.setGeometry(QtCore.QRect(0, 221, 960, 80))
        self.widget.setObjectName("widget")
        self.label_4 = QtWidgets.QLabel(self.widget)
        self.label_4.setGeometry(QtCore.QRect(30, 30, 80, 12))
        self.label_4.setObjectName("label_4")
        self.checkBox_QC = QtWidgets.QCheckBox(self.widget)
        self.checkBox_QC.setGeometry(QtCore.QRect(150, 30, 91, 19))
        self.checkBox_QC.setObjectName("checkBox_QC")
        self.checkBox_DC = QtWidgets.QCheckBox(self.widget)
        self.checkBox_DC.setGeometry(QtCore.QRect(290, 30, 91, 19))
        self.checkBox_DC.setObjectName("checkBox_DC")
        self.checkBox_Z = QtWidgets.QCheckBox(self.widget)
        self.checkBox_Z.setGeometry(QtCore.QRect(420, 30, 91, 19))
        self.checkBox_Z.setObjectName("checkBox_Z")
        self.checkBox_T = QtWidgets.QCheckBox(self.widget)
        self.checkBox_T.setGeometry(QtCore.QRect(570, 30, 91, 19))
        self.checkBox_T.setObjectName("checkBox_T")
        self.checkBox_K = QtWidgets.QCheckBox(self.widget)
        self.checkBox_K.setGeometry(QtCore.QRect(750, 30, 91, 19))
        self.checkBox_K.setObjectName("checkBox_K")
        self.label_5 = QtWidgets.QLabel(self.centralwidget)
        self.label_5.setGeometry(QtCore.QRect(0, 301, 960, 71))
        self.label_5.setText("")
        self.label_5.setObjectName("label_5")
        self.tableView = QtWidgets.QTableView(self.centralwidget)
        self.tableView.setGeometry(QtCore.QRect(0, 373, 960, 411))
        self.tableView.setObjectName("tableView")
        MainWindow.setCentralWidget(self.centralwidget)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "快手爬票"))
        self.label.setText(_translate("MainWindow", "出发地："))
        self.label_2.setText(_translate("MainWindow", "目的地："))
        self.label_3.setText(_translate("MainWindow", "出发日期："))
        self.pushButton_check.setText(_translate("MainWindow", "查询"))
        self.label_4.setText(_translate("MainWindow", "车次类型："))
        self.checkBox_QC.setText(_translate("MainWindow", "QC-高铁"))
        self.checkBox_DC.setText(_translate("MainWindow", "DC-动车"))
        self.checkBox_Z.setText(_translate("MainWindow", "Z-直达"))
        self.checkBox_T.setText(_translate("MainWindow", "T-特快"))
        self.checkBox_K.setText(_translate("MainWindow", "K-快速"))


def show_MainWindow():
    app = QtWidgets.QApplication(sys.argv)  #实例化QApplication类的实例，作为GUI主程序的入口
    MainWindow = QtWidgets.QMainWindow()   #创建QMainWindow
    ui = Ui_MainWindow()    #实例UI类
    ui.setupUi(MainWindow)  #设置窗体UI
    MainWindow.show();
    sys.exit(app.exec())  #当窗口创建完成以后，需要结束主循环

if __name__ == '__main__':
    show_MainWindow()