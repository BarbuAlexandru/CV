// Newral Network //
//+++++++++++++++++++++++++++++++++++++++++++++

    bin1 = 0;
    bin2 = 0;
    bout = 0;

//Baza Mijloc
    arrayPrincipal[0,0] = 0;
    arrayPrincipal[0,1] = 0;
    arrayPrincipal[0,2] = 0;
    arrayPrincipal[0,3] = 0;
    arrayPrincipal[0,4] = 0;
    
    
    

if(obj_joc_suprem.nivel < 1){
    randomize();
    
    //IN - 1
    arrayPrincipal[1,0] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[1,1] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[1,2] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[1,3] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[1,4] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    
    //IN - 2
    arrayPrincipal[2,0] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[2,1] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[2,2] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[2,3] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[2,4] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    
    //OUT
    arrayPrincipal[3,0] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[3,1] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[3,2] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[3,3] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    arrayPrincipal[3,4] = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    
    //WIN rest
    win1 = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    win2 = random_range(-obj_joc_suprem.interval_neural,obj_joc_suprem.interval_neural);
    
    //show_message("The players were randomized");
    
}else{
    if file_exists("Save.sav"){
        LoadFile= file_text_open_read("Save.sav");
        
        //WIN
        win1 = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        win2 = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        
        // 1 in
        arrayPrincipal[1,0] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[1,1] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[1,2] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[1,3] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[1,4] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        
        // 2 in
        arrayPrincipal[2,0] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[2,1] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[2,2] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[2,3] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[2,4] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        
        // out
        arrayPrincipal[3,0] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[3,1] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[3,2] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[3,3] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        arrayPrincipal[3,4] = file_text_read_real(LoadFile);
        file_text_readln(LoadFile);
        
       file_text_close(LoadFile);
    }//else{
        //SaveFile= file_text_open_write("Save.sav");
        //initializare obiect_salvare;
       //file_text_write_real(SaveFile,obiect_salvare);
       //file_text_close(SaveFile);
    //}
    
    // MUTATII
    if(obj_joc_suprem.save_best == 1){
        //show_message("The best has survived")
        obj_joc_suprem.save_best = 0;
    }else{
    
        randomize();
    
    
    // WIN
        win1 = scr_mutatie(win1, obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        win2 = scr_mutatie(win2, obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
    
    // 1 in
        arrayPrincipal[1,0] = scr_mutatie(arrayPrincipal[1,0], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[1,1] = scr_mutatie(arrayPrincipal[1,1], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[1,2] = scr_mutatie(arrayPrincipal[1,2], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[1,3] = scr_mutatie(arrayPrincipal[1,3], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[1,4] = scr_mutatie(arrayPrincipal[1,4], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        
    // 2 in
        arrayPrincipal[2,0] = scr_mutatie(arrayPrincipal[2,0], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[2,1] = scr_mutatie(arrayPrincipal[2,1], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[2,2] = scr_mutatie(arrayPrincipal[2,2], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[2,3] = scr_mutatie(arrayPrincipal[2,3], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[2,4] = scr_mutatie(arrayPrincipal[2,4], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        
    // out
        arrayPrincipal[3,0] = scr_mutatie(arrayPrincipal[3,0], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[3,1] = scr_mutatie(arrayPrincipal[3,1], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[3,2] = scr_mutatie(arrayPrincipal[3,2], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[3,3] = scr_mutatie(arrayPrincipal[3,3], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
        arrayPrincipal[3,4] = scr_mutatie(arrayPrincipal[3,4], obj_joc_suprem.sansa_mutatie, obj_joc_suprem.putere_mutatie, obj_joc_suprem.interval_neural);
    }
        
    
} 








//SALVARE BEST PLAYER
    if file_exists("Save.sav"){
        file_delete("Save.sav");
    }
    SaveFile= file_text_open_write("Save.sav");
    
    //WIN
    file_text_write_real(SaveFile, best_player.win1);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.win2);
    file_text_writeln(SaveFile);
    
    // 1 in
    file_text_write_real(SaveFile, best_player.arrayPrincipal[1,0]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[1,1]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[1,2]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[1,3]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[1,4]);
    file_text_writeln(SaveFile);
    
     // 2 in
    file_text_write_real(SaveFile, best_player.arrayPrincipal[2,0]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[2,1]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[2,2]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[2,3]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[2,4]);
    file_text_writeln(SaveFile);
    
     // out
    file_text_write_real(SaveFile, best_player.arrayPrincipal[3,0]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[3,1]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[3,2]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[3,3]);
    file_text_writeln(SaveFile);
    file_text_write_real(SaveFile, best_player.arrayPrincipal[3,4]);
    file_text_writeln(SaveFile);
    
    
    file_text_close(SaveFile);
