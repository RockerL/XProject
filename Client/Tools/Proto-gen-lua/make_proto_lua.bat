for %%i in (*.proto) do (    
echo %%i  
protoc.exe --lua_out=./lua/ --plugin=protoc-gen-lua="build.bat" %%i  
  
)  
echo end  

del ..\..\Assets\Lua\Proto\*.lua /q
del ..\..\Assets\Lua\Proto\*.txt /q
xcopy lua\*.lua ..\..\Assets\Lua\Proto /s /e /y  
ren ..\..\Assets\Lua\Proto\*.lua *.lua.txt

pause