buton_1 = argument0;
buton_2 = argument1;
buton_3 = argument2;
buton_4 = argument3;

if(buton_1 == -1){
    buton_1 = irandom(55)+1;
    while(buton_1==buton_2 || buton_1==buton_3 || buton_1==buton_4){
        buton_1 = irandom(55)+1;
    }}

if(buton_2 == -1){
    buton_2 = irandom(55)+1;
    while(buton_2==buton_1 || buton_2==buton_3 || buton_2==buton_4){
        buton_2 = irandom(55)+1;
    }}
    
if(buton_3 == -1){
    buton_3 = irandom(55)+1;
    while(buton_3==buton_1 || buton_3==buton_2 || buton_3==buton_4){
        buton_3 = irandom(55)+1;
    }}
    
if(buton_4 == -1){
    buton_4 = irandom(55)+1;
    while(buton_4==buton_1 || buton_4==buton_2 || buton_4==buton_3){
        buton_4 = irandom(55)+1;
    }}


script_execute(script_creare_but, buton_1, 15, 1620);
    
script_execute(script_creare_but, buton_2, 565, 1620);

script_execute(script_creare_but, buton_3, 15, 1770);

script_execute(script_creare_but, buton_4, 565, 1770);
