//-----------------------------------------------------------------------------
// File: CGameApp.cpp
//
// Desc: Game Application class, this is the central hub for all app processing
//
// Original design by Adam Hoult & Gary Simmons. Modified by Mihai Popescu.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// CGameApp Specific Includes
//-----------------------------------------------------------------------------
#include "CGameApp.h"
#include <algorithm>
extern HINSTANCE g_hInst;

using namespace std;

//-----------------------------------------------------------------------------
// CGameApp Member Functions
//-----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
// Name : CGameApp () (Constructor)
// Desc : CGameApp Class Constructor
//-----------------------------------------------------------------------------
CGameApp::CGameApp()
{
	// Reset / Clear all required values
	m_hWnd			= NULL;
	m_hIcon			= NULL;
	m_hMenu			= NULL;
	m_pBBuffer		= NULL;
	m_pPlayer		= NULL;
	m_LastFrameRate = 0;
}

//-----------------------------------------------------------------------------
// Name : ~CGameApp () (Destructor)
// Desc : CGameApp Class Destructor
//-----------------------------------------------------------------------------
CGameApp::~CGameApp()
{
	// Shut the engine down
	ShutDown();
}

//-----------------------------------------------------------------------------
// Name : InitInstance ()
// Desc : Initialises the entire Engine here.
//-----------------------------------------------------------------------------
bool CGameApp::InitInstance( LPCTSTR lpCmdLine, int iCmdShow )
{
	// Create the primary display device
	if (!CreateDisplay()) { ShutDown(); return false; }

	// Build Objects
	if (!BuildObjects()) 
	{ 
		MessageBox( 0, _T("Failed to initialize properly. Reinstalling the application may solve this problem.\nIf the problem persists, please contact technical support."), _T("Fatal Error"), MB_OK | MB_ICONSTOP);
		ShutDown(); 
		return false; 
	}

	// Set up all required game states
	SetupGameState();

	// Success!
	return true;
}

//-----------------------------------------------------------------------------
// Name : CreateDisplay ()
// Desc : Create the display windows, devices etc, ready for rendering.
//-----------------------------------------------------------------------------
bool CGameApp::CreateDisplay()
{
	LPTSTR			WindowTitle = _T("GameFramework");
	LPCSTR			WindowClass = _T("GameFramework_Class");
	Width = 1920;
	Height = 1080;
	RECT			rc;
	WNDCLASSEX		wcex;


	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = CGameApp::StaticWndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = g_hInst;
	wcex.hIcon = LoadIcon(g_hInst, MAKEINTRESOURCE(IDI_ICON));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = 0;
	wcex.lpszClassName = WindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_ICON));

	if (RegisterClassEx(&wcex) == 0)
		return false;

	// Retrieve the final client size of the window
	::GetClientRect(m_hWnd, &rc);
	m_nViewX = rc.left;
	m_nViewY = rc.top;
	m_nViewWidth = rc.right - rc.left;
	m_nViewHeight = rc.bottom - rc.top;

	m_hWnd = CreateWindow(WindowClass, WindowTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT, Width, Height, NULL, NULL, g_hInst, this);

	if (!m_hWnd)
		return false;

	// Show the window
	ShowWindow(m_hWnd, SW_MAXIMIZE);
	//ShowWindow(m_hWnd, SW_MAXIMIZE);

	// Success!!
	return true;
}

//-----------------------------------------------------------------------------
// Name : BeginGame ()
// Desc : Signals the beginning of the physical post-initialisation stage.
//		From here on, the game engine has control over processing.
//-----------------------------------------------------------------------------
int CGameApp::BeginGame()
{
	MSG		msg;

	// Start main loop
	while(true) 
	{
		// Did we recieve a message, or are we idling ?
		if ( PeekMessage(&msg, NULL, 0, 0, PM_REMOVE) ) 
		{
			if (msg.message == WM_QUIT) break;
			TranslateMessage( &msg );
			DispatchMessage ( &msg );
		} 
		else 
		{
			// Advance Game Frame.
			FrameAdvance();

		} // End If messages waiting
	
	} // Until quit message is receieved

	return 0;
}

