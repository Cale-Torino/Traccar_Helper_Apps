:CallScript111
@ECHO OFF
mode con: cols=90 lines=20
color 0c
CLS
CALL :ScriptA
CALL :ScriptB
CALL :ScriptC
CALL :ScriptD
pause
goto :eof

:ScriptA
ECHO START OF SCRIPT!!
ECHO Output only the lines containing the word 'HEX:'
ECHO ------------------
SED -n "/HEX:/p" "Server.log" > "processedA.temp"
goto :eof

:ScriptB
ECHO Remove all text before HexCode
ECHO ------------------
SED "s/.*HEX//" "processedA.temp" > "processedB.temp"
DEL "processedA.temp"
ECHO Make newline
ECHO ------------------
SED "s/: /&\n/g" "processedB.temp" > "Input.txt"
ECHO Change : to 0A
ECHO ------------------
SED -i "s/: /0A/g" "Input.txt"
DEL "processedB.temp"
::ECHO Remove spaces Crickey
::ECHO ------------------
::SED -e "s/[\t]//g;/^$/d" "Input.txt"  
goto :eof

:ScriptC
ECHO Start C++ code
ECHO ------------------
START /wait Hex_cmd.exe
goto :eof

:ScriptD
:
ECHO Get +RESP:GTERI only
ECHO ------------------
SED -n "/^+RESP:GTERI/p" "Output.txt" > "GTERI_Only.file"
:
ECHO Get +RESP:GTFSD only
ECHO ------------------
SED -n "/^+RESP:GTFSD/p" "Output.txt" > "GTFSD.file"
:
ECHO Get +RESP:GTFRI only
ECHO ------------------
SED -n "/^+RESP:GTFRI/p" "Output.txt" > "GTFRI.file"
:
ECHO Get +RESP:GTEPS only
ECHO ------------------
SED -n "/^+RESP:GTEPS/p" "Output.txt" > "GTEPS.file"
:
ECHO Get +RESP:GTINF only
ECHO ------------------
SED -n "/^+RESP:GTINF/p" "Output.txt" > "GTINF.file"
:
ECHO Get +RESP:GTMPF only
ECHO ------------------
SED -n "/^+RESP:GTMPF/p" "Output.txt" > "GTMPF.file"
:
DEL "Input.txt"
goto :eof


