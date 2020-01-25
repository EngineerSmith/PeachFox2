local insert = table.insert

local map = {}
map.__index = map

--[[
	Properties

	.map			2D table of tiles [x][y][tile]
]]

function map.new(layers)
	local self = {}
	setmetatable(self, map)
	
	self.map = setmetatable({},
		{__index = function(tb,ke) tb[ke]=setmetatable({}, 
			{__index = function(tab,key) tab[key]={} return tab[key] end}) return tb[ke] end})
	
	for _, layer in ipairs(layers) do
		for _, tile in ipairs(layer.tiles) do
			insert(self.map[tile.x][tile.y], tile)
		end
	end
	
	return self
end

-- Get all tag values for a key at a point
function map:getTags(x, y, key)
	local r = {}
	for _, v in ipairs(self.map[x][y]) do
		insert(r, v.tags[key])
	end
	return r
end

-- Run a function for all vailded tags
-- Optional, disgarded function
function map:filter(key, value, func, disfunc)
	if disfunc then -- To decrease checks
		for _, v in ipairs(self.map) do
			for _, tiles in ipairs(v) do
				for _, tile in ipairs(tiles) do
					if tile.tags[key] == value do
						func(tile)
					else
						disfunc(tile)
					end
				end
			end
		end
	else
		for _, v in ipairs(self.map) do
			for _, tiles in ipairs(v) do
				for _, tile in ipairs(tiles) do
					if tile.tags[key] == value do
						func(tile)
					end
				end
			end
		end
	end
end

return map