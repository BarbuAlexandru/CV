if file_exists("SaveSound.sav"){
LoadFileSound= file_text_open_read("SaveSound.sav");
global.LoadedSound=file_text_read_real(LoadFileSound);

obj_MenuUI.muzica=file_text_read_real(LoadFileSound);
file_text_close(LoadFileSound);



}else{

 SaveFileSound= file_text_open_write("SaveSound.sav");
 SaveSound= 1;
obj_MenuUI.muzica=1;
global.LoadedSound=1;
file_text_write_real(SaveFileSound,obj_MenuUI.muzica);
file_text_close(SaveFileSound);
}
