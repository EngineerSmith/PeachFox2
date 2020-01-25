local PATH = (...):match("(.-)[^%.]+$")
local TILEMAP = require(PATH.."tilemap") 

local PeachFox = {}

-- Imports exported lua PeachFox map
function PeachFox.import(path, tilesets)
	local tbl = require(path)
	return PeachFox.newTilemap(tbl, tilesets)
end

-- Create new tilemap from given table
function PeachFox.newTilemap(tbl, tilesets)
	return TILEMAP.new(tbl, tilesets)	
end

return PeachFox