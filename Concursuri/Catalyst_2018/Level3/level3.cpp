#include<iostream>
#include<fstream>
#include<vector>
#include<algorithm>
#include<math.h>



#include<bits/stdc++.h>

using namespace std;

int maxim(int a, int b){
    return a > b ? a : b;
}

int absolut(int x){

    if ( x >= 0)
        return x;
    else
        return -x;
}

int minim(int x, int y){
    if ( x < y)
        return x;
    else
        return y;
}

int approx(double a){
    if(a + 0.5 > floor(a+1)){
        return floor(a+1);
    }
    else
        return floor(a);
}

int equationx(double x, double xa, double xb, double ya, double yb){
    int n = approx(((x - xa) * (yb - ya) / (xb - xa)) + ya);
    return n;
}

int equationy(double y, double xa, double xb, double ya, double yb){
    int n = approx(((y - ya) * (xb - xa) / (yb - ya)) + xa);
    return n;
}

int main(){

    ifstream fin ("level3_0.in");
    ofstream fout ("level3_0.out");


    int no_of_tuples;
    double xa, ya, xb, yb;
    double minim_cells;

    fin >> no_of_tuples;

    for(int i = 0; i < no_of_tuples; i++){
        fin >> xa >> ya >> xb >> yb;

        if (absolut(xa - xb) >= absolut(ya - yb)){
            minim_cells = absolut(xa - xb);
            for(int i = minim(xa, xb); i <= maxim(xa, xb); i++){
                fout << i << " " << equationx( i, xa, xb, ya, yb) << " ";
            }
            fout << endl;
        }
        else{
            minim_cells = absolut(ya - yb);
            for(int i = minim(ya, yb); i <= maxim(ya, yb); i++){
                fout << equationy( i, xa, xb, ya, yb) << " " << i << " ";
            }
            fout << endl;
        }
    }





    fin.close();
    fout.close();
}

