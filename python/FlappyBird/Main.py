import sys
import pygame
import Bird
import Pipeline
import random


def createMap():
    screen.fill((255, 255, 255))
    screen.blit(background, (0, 0))

    # 显示管道
    screen.blit(Pipeline.pineUp, (Pipeline.wallk, -300))
    screen.blit(Pipeline.pineDowm, (Pipeline.wallk, 500))
    Pipeline.updatePipeline()

    # 显示小鸟
    if Bird.dead:
        Bird.Status = 2
    elif Bird.jump:
        Bird.status = 1
    screen.blit(Bird.biredStatus[Bird.status], (Bird.birdX, Bird.birdY))  # 设置小鸟的坐标
    Bird.birdUpdate()

    # 显示分数
    screen.blit(font.render('Score: ' + str(Pipeline.score), -1, (255, 255, 255)), (100, 50))
    pygame.display.update()

def checkData():
    # 管子的矩形位置
    upPipeRect = pygame.Rect(Pipeline.wallk, -300, Pipeline.pineDowm.get_width() - 10, Pipeline.pineUp.get_height())
    dowmPipeRect = pygame.Rect(Pipeline.wallk, 500, Pipeline.pineDowm.get_width() - 10, Pipeline.pineDowm.get_height())

    # 检测小鸟是否相撞
    if upPipeRect.colliderect(Bird.birdRect) or dowmPipeRect.colliderect(Bird.birdRect):
        Bird.dead = True

    if not 0 < Bird.birdRect[1] < height:
        Bird.dead = True
        return  True
    else:
        return  False

def getResult():
    final_text1 = " Game Over "
    final_text2 = " Your final score is: " + str(Pipeline.score)
    ft1_font = pygame.font.SysFont("Arial", 70)
    ft1_surf = font.render(final_text1, 1, (242, 3, 36))
    ft2_font = pygame.font.SysFont("Arial", 50)
    ft2_surf = font.render(final_text2, 1, (253, 177, 6))
    screen.blit(ft1_surf, [screen.get_width() / 2 -ft1_surf.get_width() / 2, 100])
    screen.blit(ft2_surf, [screen.get_width() / 2 - ft2_surf.get_width() / 2, 200])
    pygame.display.flip()

if __name__ == '__main__':
    pygame.init()
    pygame.font.init()
    font = pygame.font.SysFont(None, 50)
    size = width, height = 401, 650
    screen = pygame.display.set_mode(size)
    pygame.display.set_caption("Flappy Bird")
    clock = pygame.time.Clock()
    Pipeline = Pipeline.Pipeline()
    Bird = Bird.Bird()

    while True:
        clock.tick(60)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                sys.exit()
            if (event.type == pygame.KEYDOWN or event.type == pygame.MOUSEBUTTONDOWN) and not Bird.dead:
                Bird.jump = True
                Bird.gravity = 5
                Bird.jumpSpeed = 10

        background = pygame.image.load("assets/background.png")

        if checkData():
            getResult()
        else:
            createMap()

    pygame.quit()