//-----------------------------------------------------------------------------
// Name : ShutDown ()
// Desc : Shuts down the game engine, and frees up all resources.
//-----------------------------------------------------------------------------
bool CGameApp::ShutDown()
{
	// Release any previously built objects
	ReleaseObjects ( );
	
	// Destroy menu, it may not be attached
	if ( m_hMenu ) DestroyMenu( m_hMenu );
	m_hMenu		 = NULL;

	// Destroy the render window
	SetMenu( m_hWnd, NULL );
	if ( m_hWnd ) DestroyWindow( m_hWnd );
	m_hWnd		  = NULL;
	
	// Shutdown Success
	return true;
}

//-----------------------------------------------------------------------------
// Name : StaticWndProc () (Static Callback)
// Desc : This is the main messge pump for ALL display devices, it captures
//		the appropriate messages, and routes them through to the application
//		class for which it was intended, therefore giving full class access.
// Note : It is VITALLY important that you should pass your 'this' pointer to
//		the lpParam parameter of the CreateWindow function if you wish to be
//		able to pass messages back to that app object.
//-----------------------------------------------------------------------------
LRESULT CALLBACK CGameApp::StaticWndProc(HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam)
{
	// If this is a create message, trap the 'this' pointer passed in and store it within the window.
	if ( Message == WM_CREATE ) SetWindowLong( hWnd, GWL_USERDATA, (LONG)((CREATESTRUCT FAR *)lParam)->lpCreateParams);

	// Obtain the correct destination for this message
	CGameApp *Destination = (CGameApp*)GetWindowLong( hWnd, GWL_USERDATA );
	
	// If the hWnd has a related class, pass it through
	if (Destination) return Destination->DisplayWndProc( hWnd, Message, wParam, lParam );
	
	// No destination found, defer to system...
	return DefWindowProc( hWnd, Message, wParam, lParam );
}

//-----------------------------------------------------------------------------
// Name : DisplayWndProc ()
// Desc : The display devices internal WndProc function. All messages being
//		passed to this function are relative to the window it owns.
//-----------------------------------------------------------------------------
LRESULT CGameApp::DisplayWndProc( HWND hWnd, UINT Message, WPARAM wParam, LPARAM lParam )
{
	static UINT			fTimer;	

	// Determine message type
	switch (Message)
	{
		case WM_CREATE:
			break;
		
		case WM_CLOSE:
			PostQuitMessage(0);
			break;
		
		case WM_DESTROY:
			PostQuitMessage(0);
			break;
		
		case WM_SIZE:
			if ( wParam == SIZE_MINIMIZED )
			{
				// App is inactive
				m_bActive = false;
			
			} // App has been minimized
			else
			{
				// App is active
				m_bActive = true;

				// Store new viewport sizes
				m_nViewWidth  = LOWORD( lParam );
				m_nViewHeight = HIWORD( lParam );
		
			
			} // End if !Minimized

			break;

		case WM_LBUTTONDOWN:
			// Capture the mouse
			SetCapture( m_hWnd );
			GetCursorPos( &m_OldCursorPos );
			break;

		case WM_LBUTTONUP:
			// Release the mouse
			ReleaseCapture( );
			break;

		case WM_KEYDOWN:
			switch(wParam)
			{
			case VK_ESCAPE:
				PostQuitMessage(0);
				break;
			case VK_SPACE:
				m_pPlayer->PlaceBomb();
				break;
			/*case VK_RETURN:
				fTimer = SetTimer(m_hWnd, 1, 70, NULL);
				m_pPlayer->Explode();
				m_pPlayer->player_Sprite->mVelocity = Vec2(0, 0);
				m_pPlayer->Position() = Vec2(100, 900);
				break;
			case VK_F1:
				Save_Game();
				break;
			case VK_F2:
				fTimer = SetTimer(m_hWnd, 1, 70, NULL);
				Load_Game();*/
			}
			
			

			break;

		case WM_TIMER:
			switch(wParam)
			{
			case 1:
				if(!m_pPlayer->AdvanceExplosion())
					KillTimer(m_hWnd, 1);
			}
			break;

		case WM_COMMAND:
			break;

		default:
			return DefWindowProc(hWnd, Message, wParam, lParam);

	} // End Message Switch
	
	return 0;
}

