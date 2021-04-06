#include<iostream>
#include<fstream>
#include<vector>
#include<algorithm>
#include<math.h>



#include<bits/stdc++.h>

using namespace std;
int matrice[600][600];

ifstream fin ("level4_0.in");
ofstream fout ("level4_0.out");

int id=0;

int is_hotspot(int col, int lin, int inaltime){

    int lungime, latime;
    int i;
    i=lin;

    while(matrice[lin][col]==inaltime){
        lungime++;
        lin++;
    }
    lin = i;
    while(matrice[lin][col]==inaltime){
        latime++;
        col++;
    }

    if(latime >=4 && lungime>=4)
        return 1;
    else
        return 0;
}

void afisare_hotspot(int col, int lin, int inaltime){

    int lungime, latime;
    int xh, yh;
    int i, j;
    i=lin;
    j=col;

    while(matrice[lin][col]==inaltime){
        lungime++;
        lin++;
    }
    lin = i;
    while(matrice[lin][col]==inaltime){
        latime++;
        col++;
    }

    xh = i+lungime/2;
    yh = j+latime/2;
    fout << id <<" "<<xh<<" "<<yh<<" ";
    id++;
}


void sterge_cladire(int col, int lin, int inaltime){

    int lungime, latime;
    int xh, yh;
    int i, j;
    i=lin;
    j=col;

    while(matrice[lin][col]==inaltime){
        lungime++;
        lin++;

        while(matrice[lin][col]==inaltime){
            matrice[lin][col] = 0;
            latime++;
            col++;
        }

        col = j;
    }

}



int main(){



    int nr_col, nr_linii;

    fin >> nr_linii>> nr_col;


    for(int i=0; i<nr_col; i++)
        for(int j=0; j<nr_linii; j++){

        fin>>matrice[i][j];

    }


    for(int i=0; i<nr_linii; i++)
        for(int j=0; j<nr_col; j++){
            if(matrice[i][j]!=0){
                //is hotspot?
                if(is_hotspot(i,j, matrice[i][j])==1){
                //afisare hotspot
                    afisare_hotspot(i,j, matrice[i][j]);
                }
                //stergere cladire
                sterge_cladire(i, j, matrice[i][j]);
            }

    }



    fin.close();
    fout.close();

    return 0;
}
