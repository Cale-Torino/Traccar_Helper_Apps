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
        const char* st = "2b524553503a47544652492c3046303130362c3836323139333032303638373534372c2c2c31302c312c312c302e302c302c313339392e312c32362e3134303539312c2d32392e3133353137382c32303137313031323232303030372c303635352c303030312c303230302c433535392c30302c3234393638392e352c2c2c2c39312c3431303030302c2c2c2c32303137313031323232303032382c3233343724";
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
 
 