//-----------------------------------------------------------------------------
// Name : BuildObjects ()
// Desc : Build our demonstration meshes, and the objects that instance them
//-----------------------------------------------------------------------------
bool CGameApp::BuildObjects()
{
	srand(time(NULL));
	m_pBBuffer = new BackBuffer(m_hWnd, m_nViewWidth, m_nViewHeight);
	m_pPlayer = new CPlayer(m_pBBuffer);

	//generare grid joc
	Sprite* m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
	m_pSprite->setBackBuffer(m_pBBuffer);
	m_pSprite->mPosition = Vec2(192, 28);
	solid1List.push_back(m_pSprite);

	double second_column;
	double second_row;
	//latura sus
	for (int i = 1; i <= 23; i++) {
		m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
		m_pSprite->setBackBuffer(m_pBBuffer);
		m_pSprite->mPosition.x = 192 + 64 * i;
		m_pSprite->mPosition.y = 28;
		second_row = m_pSprite->mPosition.x + 64;
		solid1List.push_back(m_pSprite);
	}
	//latura stanga
	for (int j = 1; j <= 13; j++) {
		m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
		m_pSprite->setBackBuffer(m_pBBuffer);
		m_pSprite->mPosition.x = 192;
		m_pSprite->mPosition.y = 28 + 64 * j;
		second_column = m_pSprite->mPosition.y + 64;
		solid1List.push_back(m_pSprite);
	}
	//latura jos
	for (int i = 0; i <= 23; i++) {
		m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
		m_pSprite->setBackBuffer(m_pBBuffer);
		m_pSprite->mPosition.x = 192 + 64 * i;
		m_pSprite->mPosition.y = second_column;
		solid1List.push_back(m_pSprite);
	}
	//latura dreapta
	for (int j = 0; j <= 14; j++) {
		m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
		m_pSprite->setBackBuffer(m_pBBuffer);
		m_pSprite->mPosition.x = second_row;
		m_pSprite->mPosition.y = 28 + 64 * j;
		solid1List.push_back(m_pSprite);
	}

	// generare solide interior

	for (int i = 0; i < 11; i++) {
		for (int j = 0; j < 6; j++) {
			m_pSprite = new Sprite("data/solid_1.bmp", RGB(0xff, 0x00, 0xfe));
			m_pSprite->setBackBuffer(m_pBBuffer);
			m_pSprite->mPosition.x = 320 + 128 * i;
			m_pSprite->mPosition.y = 156 + 128 * j;
			solidInteriorList.push_back(m_pSprite);
		}
	}

	for (int i = 0; i < 23; i++) {
		for (int j = 0; j < 13; j++) {
			if ((j == 0 && i == 0) || (j == 1 && i == 0) || (j == 0 && i == 1))
				continue;
			if (rand_pro(40) && (i%2!=1 || j%2!=1)) {
				m_pSprite = new Sprite("data/nesolid_1.bmp", RGB(0xff, 0x00, 0xfe));
				m_pSprite->setBackBuffer(m_pBBuffer);
				m_pSprite->mPosition.x = 256 + 64 * i;
				m_pSprite->mPosition.y = 92 + 64 * j;
				lemnList.push_back(m_pSprite);
			}
		}
	}


	// CREARE INAMICI
	for (int i = 0; i < 5; i++) {
		int x_aux = spatiu_rand(23) * 64 + 256;
		int y_aux = spatiu_rand(13) * 64 + 92;

		bool ok = true;
		while (ok == true) {
			ok = false;
			for (auto &it : lemnList) {
				if (it->mPosition.x == x_aux && it->mPosition.y == y_aux) {
					ok = true;
				}
			}
			for (auto &it : solidInteriorList) {
				if (it->mPosition.x == x_aux && it->mPosition.y == y_aux) {
					ok = true;
				}
			}
			if (enemyList.size() > 0) {
				for (auto &it : enemyList) {
					if (it->m_pSprite->mPosition.x == x_aux && it->m_pSprite->mPosition.y == y_aux) {
						ok = true;
					}
				}
			}
			if (ok == true) {
				x_aux = spatiu_rand(23) * 64 + 256;
				y_aux = spatiu_rand(13) * 64 + 92;
			}
		}

		//Create enemy
		Enemy* inamic = new Enemy(m_pBBuffer, Vec2(double(x_aux), double(y_aux)));
		enemyList.push_back(inamic);
	}

	if (!m_imgBackground.LoadBitmapFromFile("data/Background.bmp", GetDC(m_hWnd))) {
		return false;
	}

	if (!m_imgBackgroundWin.LoadBitmapFromFile("data/BackgroundWin.bmp", GetDC(m_hWnd)))
	{
		return false;
	}

	if (!m_imgBackgroundLose.LoadBitmapFromFile("data/BackgroundLose.bmp", GetDC(m_hWnd)))
	{
		return false;
	}
	
	// Success!
	return true;
}

