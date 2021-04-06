//-----------------------------------------------------------------------------
// File: CPlayer.cpp
//
// Desc: This file stores the player object class. This class performs tasks
//       such as player movement, some minor physics as well as rendering.
//
// Original design by Adam Hoult & Gary Simmons. Modified by Mihai Popescu.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// CPlayer Specific Includes
//-----------------------------------------------------------------------------
#include "CPlayer.h"
#include "CGameApp.h"

using namespace std;
extern CGameApp	g_App;

//-----------------------------------------------------------------------------
// Name : CPlayer () (Constructor)
// Desc : CPlayer Class Constructor
//-----------------------------------------------------------------------------
CPlayer::CPlayer(const BackBuffer *pBackBuffer)
{

	player_Sprite = new Sprite("data/player.bmp", RGB(0xff,0x00, 0xfe));
	player_Sprite->setBackBuffer( pBackBuffer );
	m_eSpeedState = SPEED_STOP;
	m_fTimer = 0;
	this->pBackBuffer = pBackBuffer;

	// Animation frame crop rectangle
	RECT r;
	r.left = 0;
	r.top = 0;
	r.right = 64;
	r.bottom = 64;

	m_pExplosionSprite	= new AnimatedSprite("data/explosion.bmp", "data/explosionmask.bmp", r, 16);
	m_pExplosionSprite->setBackBuffer( pBackBuffer );
	m_bExplosion		= false;
	m_iExplosionFrame	= 0;
	m_hWnd = NULL;
}

//-----------------------------------------------------------------------------
// Name : ~CPlayer () (Destructor)
// Desc : CPlayer Class Destructor
//-----------------------------------------------------------------------------
CPlayer::~CPlayer()
{
	delete player_Sprite;
	delete m_pExplosionSprite;
}

void CPlayer::Update(Vec2 direction)
{
	// Update sprite
	player_Sprite->update(direction);
	cleanList();
	cooldown -= 10;
}

void CPlayer::Draw()
{	
	//Cooldown of bullets
	/*if (fireCooldown > 1)
	{
		fireCooldown--;
	}*/

	if (!m_bExplosion)
	{
		player_Sprite->draw();
	}

	else
	{
		m_pExplosionSprite->draw();
	}
}

bool CPlayer::VerifyCollisionObjects(Vec2 position, std::list<Sprite*> objectsList) {

	for (auto &it : objectsList) {
		if (position.x == it->mPosition.x &&  position.y == it->mPosition.y) {
			return true;
		}
	}
	return false;
}

void CPlayer::Move(ULONG ulDirection)
{



	if (ulDirection & CPlayer::DIR_LEFT && player_Sprite->mPosition.x > 256) {
		if (cooldown < 0) {
			if (!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x - 64, player_Sprite->mPosition.y), g_App.solidInteriorList) &&
				!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x - 64, player_Sprite->mPosition.y), g_App.lemnList)) {
				player_Sprite->update(Vec2(-64, 0));
				cooldown = cooldown_init;
			}
		}
	}

	if (ulDirection & CPlayer::DIR_RIGHT && player_Sprite->mPosition.x < 256 + 64 * 22) {
		if (cooldown < 0) {
			if (!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x + 64, player_Sprite->mPosition.y), g_App.solidInteriorList) &&
				!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x + 64, player_Sprite->mPosition.y), g_App.lemnList) ) {
				player_Sprite->update(Vec2(+64, 0));
				cooldown = cooldown_init;
			}
		}
	}
	if (ulDirection & CPlayer::DIR_FORWARD && player_Sprite->mPosition.y > 92) {
		if (cooldown < 0) {
			if (!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x, player_Sprite->mPosition.y - 64), g_App.solidInteriorList) &&
				!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x, player_Sprite->mPosition.y - 64), g_App.lemnList)) {
				player_Sprite->update(Vec2(0, -64));
				cooldown = cooldown_init;
			}
		}
	}
	if (ulDirection & CPlayer::DIR_BACKWARD && player_Sprite->mPosition.y < 92 + 64 * 12) {
		if (cooldown < 0) {
			if (!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x, player_Sprite->mPosition.y + 64), g_App.solidInteriorList) &&
				!VerifyCollisionObjects(Vec2(player_Sprite->mPosition.x, player_Sprite->mPosition.y + 64), g_App.lemnList)) {
				player_Sprite->update(Vec2(0, +64));
				cooldown = cooldown_init;
			}
		}
	}
}

Vec2& CPlayer::Position()
{
	return player_Sprite->mPosition;
}

void CPlayer::Explode()
{
	m_pExplosionSprite->mPosition = player_Sprite->mPosition;
	m_pExplosionSprite->SetFrame(0);
	PlaySound("data/explosion.wav", NULL, SND_FILENAME | SND_ASYNC);
	m_bExplosion = true;
}

void CPlayer::PlaceBomb() {
	if (bombList.size()==0) {
		Bomb* bomb = new Bomb(pBackBuffer, player_Sprite->mPosition);
		bombList.push_back(bomb);
	}
}

void CPlayer::cleanList() {
	if(bombList.size()>0)
		if(bombList.front()->del == true){
			bombList.pop_front();
		}
}

bool CPlayer::AdvanceExplosion()
{
	if(m_bExplosion)
	{
		m_pExplosionSprite->SetFrame(m_iExplosionFrame++);
		if(m_iExplosionFrame==m_pExplosionSprite->GetFrameCount())
		{
			m_bExplosion = false;
			m_iExplosionFrame = 0;
			//player_Sprite->mVelocity = Vec2(0,0);
			m_eSpeedState = SPEED_STOP;
			return false;
		}
	}

	return true;
}

