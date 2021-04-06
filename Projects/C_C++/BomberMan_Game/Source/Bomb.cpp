#include "Bomb.h"

Bomb::Bomb(const BackBuffer *pBackBuffer, Vec2 Position)
{
	m_hWnd = NULL;
	m_pSprite = new Sprite("data/bomb.bmp", RGB(0xff, 0x00, 0xfe));
	m_pSprite->setBackBuffer(pBackBuffer);
	this->pBackBuffer = pBackBuffer;
	m_pSprite->mPosition = Position;
}

Bomb::~Bomb(){

}

void Bomb::update() {
	cooldown -= 1;

	if (cooldown >= 0) {
		not_exploded();
	}
	if (cooldown == 0) {
		explosion_init();
	}
	if (cooldown >= -cooldown_explosion && cooldown < 0) {
		exploded();
	}
	if (cooldown < -cooldown_explosion)

		del = true;
}

void Bomb::explosion_init() {
	Sprite* explosion_sprite = new Sprite("data/explosion_centru.bmp", RGB(0xff, 0x00, 0xfe));
	explosion_sprite->setBackBuffer(pBackBuffer);
	explosion_sprite->mPosition = m_pSprite->mPosition;
	explosionFrameList.push_back(explosion_sprite);

	explosion_sprite = new Sprite("data/explosion_orizontal.bmp", RGB(0xff, 0x00, 0xfe));
	explosion_sprite->setBackBuffer(pBackBuffer);
	explosion_sprite->mPosition.x = m_pSprite->mPosition.x +64;
	explosion_sprite->mPosition.y = m_pSprite->mPosition.y;
	explosionFrameList.push_back(explosion_sprite);

	explosion_sprite = new Sprite("data/explosion_orizontal.bmp", RGB(0xff, 0x00, 0xfe));
	explosion_sprite->setBackBuffer(pBackBuffer);
	explosion_sprite->mPosition.x = m_pSprite->mPosition.x - 64;
	explosion_sprite->mPosition.y = m_pSprite->mPosition.y;
	explosionFrameList.push_back(explosion_sprite);

	explosion_sprite = new Sprite("data/explosion_vertical.bmp", RGB(0xff, 0x00, 0xfe));
	explosion_sprite->setBackBuffer(pBackBuffer);
	explosion_sprite->mPosition.x = m_pSprite->mPosition.x;
	explosion_sprite->mPosition.y = m_pSprite->mPosition.y + 64;
	explosionFrameList.push_back(explosion_sprite);

	explosion_sprite = new Sprite("data/explosion_vertical.bmp", RGB(0xff, 0x00, 0xfe));
	explosion_sprite->setBackBuffer(pBackBuffer);
	explosion_sprite->mPosition.x = m_pSprite->mPosition.x;
	explosion_sprite->mPosition.y = m_pSprite->mPosition.y - 64;
	explosionFrameList.push_back(explosion_sprite);

	exp = true;
}

void Bomb::not_exploded() {

	m_pSprite->draw();
}

void Bomb::exploded() {
	for (auto &it : explosionFrameList) {
		it->draw();
	}
}

