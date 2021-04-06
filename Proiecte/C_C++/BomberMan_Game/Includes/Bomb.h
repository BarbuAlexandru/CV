//-----------------------------------------------------------------------------
// File: BOMB.cpp
//
// Desc: This file stores the bomb object class.
//-----------------------------------------------------------------------------

#ifndef _BOMB_H_
#define _BOMB_H_

#include <string>
#include "Main.h"
#include "Sprite.h"
#include <list>

using namespace std;

class Bomb
{
public:
	Bomb(const BackBuffer *pBackBuffer, Vec2 position);
	~Bomb();

	Sprite*					m_pSprite;
	HWND					m_hWnd;
	const BackBuffer *pBackBuffer;

	void update();
	void explosion_init();

	void not_exploded();
	void exploded();

	int cooldown = 120;
	int cooldown_explosion = 15;
	std::list<Sprite*>	  explosionFrameList;
	bool del = false;
	bool exp = false;

};

#endif // !_BOMB_H_



