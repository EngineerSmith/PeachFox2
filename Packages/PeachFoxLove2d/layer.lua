local insert = table.insert
local sort = table.sort

local layer = {}
layer.__index = layer

--[[
	Properties

	.tiles          Table of all tiles                       @ tile.lua
	.static         Table of static tiles                    @ tile.lua
	.animated       Table of tiles with update function      @ tile.lua
	.maxX, .maxY    Max size (pixel units)
	.minX, .minY    Min size (pixel units)
	.tags           Table used to create tile, excluding the tables used for tiles
	.isAnimated     Bool, true if there are tiles in .animated, set at creation
]]

local function sortTiles(a, b)
	if a.data.image and b.data.image then 
		return tostring(a.data.image) < tostring(b.data.image)
	else
		return tostring(a.data) < tostring(b.data)
	end
end

function layer.new(tbl, tiles)
	local self = {}
	setmetatable(self, layer)
	
	self.tiles = {}
	self.static = {}
	self.animated = {}
	
	self.maxX, self.maxY = 0, 0
	self.minX, self.minY = 0, 0s
	self.tags = {}

	for k, v in pairs(tbl) do -- Using pair over ipair due to tags being within the same table
		if type(k) == "number" then
			local tile = {x=v.x, y=v.y, data=tiles[v.tile], layer=self, tags = v}
			if tile.tile.update then
				insert(self.animated, tile)
			else
				insert(self.static, tile)
			end
			insert(self.tiles, tile)
			if #tile.data.quads ~= 0 then
				local _, _, w, h = tile.data.quads[1]:getViewport() -- Could be an issue if size changes in animation
				if v.x + w > self.maxX then self.maxX = v.x + w end
				if v.y + h > self.maxY then self.maxY = v.y + h end	
				if v.x < self.minX then self.minX = v.x end
				if v.y < self.minY then self.minY = v.y end
			end
		else
			self.tags[k] = v
		end
	end
	
	self.isAnimated = #self.animated ~= 0
	
	-- Sorting tiles for sprite batching
	sort(self.static, sortTiles)
	sort(self.animated, sortTiles)
	
	return self
end

-- Run a function for all vailded tags
-- Optional, disgarded function
function layer:filter(key, value, func, disfunc)
	disfunc = disfunc or function(t) end
	for _, tile in ipairs(self.tiles) do
		if tile.data.tags[key] == value then
			func(tile)
		else
			disfunc(tile)
		end
	end
end

function layer:drawStatic()
	for _, v in ipairs(self.tiles) do
		v.data:draw(v.x, v.y)
	end
end

function layer:drawAnimated()
	for _, v in ipairs(self.animated) do
		v.data:draw(v.x, v.y)
	end
end

return layer