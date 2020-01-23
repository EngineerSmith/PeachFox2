local PATH = (...):match("(.-)[^%.]+$")
local TILEMAP = require(PATH.."tilemap") 

local PeachFox = {}

function PeachFox.import(path, tilesets)
	local tbl = require(path)
	return PeachFox.newtilemap(tbl, tilesets)
end

function PeachFox.newtilemap(tbl, tilesets)
	return TILEMAP.new(tbl, tilesets)	
end

return PeachFox