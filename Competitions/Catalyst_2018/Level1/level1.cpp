#include<iostream>
#include<fstream>
#include<vector>
#include<algorithm>

#include<bits/stdc++.h>

using namespace std;

int main(){

    ifstream fin ("level1_0.in");
    ofstream fout ("level1_0.out");

    int coloane, linii;
    int aux;
    int nr_in_vector=0;
    vector<int> v;

    fin >> linii;
    fin >> coloane;

    for(int i=0; i<linii; i++)
        for(int j=0; j<coloane; j++){
            fin >> aux;
            if(aux!=0){
                sort(v.begin(), v.end());
                if(!binary_search(v.begin(), v.end(), aux)){
                    v.push_back(aux);
                    nr_in_vector+=1;
                }
            }
    }

    sort(v.begin(), v.end());

    if(v.begin()==v.end()){

        fout<<0;
        return 0;
    }

    fout << v[0] << " ";
    for(int i=1; i <nr_in_vector; i++){
        if(v[i]!=v[i-1])
            fout<<v[i]<<" ";
    }

    fin.close();
    fout.close();
    return 0;
}
