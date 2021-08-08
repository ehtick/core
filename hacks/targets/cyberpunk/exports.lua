-- Exported configuration settings for Omnified Cyberpunk 2077.
-- Written By: Matt Weber (https://badecho.com) (https://twitch.tv/omni)
-- Copyright 2021 Bad Echo LLC

require("statisticMessages")

function registerExports()
    -- Hit detection (from player attacks) timer.
    if playerAttackingTimer == nil then
        playerAttackingTimer = createTimer(getMainForm())
    end
    
    playerAttackingTimer.Interval = 500
    playerAttackingTimer.OnTimer = function()
        local playerAttacking = readInteger("playerAttacking")
                
        if playerAttacking == nil or playerAttacking == 0 then
            do return end
        else
            playerAttacking = playerAttacking - 1            

            writeInteger("playerAttacking", playerAttacking)
        end
    end

    -- Custom statistics.
    AdditionalStatistics = function()
        local magazine = readInteger("[playerMagazine]+0x340")

        -- A ridiculous value indicates that the previous place in memory has been freshly reallocated.
        if magazine ~= nil and magazine > 1000 then magazine = 0 end


        return {
            WholeStatistic("Magazine", magazine)
        }
    end
end

function unregisterExports()    
    if playerAttackingTimer ~= nil then
        playerAttackingTimer.Enabled = false
        playerAttackingTimer.destroy()
        playerAttackingTimer = nil 
    end
end