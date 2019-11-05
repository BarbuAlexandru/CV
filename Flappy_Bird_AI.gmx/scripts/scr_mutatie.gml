variabila = argument0;
sansa_mutatie = argument1;
putere_mutatie = argument2;
interval = argument3;

randomize();
if(random_range(0,100) < sansa_mutatie){
            variabila += random_range(-putere_mutatie,putere_mutatie) *((interval*2) / 100);
            if(variabila<-interval)
                variabila = -interval;
            if(variabila>interval)
                variabila = interval;
}

return variabila;
