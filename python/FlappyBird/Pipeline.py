import pygame

class Pipeline(object):
    """  定义小鸟类 """

    def __init__(self):
        self.wallk = 400   # 管道所在的X轴坐标
        self.pineUp = pygame.image.load("assets/top.png")  # 加载上管道图片
        self.pineDowm = pygame.image.load("assets/bottom.png")  # 加载上管道图片
        self.score = 0
    def updatePipeline(self):
        self.wallk -= 5
        if self.wallk < -80:   # 当管道运行到一定位置，即小鸟飞跃管道则分数加1，并且重置管道
            self.score += 1
            self.wallk = 400

