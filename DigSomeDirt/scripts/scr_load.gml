if file_exists("Save.sav"){
LoadFile= file_text_open_read("Save.sav");
global.LoadedRoom=file_text_read_real(LoadFile);

file_text_close(LoadFile);



}else{

 SaveFile= file_text_open_write("Save.sav");
 SaveRoom= maze1;
global.LoadedRoom=maze1;
file_text_write_real(SaveFile,SaveRoom);
file_text_close(SaveFile);
}