int CGameApp::spatiu_rand(int max) {
	int spatiu = rand() % max;
	return spatiu;
}

bool CGameApp::rand_pro(int procent) {
	if (procent >= (rand() % 100 + 1))
		return true;
	else
		return false;
}

//-----------------------------------------------------------------------------
// Name : SetupGameState ()
// Desc : Sets up all the initial states required by the game.
//-----------------------------------------------------------------------------
void CGameApp::SetupGameState()
{
	m_pPlayer->Position() = Vec2(256, 92);
}

//-----------------------------------------------------------------------------
// Name : ReleaseObjects ()
// Desc : Releases our objects and their associated memory so that we can
//		rebuild them, if required, during our applications life-time.
//-----------------------------------------------------------------------------
void CGameApp::ReleaseObjects( )
{
	if(m_pPlayer != NULL)
	{
		delete m_pPlayer;
		m_pPlayer = NULL;
	}

	if(m_pBBuffer != NULL)
	{
		delete m_pBBuffer;
		m_pBBuffer = NULL;
	}
}

//-----------------------------------------------------------------------------
// Name : FrameAdvance () (Private)
// Desc : Called to signal that we are now rendering the next frame.
//-----------------------------------------------------------------------------
void CGameApp::FrameAdvance()
{
	static TCHAR FrameRate[ 50 ];
	static TCHAR TitleBuffer[ 255 ];

	// Advance the timer
	m_Timer.Tick( );

	// Skip if app is inactive
	if ( !m_bActive ) return;
	
	// Get / Display the framerate
	if ( m_LastFrameRate != m_Timer.GetFrameRate() )
	{
		m_LastFrameRate = m_Timer.GetFrameRate( FrameRate, 50 );
		sprintf_s( TitleBuffer, _T("Game : %s"), FrameRate );
		SetWindowText( m_hWnd, TitleBuffer );

	} // End if Frame Rate Altered

	// Poll & Process input devices
	ProcessInput();

	// Animate the game objects
	AnimateObjects();

	// Drawing the game objects
	DrawObjects();
}

//-----------------------------------------------------------------------------
// Name : ProcessInput () (Private)
// Desc : Simply polls the input devices and performs basic input operations
//-----------------------------------------------------------------------------
void CGameApp::ProcessInput( )
{
	static UCHAR pKeyBuffer[ 256 ];
	ULONG		Direction = 0;
	//bool		bomb_place = 0;
	POINT		CursorPos;
	float		X = 0.0f, Y = 0.0f;

	// Retrieve keyboard state
	if ( !GetKeyboardState( pKeyBuffer ) ) return;

	// Check the relevant keys
	if ( pKeyBuffer[ VK_UP	] & 0xF0 ) Direction |= CPlayer::DIR_FORWARD;
	if ( pKeyBuffer[ VK_DOWN  ] & 0xF0 ) Direction |= CPlayer::DIR_BACKWARD;
	if ( pKeyBuffer[ VK_LEFT  ] & 0xF0 ) Direction |= CPlayer::DIR_LEFT;
	if ( pKeyBuffer[ VK_RIGHT ] & 0xF0 ) Direction |= CPlayer::DIR_RIGHT;


	
	// Move the player
	m_pPlayer->Move(Direction);


	// Now process the mouse (if the button is pressed)
	if ( GetCapture() == m_hWnd )
	{
		// Hide the mouse pointer
		SetCursor( NULL );

		// Retrieve the cursor position
		GetCursorPos( &CursorPos );

		// Reset our cursor position so we can keep going forever :)
		SetCursorPos( m_OldCursorPos.x, m_OldCursorPos.y );

	} // End if Captured
}

