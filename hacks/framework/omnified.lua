-- Omnified Framework
-- Written By: Matt Weber (https://badecho.com) (https://twitch.tv/omni)
-- Copyright 2021 Bad Echo LLC

require("defines")
require("utility")

local DEFAULT_FRAMEWORK_PATH = "..\\..\\framework\\"
 
function readPlayerCoordinates()
	local x = not coordinatesAreDoubles 
				and readFloat(playerCoordinatesXAddress) 
				or readDouble(playerCoordinatesXAddress)

	local y = not coordinatesAreDoubles 
				and readFloat(playerCoordinatesYAddress) 
				or readDouble(playerCoordinatesYAddress)

	local z = not coordinatesAreDoubles 
				and readFloat(playerCoordinatesZAddress) 
				or readDouble(playerCoordinatesZAddress)

	if x ~= x then x = 0 end
	if y ~= y then y = 0 end
	if z ~= z then z = 0 end

	local coordinates = { X = x, Y = y,	Z = z }

	return coordinates
end

local function mark()
	local coordinates = readPlayerCoordinates()

	if areNotNil(coordinates.X,coordinates.Y,coordinates.Z) then
		if not coordinatesAreDoubles then
			writeFloat("teleportX", coordinates.X)						
			writeFloat("teleportY", coordinates.Y)
			writeFloat("teleportZ", coordinates.Z)
		else
			writeDouble("teleportX", coordinates.X)			 
			writeDouble("teleportY", coordinates.Y)
			writeDouble("teleportZ", coordinates.Z)
		end
	end	
end

local function recall()
	writeInteger("teleport", 1)
end

local function assemble(assemblyFilePath, disableInfo)
	local assemblyFile = assert(io.open(assemblyFilePath))

	if assemblyFile == nil then 
	  print("Assembly file located at ", assemblyFilePath, " was unable to be opened.")
	  do return end
	end
  
	local assembly = assemblyFile:read("a")
	assemblyFile.close()
  
	assembly = "[ENABLE]\n" .. assembly

	local result, resultDisableInfo = autoAssemble(assembly, false, disableInfo)
  
	if result == false then
	  print("Failed to assemble ", assemblyFilePath)
	end
  
	return result, resultDisableInfo
end

function registerOmnification(targetAssemblyFilePath, pathToFramework)
	if not omnifiedRegistered then
		markHotkey = createHotkey(mark, VK_NUMPAD8)
		recallHotkey = createHotkey(recall, VK_NUMPAD9)

		if pathToFramework == nil then pathToFramework = DEFAULT_FRAMEWORK_PATH end

		omnifiedRegistered, omnifiedDisableInfo = assemble(pathToFramework .. "omnified.asm")
		apocalypseRegistered, apocalypseDisableInfo = assemble(pathToFramework .. "systems\\apocalypse.asm")		
		predatorRegistered, predatorDisableInfo = assemble(pathToFramework .. "systems\\predator.asm")
		abomnificationRegistered, abomnificationDisableInfo = assemble(pathToFramework .. "systems\\abomnification.asm")
		
		if anyNil(omnifiedRegistered, apocalypseRegistered, predatorRegistered, abomnificationRegistered) then
			print("Failed to register the Omnified framework.")
			do return end
		end
		
		if statusTimer == nil then
			statusTimer = createTimer(getMainForm())
		end
		
		statusTimer.Interval = 400
		statusTimer.OnTimer = function()
			local fatalisState 
				= readInteger("fatalisState")
				
			if fatalisState == 1 and fatalisTimer == nil then
				fatalisTimer = createTimer(getMainForm())
				fatalisTimer.Interval = 600000
				fatalisTimer.OnTimer = function()
					writeInteger("fatalisState",2)		
					local previousPlayerDamageX =  readFloat("basePlayerDamageX")

					if previousPlayerDamageX ~= nil then
						writeFloat("playerDamageX", previousPlayerDamageX)
					end 
					
					fatalisTimer.Enabled = false
					fatalisTimer.Destroy()
					fatalisTimer = nil
				end
			end
		end
	end

  if not targetAssemblyRegistered then
    targetAssemblyRegistered, targetAssemblyDisableInfo = assemble(targetAssemblyFilePath)

    if not targetAssemblyRegistered  then
      print("Failed to register the target assembly.")
	  print(targetAssemblyDisableInfo)
    end
  end
end

function unregisterOmnification(targetAssemblyFilePath, pathToFramework)
	if	areTrue(omnifiedRegistered, apocalypseRegistered, predatorRegistered, abomnificationRegistered) then
		markHotkey.destroy()
		recallHotkey.destroy()

		if pathToFramework == nil then pathToFramework = DEFAULT_FRAMEWORK_PATH end

		omnifiedRegistered = assemble(pathToFramework .."omnified.asm", omnifiedDisableInfo)
		apocalypseRegistered = assemble(pathToFramework .. "systems\\apocalypse.asm", apocalypseDisableInfo)
		predatorRegistered = assemble(pathToFramework .. "systems\\predator.asm", predatorDisableInfo)
		abomnificationDisableInfo = assemble(pathToFramework .. "systems\\abomnification.asm", abomnificationDisableInfo)
		
		if not omnifiedRegistered then
			print("Failed to unregister the Omnified framework.")
		else 
			omnifiedRegistered, apocalypseRegistered, predatorRegistered, abomnificationRegistered = false
			
			if statusTimer ~= nil then
				if fatalisTimer ~= nil then
					fatalisTimer.Enabled = false
					fatalisTimer.Destroy()
					fatalisTimer = nil
				end
				
				statusTimer.Enabled = false
				statusTimer.Destroy()
				statusTimer = nil
			end
		end		
	else 
		print("Omnified framework already unregistered.")
	end

  	if targetAssemblyRegistered  then
    	targetAssemblyRegistered = assemble(targetAssemblyFilePath, targetAssemblyDisableInfo)
		
		if not targetAssemblyRegistered then
			print("Failed to unregister the target assembly.")
    	else
      		targetAssemblyRegistered = false
    	end
  	end
end