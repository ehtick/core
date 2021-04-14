function FloorIt(number)
	if number ~= nil then
		return math.floor(number)
	end

	return nil
end

function activateLoggers()
	if loggersTimer == nil then
		loggersTimer = createTimer(getMainForm())
	end

	loggersTimer.Interval = 400
	loggersTimer.OnTimer = function()


		local playerHealth = readFloat("[playerVitals]")
		playerHealth = FloorIt(playerHealth)
		local playerMaxHealth = readFloat("[playerVitals]+0x4")        
		local enemyHealth = readFloat("lastEnemyHealthValue")

		enemyHealth = FloorIt(enemyHealth)
		
		local deathcounter = assert(io.open("\\\\parsec\\c$\\streamData\\deathcount-synced.txt","w"))		
		
		local playerDeaths = readInteger("playerDeaths")
		
		if playerDeaths ~= nil then
			deathcounter:write("Deaths: ", playerDeaths)
		end
		
		deathcounter:close()	
		
		
		local stats = assert(io.open("\\\\parsec\\c$\\streamData\\stats.txt","w"))		
		
		if playerHealth ~= nil and playerHealth == 0xFFFFFFFF then
			playerHealth = 0
		end		

		if playerHealth ~= nil and playerMaxHealth ~= nil then
			stats:write("Health: ", playerHealth, "/", playerMaxHealth, "\n")
		end

		if enemyHealth ~= nil then
           stats:write( "Enemy: ", enemyHealth, "\n")
		end

		local lastDamageToPlayer = readFloat("lastDamageToPlayer")
		local maxDamageToPlayer = readFloat("maxDamageToPlayer")
		local lastDamageByPlayer = readFloat("lastDamageByPlayer")
		local maxDamageByPlayer = readFloat("maxDamageByPlayer")
		local totalDamageByPlayer = readFloat("totalDamageByPlayer")

		lastDamageToPlayer = FloorIt(lastDamageToPlayer)
		maxDamageToPlayer = FloorIt(maxDamageToPlayer)
		lastDamageByPlayer = FloorIt(lastDamageByPlayer)
		maxDamageByPlayer = FloorIt(maxDamageByPlayer)
		totalDamageByPlayer = FloorIt(totalDamageByPlayer)

		if lastDamageToPlayer ~= nil and maxDamageToPlayer ~= nil then
			stats:write( "Enemy L/M Dmg: ", lastDamageToPlayer, "/", maxDamageToPlayer, "\n")
		end

		if lastDamageByPlayer ~= nil and maxDamageByPlayer ~= nil then
			stats:write( "Player L/M Dmg: ", lastDamageByPlayer, "/", maxDamageByPlayer, "\n")
		end

		if totalDamageByPlayer ~= nil then
			stats:write( "Player Total Dmg: ", totalDamageByPlayer, "\n")
		end

		local xCoords = readFloat("[playerPhysics]+0x190")
		local yCoords = readFloat("[playerPhysics]+0x194")
		local zCoords = readFloat("[playerPhysics]+0x198")

		if xCoords ~= nil and yCoords ~= nil and zCoords ~= nil then
			stats:write( "X: ", xCoords, "\n")
			stats:write( "Y: ", yCoords, "\n")
			stats:write( "Z: ",  zCoords, "\n")
		end
		
		local playerDamageX = readFloat("playerDamageX")
		
		if playerDamageX ~= nil then
			playerDamageX = math.floor(playerDamageX*10)/10
			stats:write("Player Damage: ", playerDamageX, "x\n")
		end
		
		--local souls = readInteger("[[player]+0x1FA0]+0x74")
		
		if souls ~= nil then
			stats:write("Souls: ", souls, "\n")
		end


		stats:close()

		local log = assert(io.open("log.txt", "a"))

		local ts = os.time()
		local timestamp = os.date('%H:%M-', ts)

		local logEntryEnemyRoll = "Enemy rolls a"
		local logEntryPlayerData
			= "damage!\nPlayer now has"

		local logApocalypse
			= readInteger("logApocalypse")

		local apocalypseResult
			= readInteger("apocalypseResult")

		local riskOfMurderResult
			= readInteger("riskOfMurderResult")
			
		local fatalisResult
			= readInteger("fatalisResult")
			
		local fatalisResultUpper
			= readInteger("fatalisResultUpper")
			
		local fatalisState
			= readInteger("fatalisState")

		local extraDamageX
			= readFloat("extraDamageX")
			
		local lastVerticalDisplacement
			= readFloat("lastVerticalDisplacement")
			
		if fatalisState == 2 then
			log:write(timestamp, "Miraculously, the player has been cured of Fatalis!\n")
			playSound(findTableFile('fatalisCured.wav'))
			writeInteger("fatalisState", 0)
		end

		if logApocalypse == 1 and apocalypseResult ~= nil
							  and lastDamageToPlayer ~= nil
							  and playerHealth ~= nil
							  and timestamp ~= nil
							  and extraDamageX ~= nil
							  and fatalisResult ~= nil
							  and fatalisResultUpper ~= nil
							  and fatalisState ~= nil
							  then
		
			if fatalisState == 1 and fatalisResult == 0 then
				log:write(timestamp, "The player, afflicted with Fatalis, dies immediately from the enemy attack!\n")
				playSound(findTableFile('fatalisDeath.wav'))						
			else
				local apocalypseEnemyRoll =
					string.format("%s%s %i: ", timestamp,
											   logEntryEnemyRoll,
											   apocalypseResult)

				local apocalypseDamagedHealth =
					string.format("%.0f %s %.0f health.\n", lastDamageToPlayer,
															logEntryPlayerData,
															playerHealth)

				if apocalypseResult >= 1 and apocalypseResult <= 4 then
					log:write(apocalypseEnemyRoll,
							  extraDamageX,
							  "x DAMAGE causing ",
							  apocalypseDamagedHealth)
				elseif apocalypseResult == 5 or apocalypseResult == 6 then
					log:write(apocalypseEnemyRoll,
							  "SUDDEN TELEPORTITIS (",
							  lastVerticalDisplacement,
							  ") causing ",
							  apocalypseDamagedHealth)
					if lastVerticalDisplacement > 7.5 then
						playSound(findTableFile('freefallin.wav'))
					end	
				elseif apocalypseResult >= 7 and apocalypseResult <= 9 then
					log:write(apocalypseEnemyRoll,
							  "RISK OF MURDER!\n")

					local riskOfMurderEnemyRoll =
						string.format("%s%s %i: ", timestamp,
												   logEntryEnemyRoll,
												   riskOfMurderResult)

					if riskOfMurderResult <= 3 then
						log:write(riskOfMurderEnemyRoll,
								  "WHEW! Just normal damage causing ",
								  apocalypseDamagedHealth)
						if fatalisResult == fatalisResultUpper then
							log:write(timestamp, "Unfortunately the player has been stricken with Fatalis for the next ten minutes...\n")						
							playSound(findTableFile('fatalisAfflication.wav'))
							writeInteger("fatalisResult",0)
						end								  
					else
						log:write(riskOfMurderEnemyRoll,
								  "HOLY SHIT! Player has been SIXTY NINED causing ",
								  apocalypseDamagedHealth)
								  playSound(findTableFile('Holyshit.wav'))
					end
				else				
						log:write(apocalypseEnemyRoll,
								  "WOW! Player achieves orgasm!\nPlayer is healed fully to ",
								  playerHealth,
								  " health.\n")
								  playSound(findTableFile('Wow.wav'))
				end

			end

			writeInteger("logApocalypse", 0)				

		end

		local logPlayerCrit = readInteger("logPlayerCrit")

		if logPlayerCrit == 1 and lastDamageByPlayer ~= nil then		

			local playerCritDamageResult = readInteger("playerCritDamageResult")

			if playerCritDamageResult ~= nil then
				log:write(timestamp,
						  "Enemy has been critically hit (",
						  playerCritDamageResult/10.0,
						  "x) for ",
						  lastDamageByPlayer,
						  " damage!\n")
            playSound(findTableFile('chocobo.wav'))
			end
			
			writeInteger("logPlayerCrit", 0)
		end

		local logKamehameha = readInteger("logKamehameha")
		local gokuDamageX = readFloat("gokuDamageX")

		if logKamehameha == 1 and lastDamageByPlayer ~= nil
							  and timestamp ~= nil then
			log:write(timestamp,
					  "Player has unlocked his inner Goku and performs a devastating KAMEHAMEHAAAAA attack causing ",
					  gokuDamageX,
					  "x extra damage for a total of ",
					  lastDamageByPlayer,
					  " damage!\n")
            playSound(findTableFile('kame.wav'))
			writeInteger("logKamehameha", 0)
		end

		log:close()
	end

end

function deactivateLoggers()
  if loggersTimer ~= nil then
	loggersTimer.Enabled = false
	loggersTimer.Destroy()
	loggersTimer = nil
  end

end