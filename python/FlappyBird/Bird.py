import pygame

class Bird(object):
    """  定义小鸟类 """
    def __init__(self):
        self.birdRect = pygame.Rect(65, 50, 50, 50)   # 鸟的形状
        # 鸟的3 种姿态
        self.biredStatus = [pygame.image.load("assets/0.png"),
                            pygame.image.load("assets/1.png"),
                            pygame.image.load("assets/2.png"),
                            ]
        self.status = 0     # 默认飞行状态
        self.birdX = 120    # 鸟所在的X轴坐标
        self.birdY = 350    # 鸟所在的Y轴坐标
        self.jump = False   # 默认情况小鸟自动降落
        self.jumpSpeed = 10     # 跳跃高度
        self.gravity = 5        # 重力
        self.dead = False

    def birdUpdate(self):
        if self.jump:  # 小鸟跳跃
            self.jumpSpeed -= 1     # 速度递减，上升越来越慢
            self.birdY -= self.jumpSpeed    # 鸟的Y轴坐标减小，小鸟上升
        else:  # 小鸟坠落
            self.gravity += 0.2  # 重力递增，下降越来越快
            self.birdY += self.gravity

        self.birdRect[1] = self.birdY

