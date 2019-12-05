if file_exists("Save.sav"){
file_delete("Save.sav");
}

SaveFile= file_text_open_write("Save.sav");
 SaveRoom= maze1;
global.LoadedRoom=maze1;
file_text_write_real(SaveFile,SaveRoom);
file_text_close(SaveFile);
