#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class U3DUtilityTcpLayerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(U3DUtility.TcpLayer);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Connect", _m_Connect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddRecvEvent", _m_AddRecvEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveRecvEvent", _m_RemoveRecvEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reconnect", _m_Reconnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Disconnect", _m_Disconnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendPack", _m_SendPack);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 1, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PACK_HEAD_SIZE", U3DUtility.TcpLayer.PACK_HEAD_SIZE);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MSG_ID_SIZE", U3DUtility.TcpLayer.MSG_ID_SIZE);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "singleton", _g_get_singleton);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					U3DUtility.TcpLayer __cl_gen_ret = new U3DUtility.TcpLayer();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to U3DUtility.TcpLayer constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int recvBuffSize = LuaAPI.xlua_tointeger(L, 2);
                    int sendBuffSize = LuaAPI.xlua_tointeger(L, 3);
                    
                    __cl_gen_to_be_invoked.Init( recvBuffSize, sendBuffSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Connect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string ip = LuaAPI.lua_tostring(L, 2);
                    int port = LuaAPI.xlua_tointeger(L, 3);
                    U3DUtility.TcpLayer.OnConnectEvent connEvent = translator.GetDelegate<U3DUtility.TcpLayer.OnConnectEvent>(L, 4);
                    U3DUtility.TcpLayer.OnDisconnectEvent disconnEvent = translator.GetDelegate<U3DUtility.TcpLayer.OnDisconnectEvent>(L, 5);
                    U3DUtility.TcpLayer.OnRecvEvent recvEvent = translator.GetDelegate<U3DUtility.TcpLayer.OnRecvEvent>(L, 6);
                    
                    __cl_gen_to_be_invoked.Connect( ip, port, connEvent, disconnEvent, recvEvent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddRecvEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    U3DUtility.TcpLayer.OnRecvEvent recvEvent = translator.GetDelegate<U3DUtility.TcpLayer.OnRecvEvent>(L, 2);
                    
                    __cl_gen_to_be_invoked.AddRecvEvent( recvEvent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveRecvEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    U3DUtility.TcpLayer.OnRecvEvent recvEvent = translator.GetDelegate<U3DUtility.TcpLayer.OnRecvEvent>(L, 2);
                    
                    __cl_gen_to_be_invoked.RemoveRecvEvent( recvEvent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reconnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.Reconnect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Disconnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string msg = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.Disconnect( msg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendPack(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                U3DUtility.TcpLayer __cl_gen_to_be_invoked = (U3DUtility.TcpLayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    short messId = (short)LuaAPI.xlua_tointeger(L, 2);
                    byte[] data = LuaAPI.lua_tobytes(L, 3);
                    
                    __cl_gen_to_be_invoked.SendPack( messId, data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_singleton(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, U3DUtility.TcpLayer.singleton);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
