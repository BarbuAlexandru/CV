#include "Enemy.h"
#include "CGameApp.h"

extern CGameApp	g_App;

Enemy::Enemy(const BackBuffer *pBackBuffer, Vec2 position)
{
	m_pSprite = new Sprite("data/enemy.bmp", RGB(0xff, 0x00, 0xfe));
	m_pSprite->setBackBuffer(pBackBuffer);
	this->pBackBuffer = pBackBuffer;
	m_pSprite->mPosition = position;
	direction = 0;
}

Enemy::~Enemy()
{

}

void Enemy::update() {
	cooldown_movement -= 5;

	if (cooldown_movement <= 0) {
		move();
		cooldown_movement = 100;
	}
	draw();
}

void Enemy::draw() {
	m_pSprite->draw();
}

void Enemy::move() {
	switch (direction) {
		//move left
	case 0:
		if ((!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x - 64, m_pSprite->mPosition.y), g_App.solidInteriorList) &&
			!VerifyCollisionObjects(Vec2(m_pSprite->mPosition.x - 64, m_pSprite->mPosition.y), g_App.enemyList) &&
			!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x - 64, m_pSprite->mPosition.y), g_App.lemnList)) && (m_pSprite->mPosition.x > 256)) {
			m_pSprite->update(Vec2(-64, 0));
			cooldown_movement = 100;
		}else {
			changeDirection();
		}
		break;
		//move right
	case 1:
		if ((!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x + 64, m_pSprite->mPosition.y), g_App.solidInteriorList) &&
			!VerifyCollisionObjects(Vec2(m_pSprite->mPosition.x+64, m_pSprite->mPosition.y - 64), g_App.enemyList) &&
			!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x + 64, m_pSprite->mPosition.y), g_App.lemnList)) && (m_pSprite->mPosition.x < 256 + 64 * 22)) {
			m_pSprite->update(Vec2(+64, 0));
			cooldown_movement = 100;
		}else {
			changeDirection();
		}
		break;
		//move up
	case 2:
		if ((!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y - 64), g_App.solidInteriorList) &&
			!VerifyCollisionObjects(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y - 64), g_App.enemyList) &&
			!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y - 64), g_App.lemnList)) && (m_pSprite->mPosition.y > 92)) {
			m_pSprite->update(Vec2(0, -64));
			cooldown_movement = 100;
		}else{
			changeDirection();
		}
		break;
		//move down
	case 3:
		if ((!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y + 64), g_App.solidInteriorList) &&
			!VerifyCollisionObjects(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y + 64), g_App.enemyList) &&
			!VerifyCollisionSprites(Vec2(m_pSprite->mPosition.x, m_pSprite->mPosition.y + 64), g_App.lemnList)) && (m_pSprite->mPosition.y < 92 + 64 * 12)) {
			m_pSprite->update(Vec2(0, +64));
			cooldown_movement = 100;
		}
		else {
			changeDirection();
		}
		break;
	}

}

void Enemy::changeDirection() {
	direction = rand() % 4;
}


bool Enemy::VerifyCollisionSprites(Vec2 position, std::list<Sprite*> objectsList) {

	for (auto &it : objectsList) {
		if (position.x == it->mPosition.x &&  position.y == it->mPosition.y) {
			return true;
		}
	}
	return false;
}

bool Enemy::VerifyCollisionObjects(Vec2 position, std::list<Enemy*> objectsList) {

	for (auto &it : objectsList) {
		if (position.x == it->m_pSprite->mPosition.x &&  position.y == it->m_pSprite->mPosition.y) {
			return true;
		}
	}
	return false;
}
