package Principal;

import java.util.Scanner;

public class Application {
	static Scanner scanner = new Scanner(System.in);
	static String alegere="load4";
	static Matrice4x4 Game=null;
	
	public static void AfisareOptiuniGame(){
		System.out.print("\n");
		System.out.println("w/a/s/d -> swipe up/left/down/right.");
		System.out.println("save (not implemented) -> save game.");
		System.out.println("menu -> menu screen.");
		System.out.println("exit -> exit the application.");
	}
	
	public static void AfisareOptiuniMenu(){
		System.out.print("\n");
		System.out.println("new4 -> new 4x4 game.");
		System.out.println("load4 (ERROR) -> load 4x4 game.");
		System.out.println("exit -> exit the application.");
		System.out.println("Please pick an option.");
	}
	
	public static void ClearScreen() {
		for(int i=0; i<10; i++)
			System.out.println("\n");
		System.out.flush();
	}
	
	public static void MenuGame() throws Exception {
		ClearScreen();
		alegere = "DefaultC";
		AfisareOptiuniMenu();
	    alegere = scanner.nextLine();
	    
	    switch(alegere) {
	    case "new4":
	    	Game = new Matrice4x4();
	    	ClearScreen();
	    	GameGame();
	    	break;
	    case "load4":
	    	Game = new Matrice4x4(1);
	    	ClearScreen();
	    	GameGame();
	    	break;
	    case "exit":
	    	ClearScreen();
			System.out.println("The Game is Closed.");
			scanner.close();
			System.exit(0);
			break;
		case "DefaultC":
			break;
		default:
			ClearScreen();
			System.out.println("Please enter a valid option.");
			MenuGame();
			break;
	    }
	    ClearScreen();
	}
	
	public static void GameGame() throws Exception{
		alegere="DefaultC";
		while(1!=0){
			switch(alegere) {
			case "w":
				Game.SwipeUp();
				break;
			case "a":
				Game.SwipeLeft();
				break;
			case "s":
				Game.SwipeDown();
				break;
			case "d":
				Game.SwipeRight();
				break;
			case "save":
				Game.SaveGame();
				ClearScreen();
				System.out.println("The Game was saved succesfully.");
				break;
			case "menu":
				Game.SwipeRight();
				ClearScreen();
				MenuGame();
				break;
			case "exit":
				System.out.println("The Game is Closed.");
				scanner.close();
				System.exit(0);
				break;
			case "DefaultC":
				break;
			default:
				System.out.println("Please enter a valid option.");
				break;
			}
			Game.AfisareMatrice();
			
			AfisareOptiuniGame();
			System.out.println("Please pick an option.");
			alegere = scanner.nextLine();
			ClearScreen();
		}
	}
	
	
	
	
	
	
	public static void main(String[] args) throws Exception {
		MenuGame();
	//END MAIN	
	}
	
	
//END PROGRAM
}
