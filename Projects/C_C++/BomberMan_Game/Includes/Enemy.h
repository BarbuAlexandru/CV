#pragma once

#ifndef _ENEMY_H_
#define _ENEMY_H_

#include "Main.h"
#include "Sprite.h"
#include <stdlib.h>
#include <time.h>
#include <ctime>
#include <list>
#include <vector>

class Enemy
{
public:
	Enemy(const BackBuffer *pBackBuffer, Vec2 position);
	void update();
	bool VerifyCollisionSprites(Vec2 position, std::list<Sprite*> objectsList);
	bool VerifyCollisionObjects(Vec2 position, std::list<Enemy*> objectsList);
	void changeDirection();
	~Enemy();


	Sprite*					m_pSprite;
	const BackBuffer *pBackBuffer;

	int cooldown_movement = 100;
	void move();
	void draw();
	int direction;
};



#endif // !_ENEMY_H_