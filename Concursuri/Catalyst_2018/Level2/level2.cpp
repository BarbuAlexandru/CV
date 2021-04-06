#include<iostream>
#include<fstream>
#include<vector>
#include<algorithm>
#include<math.h>



#include<bits/stdc++.h>

using namespace std;

int minim(int x, int y){
    if ( x < y)
        return x;
    else
        return y;
}

int absolut(int x, int y){

    if ( x > y)
        return x - y;
    else
        return y - x;
}


int main(){

    ifstream fin ("level2_0.in");
    ofstream fout ("level2_0.out");

    int number_of_lines;
    double xa, xb, xc;
    double ya, yb, yc;
    double R, rx, ry;

    fin >> number_of_lines;

    for(int i = 0; i < number_of_lines; i++){
        fin >> xa >> ya >> xb >> yb >> R;
        xa += 0.5;
        ya += 0.5;
        xb += 0.5;
        yb += 0.5;
        rx = R;
        ry = R;
        if (xa > xb) {
            rx = 1 - rx;
        }
        if (ya > yb) {
            ry = 1 - ry;
        }
        xc = floor(absolut(xa, xb) * rx + minim(xa, xb)+ 0.5);
        yc = floor(absolut(ya, yb) * ry + minim(ya, yb)+ 0.5);

        fout << xc << " " << yc << endl;
    }

    fin.close();
    fout.close();
}
