local speed = 10
local lightCpnt = nil
local ResManager = CS.U3DUtility.ResManager.singleton

function start()
	print("main lua start...")
	
	--testJson()

	testProto()

	local canvas = CS.UnityEngine.GameObject.Find("Canvas")

	local prefab = ResManager:LoadAsset("Prefabs/UI/UITestPanel", typeof(CS.UnityEngine.GameObject));
	CS.UnityEngine.GameObject.Instantiate(prefab, canvas.transform)
end

function testJson()
	local rapidjson = require('rapidjson')
	local t = rapidjson.decode('{"a":123}')
	print(t.a)
	t.a = 456
	local s = rapidjson.encode(t)
	print('json', s)
end

require "Proto.protocol_cs_pb"
function testProto()
	local msg = protocol_cs_pb.GS_Info()  
	msg.name = "foo111"  
	   
	local pb_data = msg:SerializeToString()  -- Parse Example  
	   
	print("create:", msg.name)  
	   
	local msg1 = protocol_cs_pb.GS_Info()
	msg1:ParseFromString(pb_data)  
	print("parser:", msg1.name)   
end

function update()
	--local r = CS.UnityEngine.Vector3.up * CS.UnityEngine.Time.deltaTime * speed
	--self.transform:Rotate(r)
	--lightCpnt.color = CS.UnityEngine.Color(CS.UnityEngine.Mathf.Sin(CS.UnityEngine.Time.time) / 2 + 0.5, 0, 0, 1)
end

function ondestroy()
    --print("lua destroy")
end