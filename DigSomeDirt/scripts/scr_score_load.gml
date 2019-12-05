if file_exists("SaveScore.sav"){
LoadFileScore= file_text_open_read("SaveScore.sav");
global.LoadedScore=file_text_read_real(LoadFileScore);

file_text_close(LoadFileScore);



}else{

 SaveFileScore= file_text_open_write("SaveScore.sav");
 SaveScore= 0;
global.LoadedScore=0;
file_text_write_real(SaveFileScore,SaveScore);
file_text_close(SaveFileScore);
}