bool CGameApp::SpriteCollision(Sprite *sprite1, Sprite *sprite2) {
	if (sprite1->mPosition.x == sprite2->mPosition.x && sprite1->mPosition.y == sprite2->mPosition.y) {
		return true;
	}
	return false;
}


/*bool CGameApp::SpriteCollision(Sprite *sprite1, Sprite *sprite2)
{

	double left1, left2;
	double right1, right2;
	double top1, top2;
	double bottom1, bottom2;


	left1 = sprite1->mPosition.x - (sprite1->width() / 2);
	left2 = sprite2->mPosition.x - (sprite2->width() / 2);

	right1 = left1 + sprite1->width();
	right2 = left2 + sprite2->width();

	top1 = sprite1->mPosition.y - (sprite1->height() / 2);
	top2 = sprite2->mPosition.y - (sprite2->height() / 2);

	bottom1 = top1 + sprite1->height();
	bottom2 = top2 + sprite2->height();

	if (bottom1 < top2)
	{
		return false;
	}

	else if (top1 > bottom2)
	{
		return false;
	}

	else if (right1 < left2)
	{
		return false;
	}

	else if (left1 > right2)
	{
		return false;
	}

	else
	{
		return true;
	}
};*/


//-----------------------------------------------------------------------------
// Name : AnimateObjects () (Private)
// Desc : Animates the objects we currently have loaded.
//-----------------------------------------------------------------------------
void CGameApp::AnimateObjects()
{
	m_pPlayer->Update(Vec2(0,0));
}

//-----------------------------------------------------------------------------
// Name : DrawObjects () (Private)
// Desc : Draws the game objects
//-----------------------------------------------------------------------------
void CGameApp::DrawObjects()
{
	static UINT			fTimer;
	m_pBBuffer->reset();

	m_imgBackground.Paint(m_pBBuffer->getDC(), 0, 0);



	if (m_pPlayer->bombList.size() > 0)
		for (auto &it : m_pPlayer->bombList) {
			it->update();
		}

	m_pPlayer->Draw();


	for (auto &it : solid1List) {
		it->draw();
	}

	for (auto &it : solidInteriorList) {
		it->draw();
	}
	for (auto &it : lemnList) {
		it->draw();
	}

	if (enemyList.size() > 0) {
		for (auto &it : enemyList) {
			it->update();
			if (SpriteCollision(it->m_pSprite, m_pPlayer->player_Sprite)) {
				player_alive = false;
			}	
		}
	}
	else if (enemyList.size() < 1) {
		enemys_alive = false;
	}

	if (m_pPlayer->bombList.size() > 0) {
		resutExplosion();
	}

	if (enemys_alive == false)
	{
		m_imgBackgroundWin.Paint(m_pBBuffer->getDC(), 0, 0);
	}

	else if (player_alive == false)
	{
		m_imgBackgroundLose.Paint(m_pBBuffer->getDC(), 0, 0);
	}


	m_pBBuffer->present();
}


void CGameApp::resutExplosion() {
	if (m_pPlayer->bombList.front()->exp == true) {
		std::list<Sprite*> lemnList_aux;
		std::list<Enemy*> enemyList_aux;
		for (auto &it : lemnList) {
			for (auto &it2 : m_pPlayer->bombList.front()->explosionFrameList) {
				if (it->mPosition.x == it2->mPosition.x && it->mPosition.y == it2->mPosition.y) {
					lemnList_aux.push_back(it);
				}
			}
		}

		for (auto &it : lemnList_aux) {
			lemnList.remove(it);
		}

		//PT ENEMY
		for (auto &it : enemyList) {
			for (auto &it2 : m_pPlayer->bombList.front()->explosionFrameList) {
				if (it->m_pSprite->mPosition.x == it2->mPosition.x && it->m_pSprite->mPosition.y == it2->mPosition.y) {
					enemyList_aux.push_back(it);
				}
			}
		}

		for (auto &it : enemyList_aux) {
			enemyList.remove(it);
		}

		for (auto &it2 : m_pPlayer->bombList.front()->explosionFrameList) {
			if (m_pPlayer->player_Sprite->mPosition.x == it2->mPosition.x && m_pPlayer->player_Sprite->mPosition.y == it2->mPosition.y) {
				player_alive = false;
			}
		}


		m_pPlayer->bombList.front()->exp == false;
	}

}