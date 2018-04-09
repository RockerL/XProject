for %%i in (*.proto) do (    
echo %%i  
protoc.exe --lua_out=./lua/ --plugin=protoc-gen-lua="build.bat" %%i  
  
)  
echo end  

del ..\..\Assets\Lua\ProtoGen\*.lua /q
del ..\..\Assets\Lua\ProtoGen\*.txt /q
xcopy lua\*.lua ..\..\Assets\Lua\ProtoGen /s /e /y  
ren ..\..\Assets\Lua\ProtoGen\*.lua *.lua.txt

pause