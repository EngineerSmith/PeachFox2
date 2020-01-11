local insert = table.insert

local map = {}
map.__index = map

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

function map:getTags(x, y, key)
	local r = {}
	for _, v in ipairs(self.map[x][y]) do
		if v:getValue(key) then
			insert(r, v:getValue(key))
		end
	end
	return r
end

return map