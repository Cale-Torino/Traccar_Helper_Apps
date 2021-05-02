#include <stdio.h>
#include <string.h>
#include <cstdlib>


int hex_to_int(char c)
{
    if (c >= 97)
        c = c - 32;
    int first = c / 16 - 3;
    int second = c % 16;
    int result = first * 10 + second;
    if (result > 9) result--;
    return result;
}

int hex_to_ascii(char c, char d){
        int high = hex_to_int(c) * 16;
        int low = hex_to_int(d);
        return high+low;
}

int main(){
        const char* st = "2b524553503a4754494e462c3046303130362c3836323139333032303637373338312c2c34312c38393135343530303030303030343333353631322c33312c302c312c302c2c342e312c302c302c2c2c32303137313031323231353932332c2c2c2c30302c30302c2b303030302c302c32303137313031323232303032322c3534344324";
        int length = strlen(st);
        int i;
        char buf = 0;
        for(i = 0; i < length; i++){
                if(i % 2 != 0){
                        printf("%c", hex_to_ascii(buf, st[i]));
                }else{
                        buf = st[i];
						system("pause>nul");                      
                }
        }
}
 
 




