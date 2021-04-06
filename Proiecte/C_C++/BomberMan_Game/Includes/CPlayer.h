//-----------------------------------------------------------------------------
// File: CPlayer.cpp
//
// Desc: This file stores the player object class. This class performs tasks
//	   such as player movement, some minor physics as well as rendering.
//
// Original design by Adam Hoult & Gary Simmons. Modified by Mihai Popescu.
//-----------------------------------------------------------------------------

#ifndef _CPLAYER_H_
#define _CPLAYER_H_

//-----------------------------------------------------------------------------
// CPlayer Specific Includes
//-----------------------------------------------------------------------------
#include "Main.h"
#include "Sprite.h"
#include <list>
#include <vector>
#include "Bomb.h"

using namespace std;

//-----------------------------------------------------------------------------
// Main Class Definitions
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
// Name : CPlayer (Class)
// Desc : Player class handles all player manipulation, update and management.
//-----------------------------------------------------------------------------
class CPlayer
{
public:
	//-------------------------------------------------------------------------
	// Enumerators
	//-------------------------------------------------------------------------
	enum DIRECTION 
	{ 
		DIR_FORWARD	 = 1, 
		DIR_BACKWARD	= 2, 
		DIR_LEFT		= 4, 
		DIR_RIGHT	   = 8, 
	};

	enum ESpeedStates
	{
		SPEED_START,
		SPEED_STOP
	};

	//-------------------------------------------------------------------------
	// Constructors & Destructors for This Class.
	//-------------------------------------------------------------------------
	CPlayer(const BackBuffer *pBackBuffer);
	virtual ~CPlayer();

	//-------------------------------------------------------------------------
	// Public Functions for This Class.
	//-------------------------------------------------------------------------
	void					Update(Vec2 direction );
	void					Draw();
	void					Move(ULONG ulDirection);
	Vec2&					Position();
	void					PlaceBomb();
	void					cleanList();
	bool					VerifyCollisionObjects(Vec2 position, std::list<Sprite*> objectsList);
	//Vec2&					Velocity();

	void					Explode(); // not sure if we keep this
	bool					AdvanceExplosion();// same
	Sprite*					player_Sprite;
	std::list<Bomb*>			bombList;

private:
	//-------------------------------------------------------------------------
	// Private Variables for This Class.
	//-------------------------------------------------------------------------
	
	ESpeedStates			m_eSpeedState;
	float					m_fTimer;
	const BackBuffer		*pBackBuffer;
	HWND					m_hWnd;

	int cooldown_init = 100;
	int cooldown;
	int cooldown_bomb = 200;

	bool					m_bExplosion; // same
	AnimatedSprite*			m_pExplosionSprite; // same
	int						m_iExplosionFrame; // same
};

#endif // _CPLAYER_H_