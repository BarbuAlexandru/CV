package Principal;

import java.util.Random;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner; 

public class Matrice4x4 {
	int marime = 3;
	Random rand = new Random();
	int score = 0;
	
	int[][]  matrice = new int[4][4];
	
	public void NewGame() {
		this.score = 0;
		for(int i=0; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				this.matrice[i][j]=0;
		
		InsertNumber();
		InsertNumber();
	}
	
	public Matrice4x4(){
		NewGame();
	}
	
	public void SaveGame() throws IOException {
		File file = new File("Matrice4x4_Save");
		if(file.exists() && !file.isDirectory()) {
			file.delete();
		}
		
		BufferedWriter fileWriter = new BufferedWriter(new FileWriter("Matrice4x4_Save"));
		fileWriter.write(this.score+"\n");
		for(int i=0; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				fileWriter.write(this.matrice[i][j]+" ");
		fileWriter.close();
	}
	
	public Matrice4x4(int n) throws Exception {
		File file = new File("Matrice4x4_Save");
		
		if(file.exists() && !file.isDirectory()) {
			Scanner scannerFile = new Scanner(file);
			this.score=scannerFile.nextInt();
			for(int i=0; i<=this.marime; i++)
				for(int j=0; j<=this.marime; j++)
					this.matrice[i][j]=scannerFile.nextInt();
			scannerFile.close();
		}else{
			NewGame();
			SaveGame();
		}
	}
	
	public int RandomNr(int n) {
		return rand.nextInt(n);
	}
	
	public int Random2or4(){
		if(RandomNr(100)>70) 
			return 4;
		else
			return 2;
	}
	
	public boolean IsFull() {
		for(int i=0; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				if(this.matrice[i][j]==0)
					return false;
		return true;
	}
	
	public void InsertNumber() {
		int ok=0;
		int i, j;
		
		if(IsFull()==true) {
			System.out.println("\nYOU LOST!\n");
			System.exit(0);
		}
		while(ok==0) {
			i = RandomNr(this.marime+1);
			j = RandomNr(this.marime+1);
			
			if(matrice[i][j]==0) {
				this.matrice[i][j]=Random2or4();
				ok = 1;
			}
		}
	}
	
	public void AfisareMatrice() {
		System.out.println("Your score is: " + this.score + ".\n");
		for(int i=0; i<=this.marime; i++) {
			for(int j=0; j<=this.marime; j++) {
				if(this.matrice[i][j]<10)
					System.out.print(this.matrice[i][j]+"      ");
				else
					if(this.matrice[i][j]>=10 && this.matrice[i][j]<100)
						System.out.print(this.matrice[i][j]+"     ");
					else
						if(this.matrice[i][j]>=100 && this.matrice[i][j]<1000)
							System.out.print(this.matrice[i][j]+"    ");
						else
							if(this.matrice[i][j]>=1000)
								System.out.print(this.matrice[i][j]+"   ");
			}
			System.out.print("\n");
		}
	}
	
	public void RepairTheMatrix() {
		for(int i=0; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				if(this.matrice[i][j]<0) {
					this.matrice[i][j]*=-1;
					this.score += this.matrice[i][j];
				}
	}
	
	public int MaxNr() {
		int max = 0;
		for(int i=0; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				if(this.matrice[i][j]>max)
					max = this.matrice[i][j];
		return max;
	}
	
	//FUNCTII MISCARE
	
	public void SwipeUp() {
		int aux;
		int actiune = 0;
		for(int i=0+1; i<=this.marime; i++)
			for(int j=0; j<=this.marime; j++)
				if(this.matrice[i][j]!=0) {
					aux = i-1;
					while(this.matrice[aux][j]==0 && aux > 0) {
						aux-=1;
					}
					
					if(this.matrice[aux][j]==this.matrice[i][j]){
						this.matrice[aux][j]*=-2;
						this.matrice[i][j] = 0;
						actiune = 1;
					}else{
						if(this.matrice[aux][j]==0) {
							this.matrice[aux][j] = this.matrice[i][j];
							this.matrice[i][j] = 0;
							actiune = 1;
						}else{
							if(aux+1<i)
								aux+=1;
							if(this.matrice[aux][j]==this.matrice[i][j]){
								this.matrice[aux][j]*=-2;
								this.matrice[i][j] = 0;
								actiune = 1;
							}else{
								if(this.matrice[aux][j]==0) {
									this.matrice[aux][j] = this.matrice[i][j];
									this.matrice[i][j] = 0;
									actiune = 1;
								}	
							}
						}
					}		
				}
		if(actiune != 0) {
			RepairTheMatrix();
			InsertNumber();
		}
	}
	
	public void SwipeDown() {
		int aux;
		int actiune = 0;
		for(int i=this.marime-1; i>=0; i--)
			for(int j=0; j<=this.marime; j++)
				if(this.matrice[i][j]!=0) {
					aux = i+1;
					while(this.matrice[aux][j]==0 && aux < this.marime) {
						aux+=1;
					}
					
					if(this.matrice[aux][j]==this.matrice[i][j]){
						this.matrice[aux][j]*=-2;
						this.matrice[i][j] = 0;
						actiune = 1;
					}else{
						if(this.matrice[aux][j]==0) {
							this.matrice[aux][j] = this.matrice[i][j];
							this.matrice[i][j] = 0;
							actiune = 1;
						}else{
							if(aux-1>i)
								aux-=1;
							if(this.matrice[aux][j]==this.matrice[i][j]){
								this.matrice[aux][j]*=-2;
								this.matrice[i][j] = 0;
								actiune = 1;
							}else{
								if(this.matrice[aux][j]==0) {
									this.matrice[aux][j] = this.matrice[i][j];
									this.matrice[i][j] = 0;
									actiune = 1;
								}	
							}
						}
					}
				}
		if(actiune != 0) {
			RepairTheMatrix();
			InsertNumber();
		}
	}
	
	public void SwipeRight() {
		int aux;
		int actiune = 0;
		for(int j=this.marime-1; j>=0; j--)
			for(int i=0; i<=this.marime; i++)
				if(this.matrice[i][j]!=0) {
					aux = j+1;
					while(this.matrice[i][aux]==0 && aux < this.marime) {
						aux+=1;
					}
					
					if(this.matrice[i][aux]==this.matrice[i][j]){
						this.matrice[i][aux]*=-2;
						this.matrice[i][j] = 0;
						actiune = 1;
					}else{
						if(this.matrice[i][aux]==0) {
							this.matrice[i][aux] = this.matrice[i][j];
							this.matrice[i][j] = 0;
							actiune = 1;
						}else{
							if(aux-1>j)
								aux-=1;
							if(this.matrice[i][aux]==this.matrice[i][j]){
								this.matrice[i][aux]*=-2;
								this.matrice[i][j] = 0;
								actiune = 1;
							}else{
								if(this.matrice[i][aux]==0) {
									this.matrice[i][aux] = this.matrice[i][j];
									this.matrice[i][j] = 0;
									actiune = 1;
								}	
							}
						}
					}
				}
		if(actiune != 0) {
			RepairTheMatrix();
			InsertNumber();
		}
	}
	
	public void SwipeLeft() {
		int aux;
		int actiune = 0;
		for(int j=0+1; j<=this.marime; j++)
			for(int i=0; i<=this.marime; i++)
				if(this.matrice[i][j]!=0) {
					aux = j-1;
					while(this.matrice[i][aux]==0 && aux > 0) {
						aux-=1;
					}
					
					if(this.matrice[i][aux]==this.matrice[i][j]){
						this.matrice[i][aux]*=-2;
						this.matrice[i][j] = 0;
						actiune = 1;
					}else{
						if(this.matrice[i][aux]==0) {
							this.matrice[i][aux] = this.matrice[i][j];
							this.matrice[i][j] = 0;
							actiune = 1;
						}else{
							if(aux+1<j)
								aux+=1;
							if(this.matrice[i][aux]==this.matrice[i][j]){
								this.matrice[i][aux]*=-2;
								this.matrice[i][j] = 0;
								actiune = 1;
							}else{
								if(this.matrice[i][aux]==0) {
									this.matrice[i][aux] = this.matrice[i][j];
									this.matrice[i][j] = 0;
									actiune = 1;
								}	
							}
						}
					}
				}
		if(actiune != 0) {
			RepairTheMatrix();
			InsertNumber();
		}
	}
}